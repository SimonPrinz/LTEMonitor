using System.Text.Json.Serialization;

namespace SimonPrinz.LTEMonitor.Model;

public class GetConnectionStateResult : IResult
{
	[JsonPropertyName("ConnectionStatus")]
	public int ConnectionStatus { get; set; }

	[JsonPropertyName("Conprofileerror")]
	public int Conprofileerror { get; set; }

	[JsonPropertyName("ClearCode")]
	public int ClearCode { get; set; }

	[JsonPropertyName("mPdpRejectCount")]
	public int MPdpRejectCount { get; set; }

	[JsonPropertyName("Tr069ConnectionStatus")]
	public int Tr069ConnectionStatus { get; set; }

	[JsonPropertyName("VoipConnectionStatus")]
	public int VoipConnectionStatus { get; set; }

	[JsonPropertyName("IPv4Adrress")]
	public string IPv4Adrress { get; set; } = string.Empty;

	[JsonPropertyName("Tr069IPv4Adrress")]
	public string Tr069IPv4Adrress { get; set; } = string.Empty;

	[JsonPropertyName("VoipIPv4Adrress")]
	public string VoipIPv4Adrress { get; set; } = string.Empty;

	[JsonPropertyName("IPv6Adrress")]
	public string IPv6Adrress { get; set; } = string.Empty;

	[JsonPropertyName("Tr069IPv6Adrress")]
	public string Tr069IPv6Adrress { get; set; } = string.Empty;

	[JsonPropertyName("VoipIPv6Adrress")]
	public string VoipIPv6Adrress { get; set; } = string.Empty;

	[JsonPropertyName("Speed_Dl")]
	public int Speed_Dl { get; set; }

	[JsonPropertyName("Speed_Ul")]
	public int Speed_Ul { get; set; }

	[JsonPropertyName("DlRate")]
	public int DlRate { get; set; }

	[JsonPropertyName("UlRate")]
	public int UlRate { get; set; }

	[JsonPropertyName("ConnectionTime")]
	public int ConnectionTime { get; set; }

	[JsonPropertyName("UlBytes")]
	public int UlBytes { get; set; }

	[JsonPropertyName("DlBytes")]
	public int DlBytes { get; set; }
}