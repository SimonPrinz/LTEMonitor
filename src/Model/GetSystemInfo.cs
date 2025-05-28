using System.Text.Json.Serialization;

namespace SimonPrinz.LTEMonitor.Model;

public class GetSystemInfoResult : IResult
{
	[JsonPropertyName("SwVersionMain")]
	public string SwVersionMain { get; set; } = string.Empty;

	[JsonPropertyName("SwVersion")]
	public string SwVersion { get; set; } = string.Empty;

	[JsonPropertyName("HwVersion")]
	public string HwVersion { get; set; } = string.Empty;

	[JsonPropertyName("WebUiVersion")]
	public string WebUiVersion { get; set; } = string.Empty;

	[JsonPropertyName("HttpApiVersion")]
	public string HttpApiVersion { get; set; } = string.Empty;

	[JsonPropertyName("AppVersion")]
	public string AppVersion { get; set; } = string.Empty;

	[JsonPropertyName("DeviceName")]
	public string DeviceName { get; set; } = string.Empty;

	[JsonPropertyName("RunTime")]
	public long Uptime { get; set; }

	[JsonPropertyName("IMEI")]
	public string IMEI { get; set; } = string.Empty;

	[JsonPropertyName("sn")]
	public string Sn { get; set; } = string.Empty;

	[JsonPropertyName("MacAddress")]
	public string MacAddress { get; set; } = string.Empty;

	[JsonPropertyName("MacAddress5G")]
	public string MacAddress5G { get; set; } = string.Empty;

	[JsonPropertyName("IMSI")]
	public string IMSI { get; set; } = string.Empty;

	[JsonPropertyName("ICCID")]
	public string ICCID { get; set; } = string.Empty;

	[JsonPropertyName("MsisdnMark")]
	public int MsisdnMark { get; set; }

	[JsonPropertyName("MSISDN")]
	public string MSISDN { get; set; } = string.Empty;
}
