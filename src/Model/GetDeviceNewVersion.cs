using System.Text.Json.Serialization;

namespace SimonPrinz.LTEMonitor.Model;

public class GetDeviceNewVersionResult : IResult
{
	[JsonPropertyName("State")]
	public int State { get; set; }

	[JsonPropertyName("Version")]
	public string Version { get; set; } = string.Empty;

	[JsonPropertyName("total_size")]
	public int TotalSize { get; set; }
}
