using System.Text.Json.Serialization;

namespace SimonPrinz.LTEMonitor.Model;

public class GetWanSettingsResult : IResult
{
	[JsonPropertyName("SubNetMask")]
	public string SubnetMask { get; set; } = string.Empty;

	[JsonPropertyName("Gateway")]
	public string Gateway { get; set; } = string.Empty;

	[JsonPropertyName("IpAddress")]
	public string IpAddress { get; set; } = string.Empty;

	[JsonPropertyName("Mtu")]
	public int Mtu { get; set; }

	[JsonPropertyName("ConnectType")]
	public int ConnectType { get; set; }

	[JsonPropertyName("PrimaryDNS")]
	public string PrimaryDns { get; set; } = string.Empty;

	[JsonPropertyName("SecondaryDNS")]
	public string SecondaryDns { get; set; } = string.Empty;

	[JsonPropertyName("Account")]
	public string Account { get; set; } = string.Empty;

	[JsonPropertyName("Password")]
	public string Password { get; set; } = string.Empty;

	[JsonPropertyName("Status")]
	public int Status { get; set; }

	[JsonPropertyName("StaticIpAddress")]
	public string StaticIpAddress { get; set; } = string.Empty;

	[JsonPropertyName("pppoeMtu")]
	public int PppoeMtu { get; set; }

	[JsonPropertyName("DurationTime")]
	public int DurationTime { get; set; }

	[JsonPropertyName("WanType")]
	public string WanType { get; set; } = string.Empty;
}