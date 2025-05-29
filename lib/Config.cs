namespace SimonPrinz.LTE;

public class Config
{
	public const string Name = "Config";

	public string Url { get; set; } = string.Empty;
	public string EncryptionKey { get; set; } = string.Empty;
	public string RequestVerificationKey { get; set; } = string.Empty;
	public string Username { get; set; } = "admin";
	public string Password { get; set; } = string.Empty;
}