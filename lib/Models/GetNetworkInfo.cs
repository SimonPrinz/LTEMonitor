using System.Text.Json.Serialization;

namespace SimonPrinz.LTE.Models;

public class GetNetworkInfoResult : IResult
{
	[JsonPropertyName("PLMN")]
	public string PLMN { get; set; } = string.Empty;

	[JsonPropertyName("NetworkType")]
	public int NetworkType { get; set; }

	[JsonPropertyName("NetworkName")]
	public string NetworkName { get; set; } = string.Empty;

	[JsonPropertyName("SpnName")]
	public string SpnName { get; set; } = string.Empty;

	[JsonPropertyName("LAC")]
	public string LAC { get; set; } = string.Empty;

	[JsonPropertyName("CellId")]
	public string CellId { get; set; } = string.Empty;

	[JsonPropertyName("RncId")]
	public string RncId { get; set; } = string.Empty;

	[JsonPropertyName("Roaming")]
	public int Roaming { get; set; }

	[JsonPropertyName("Domestic_Roaming")]
	public int Domestic_Roaming { get; set; }

	[JsonPropertyName("SignalStrength")]
	public int SignalStrength { get; set; }

	[JsonPropertyName("mcc")]
	public string Mcc { get; set; } = string.Empty;

	[JsonPropertyName("mnc")]
	public string Mnc { get; set; } = string.Empty;

	[JsonPropertyName("SINR")]
	public string SINR { get; set; } = string.Empty;

	[JsonPropertyName("RSRP")]
	public string RSRP { get; set; } = string.Empty;

	[JsonPropertyName("RSSI")]
	public string RSSI { get; set; } = string.Empty;

	[JsonPropertyName("eNBID")]
	public string ENBID { get; set; } = string.Empty;

	[JsonPropertyName("CGI")]
	public string CGI { get; set; } = string.Empty;

	[JsonPropertyName("CenterFreq")]
	public string CenterFreq { get; set; } = string.Empty;

	[JsonPropertyName("TxPWR")]
	public string TxPWR { get; set; } = string.Empty;

	[JsonPropertyName("LTE_state")]
	public int LTE_state { get; set; }

	[JsonPropertyName("PLMN_name")]
	public string PLMN_name { get; set; } = string.Empty;

	[JsonPropertyName("Band")]
	public int Band { get; set; }

	[JsonPropertyName("DL_channel")]
	public string DL_channel { get; set; } = string.Empty;

	[JsonPropertyName("UL_channel")]
	public string UL_channel { get; set; } = string.Empty;

	[JsonPropertyName("RSRQ")]
	public string RSRQ { get; set; } = string.Empty;

	[JsonPropertyName("EcIo")]
	public double EcIo { get; set; }

	[JsonPropertyName("RSCP")]
	public int RSCP { get; set; }
}
