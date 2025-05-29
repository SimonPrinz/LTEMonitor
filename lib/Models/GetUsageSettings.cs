using System.Text.Json.Serialization;

namespace SimonPrinz.LTE.Models;

public class GetUsageSettingsResult : IResult
{
	[JsonPropertyName("BillingDay")]
	public int BillingDay { get; set; }

	[JsonPropertyName("MonthlyPlan")]
	public int MonthlyPlan { get; set; }

	[JsonPropertyName("UsedData")]
	public long UsedData { get; set; }

	[JsonPropertyName("Unit")]
	public int Unit { get; set; }

	[JsonPropertyName("TimeLimitFlag")]
	public int TimeLimitFlag { get; set; }

	[JsonPropertyName("TimeLimitTimes")]
	public int TimeLimitTimes { get; set; }

	[JsonPropertyName("UsedTimes")]
	public int UsedTimes { get; set; }

	[JsonPropertyName("Status")]
	public int Status { get; set; }

	[JsonPropertyName("AutoDisconnFlag")]
	public int AutoDisconnFlag { get; set; }
}
