using System.Text.Json.Serialization;

namespace SimonPrinz.LTEMonitor.Model;

public class Request<TParams> where TParams : IParams
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = "1";

	[JsonPropertyName("jsonrpc")]
	public string JsonRpc { get; set; } = "2.0";

	[JsonPropertyName("method")]
	public string Method { get; set; } = null!;

	[JsonPropertyName("params")]
	public TParams Params { get; set; } = default!;
}

public interface IParams
{
}

public class NullParams : IParams
{
}

public class Response<TResult> where TResult : IResult
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = null!;

	[JsonPropertyName("jsonrpc")]
	public string JsonRpc { get; set; } = null!;

	[JsonPropertyName("result")]
	public TResult? Result { get; set; }
	
	[JsonPropertyName("error")]
	public ResponseError? Error { get; set; }

	public class ResponseError
	{
		[JsonPropertyName("code")]
		public string Code { get; set; }
		[JsonPropertyName("message")]
		public string Message { get; set; }
	}
}

public interface IResult
{
}