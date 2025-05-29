using System.Text.Json.Serialization;

namespace SimonPrinz.LTE.Models;

public class GetCurrentProfileResult : IResult
{
	[JsonPropertyName("ProfileID")]
	public int ProfileID { get; set; }

	[JsonPropertyName("IsPredefine")]
	public int IsPredefine { get; set; }

	[JsonPropertyName("AuthType")]
	public int AuthType { get; set; }

	[JsonPropertyName("ProfileName")]
	public string ProfileName { get; set; } = string.Empty;

	[JsonPropertyName("UserName")]
	public string UserName { get; set; } = string.Empty;

	[JsonPropertyName("DailNumber")]
	public string DailNumber { get; set; } = string.Empty;

	[JsonPropertyName("Password")]
	public string Password { get; set; } = string.Empty;

	[JsonPropertyName("APN")]
	public string APN { get; set; } = string.Empty;

	[JsonPropertyName("PdpType")]
	public int PdpType { get; set; }

	[JsonPropertyName("IPAdrress")]
	public string IPAdrress { get; set; } = string.Empty;
}
