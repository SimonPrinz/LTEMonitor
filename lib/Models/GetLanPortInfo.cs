using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SimonPrinz.LTE.Models;

public class GetLanPortInfoResult : IResult
{
	[JsonPropertyName("List")]
	public List<LanPortInfoItem> List { get; set; } = new();

	public class LanPortInfoItem
	{
		[JsonPropertyName("IPAddress")]
		public string IPAddress { get; set; } = string.Empty;

		[JsonPropertyName("MACAddress")]
		public string MACAddress { get; set; } = string.Empty;

		[JsonPropertyName("DHCPServer")]
		public string DHCPServer { get; set; } = string.Empty;

		[JsonPropertyName("LanFlag")]
		public string LanFlag { get; set; } = string.Empty;

		[JsonPropertyName("ConnectionStatus")]
		public int ConnectionStatus { get; set; }
	}
}