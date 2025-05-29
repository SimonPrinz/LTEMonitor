using System.Text.Json.Serialization;

namespace SimonPrinz.LTE.Models;

public class GetSystemStatusResult : IResult
{
	[JsonPropertyName("NetworkMode")]
	public int NetworkMode { get; set; }

	[JsonPropertyName("NetworkType")]
	public int NetworkType { get; set; }

	[JsonPropertyName("NetworkName")]
	public string NetworkName { get; set; } = string.Empty;

	[JsonPropertyName("Roaming")]
	public int Roaming { get; set; }

	[JsonPropertyName("Domestic_Roaming")]
	public int Domestic_Roaming { get; set; }

	[JsonPropertyName("SignalStrength")]
	public int SignalStrength { get; set; }

	[JsonPropertyName("ConnectionStatus")]
	public int ConnectionStatus { get; set; }

	[JsonPropertyName("Conprofileerror")]
	public int Conprofileerror { get; set; }

	[JsonPropertyName("SmsState")]
	public int SmsState { get; set; }

	[JsonPropertyName("curr_num_2g")]
	public int CurrNum2g { get; set; }

	[JsonPropertyName("curr_num_5g")]
	public int CurrNum5g { get; set; }

	[JsonPropertyName("WlanState")]
	public int WlanState { get; set; }

	[JsonPropertyName("WlanState_2g")]
	public int WlanState2g { get; set; }

	[JsonPropertyName("WlanState_5g")]
	public int WlanState5g { get; set; }

	[JsonPropertyName("UsbStatus")]
	public int UsbStatus { get; set; }

	[JsonPropertyName("UsbName")]
	public string UsbName { get; set; } = string.Empty;

	[JsonPropertyName("Ssid_2g")]
	public string Ssid2g { get; set; } = string.Empty;

	[JsonPropertyName("Ssid_5g")]
	public string Ssid5g { get; set; } = string.Empty;

	[JsonPropertyName("Status")]
	public int Status { get; set; }

	[JsonPropertyName("TotalConnNum")]
	public int TotalConnNum { get; set; }

	[JsonPropertyName("CurrentConnection")]
	public int CurrentConnection { get; set; }

	[JsonPropertyName("VoLTE_Calling")]
	public int VoLTE_Calling { get; set; }
}
