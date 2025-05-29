using Prometheus.Client;
using SimonPrinz.LTE;
using SimonPrinz.LTE.Models;

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
			IMetricFamily<IGauge> lSpeed = lRegistry.CreateGauge("connection_speed", "Speed", labelNames: ["direction"]);
			IMetricFamily<IGauge> lRate = lRegistry.CreateGauge("connection_rate", "Rate", labelNames: ["direction"]);
			IMetricFamily<IGauge> lBytes = lRegistry.CreateGauge("connection_bytes", "Bytes", labelNames: ["direction"]);

			IMetricFamily<IGauge> lLan = lRegistry.CreateGauge("lan_status", "LAN", labelNames: ["ipv4", "mac"]);

			IGauge lUptime = lRegistry.CreateGauge("system_uptime", "Uptime");

			IMetricFamily<IGauge> lSignal = lRegistry.CreateGauge("network_signal", "Signal", labelNames: ["type"]);

			while (!pStoppingToken.IsCancellationRequested)
			{
				GetConnectionStateResult lConnectionState = await lClient.GetConnectionState();
				lConnectionTime
					.WithLabels(lConnectionState.IPv4Adrress, lConnectionState.IPv6Adrress)
					.Set(lConnectionState.ConnectionTime);
				lConnectionStatus.Set(lConnectionState.ConnectionStatus);
				lSpeed.WithLabels("download").Set(lConnectionState.Speed_Dl);
				lSpeed.WithLabels("upload").Set(lConnectionState.Speed_Ul);
				lRate.WithLabels("download").Set(lConnectionState.DlRate);
				lRate.WithLabels("upload").Set(lConnectionState.UlRate);
				lBytes.WithLabels("download").Set(lConnectionState.DlBytes);
				lBytes.WithLabels("upload").Set(lConnectionState.UlBytes);

				GetLanPortInfoResult lLanPortInfo = await lClient.GetLanPortInfo();
				foreach (GetLanPortInfoResult.LanPortInfoItem lInfoItem in lLanPortInfo.List)
					lLan.WithLabels(lInfoItem.IPAddress, lInfoItem.MACAddress).Set(lInfoItem.ConnectionStatus);

				GetSystemInfoResult lSystemInfo = await lClient.GetSystemInfo();
				lUptime.Set(lSystemInfo.Uptime);

				GetNetworkInfoResult lNetworkInfo = await lClient.GetNetworkInfo();
				if (int.TryParse(lNetworkInfo.RSRP, out int lRsrpValue)) lSignal.WithLabels("rsrp").Set(lRsrpValue);
				else lSignal.WithLabels("rsrp").Reset();
				if (int.TryParse(lNetworkInfo.RSRQ, out int lRsrqValue)) lSignal.WithLabels("rsrq").Set(lRsrqValue);
				else lSignal.WithLabels("rsrq").Reset();
				if (int.TryParse(lNetworkInfo.RSSI, out int lRssiValue)) lSignal.WithLabels("rssi").Set(lRssiValue);
				else lSignal.WithLabels("rssi").Reset();
				if (int.TryParse(lNetworkInfo.SINR, out int lSinrValue)) lSignal.WithLabels("sinr").Set(lSinrValue);
				else lSignal.WithLabels("sinr").Reset();

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