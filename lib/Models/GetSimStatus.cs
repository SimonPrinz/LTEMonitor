using System.Text.Json.Serialization;

namespace SimonPrinz.LTE.Models;

public class GetSimStatusResult : IResult
{
	[JsonPropertyName("SIMState")]
	public int SimState { get; set; }

	[JsonPropertyName("PinState")]
	public int PinState { get; set; }

	[JsonPropertyName("PinRemainingTimes")]
	public int PinRemainingTimes { get; set; }

	[JsonPropertyName("PukRemainingTimes")]
	public int PukRemainingTimes { get; set; }

	[JsonPropertyName("SIMLockState")]
	public int SimLockState { get; set; }

	[JsonPropertyName("SIMLockRemainingTimes")]
	public int SimLockRemainingTimes { get; set; }

	[JsonPropertyName("PLMN")]
	public string PublicLandMobileNetwork { get; set; } = string.Empty;
}