using Prometheus.Client;
using SimonPrinz.LTEMonitor.Model;

namespace SimonPrinz.LTEMonitor.Services;

public class PrometheusService(IServiceScopeFactory pScopeFactory) : BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken pStoppingToken)
	{
		using IServiceScope lScope = pScopeFactory.CreateScope();

		try
		{
			Client lClient = lScope.ServiceProvider.GetRequiredService<Client>();
			IMetricFactory lRegistry = lScope.ServiceProvider.GetRequiredService<IMetricFactory>();

			IMetricFamily<IGauge> lConnectionTime = lRegistry.CreateGauge("connection_time", "Connection Time", labelNames: ["ipv4", "ipv6"]);
			IGauge lConnectionStatus = lRegistry.CreateGauge("connection_status", "Connection Status");
			IMetricFamily<IGauge> lSpeed = lRegistry.CreateGauge("speed", "Speed", labelNames: ["direction"]);
			IMetricFamily<IGauge> lRate = lRegistry.CreateGauge("rate", "Rate", labelNames: ["direction"]);
			IMetricFamily<IGauge> lBytes = lRegistry.CreateGauge("bytes", "Bytes", labelNames: ["direction"]);
			IMetricFamily<IGauge> lLan = lRegistry.CreateGauge("lan", "LAN", labelNames: ["ipv4", "mac"]);
			IGauge lUptime = lRegistry.CreateGauge("uptime", "Uptime");
			IGauge lUsedData = lRegistry.CreateGauge("used_data", "Used Data");

			while (!pStoppingToken.IsCancellationRequested)
			{
				GetConnectionStateResult lConnectionStateTask = await lClient.GetConnectionState();
				GetLanPortInfoResult lLanPortInfoTask = await lClient.GetLanPortInfo();
				GetSystemInfoResult lSystemInfoTask = await lClient.GetSystemInfo();
				GetUsageSettingsResult lUsageSettingsTask = await lClient.GetUsageSettings();

				lConnectionTime
					.WithLabels(lConnectionStateTask.IPv4Adrress, lConnectionStateTask.IPv6Adrress)
					.Set(lConnectionStateTask.ConnectionTime);
				lConnectionStatus.Set(lConnectionStateTask.ConnectionStatus);
				lSpeed.WithLabels("download").Set(lConnectionStateTask.Speed_Dl);
				lSpeed.WithLabels("upload").Set(lConnectionStateTask.Speed_Ul);
				lRate.WithLabels("download").Set(lConnectionStateTask.DlRate);
				lRate.WithLabels("upload").Set(lConnectionStateTask.UlRate);
				lBytes.WithLabels("download").Set(lConnectionStateTask.DlBytes);
				lBytes.WithLabels("upload").Set(lConnectionStateTask.UlBytes);
				foreach (GetLanPortInfoResult.LanPortInfoItem lInfoItem in lLanPortInfoTask.List)
					lLan.WithLabels(lInfoItem.IPAddress, lInfoItem.MACAddress).Set(lInfoItem.ConnectionStatus);
				lUptime.Set(lSystemInfoTask.Uptime);
				lUsedData.Set(lUsageSettingsTask.UsedData);

				await Task.Delay(TimeSpan.FromSeconds(5), pStoppingToken);
			}
		}
		catch (Exception lException)
		{
			Console.WriteLine(lException);
			throw;
		}
	}
}