using System.Text.Json.Serialization;

namespace SimonPrinz.LTEMonitor.Model;

public class LoginParams : IParams
{
	[JsonPropertyName("UserName")]
	public string Username { get; set; } = null!;

	[JsonPropertyName("Password")]
	public string Password { get; set; } = null!;
}

public class LoginResult : IResult
{
	[JsonPropertyName("token")]
	public long Token { get; set; }
}