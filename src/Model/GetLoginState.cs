using System.Text.Json.Serialization;

namespace SimonPrinz.LTEMonitor.Model;

public class GetLoginStateResult : IResult
{
	/**
	 * "State" : 0, // 1 when logged in
	 */
	[JsonPropertyName("State")]
	public int State { get; set; }

	[JsonPropertyName("LoginRemainingTimes")]
	public int LoginRemainingTimes { get; set; }

	[JsonPropertyName("LockedRemainingTime")]
	public int LockedRemainingTime { get; set; }

	[JsonPropertyName("PwEncrypt")]
	public int PwEncrypt { get; set; }
}
