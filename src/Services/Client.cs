using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using SimonPrinz.LTEMonitor.Model;
using SimonPrinz.LTEMonitor.Utils;
using IResult = SimonPrinz.LTEMonitor.Model.IResult;

namespace SimonPrinz.LTEMonitor.Services;

public class Client : IDisposable
{
	private readonly Config _Config;
	private readonly HttpClient _HttpClient;
	private readonly IMemoryCache _MemoryCache;
	private readonly ILogger<Client> _Logger;

	public Client(IOptions<Config> pOptions, IMemoryCache pMemoryCache, ILogger<Client> pLogger)
	{
		_MemoryCache = pMemoryCache;
		_Logger = pLogger;
		_Config = pOptions.Value;

		_HttpClient = new HttpClient
		{
			BaseAddress = new Uri(_Config.Url)
		};
		_HttpClient.DefaultRequestHeaders.Referrer = new Uri(_HttpClient.BaseAddress, "/index.html");
		_HttpClient.DefaultRequestHeaders.Add("_TclRequestVerificationKey", _Config.RequestVerificationKey);
	}

	public void Dispose()
	{
		_MemoryCache.Dispose();
		_HttpClient.Dispose();

		GC.SuppressFinalize(this);
	}

	public Task<GetSystemInfoResult> GetSystemInfo() =>
		RunMethodAsync<GetSystemInfoResult>("GetSystemInfo");

	public Task<GetSimStatusResult> GetSimStatus() =>
		RunMethodAsync<GetSimStatusResult>("GetSimStatus");

	public Task<GetSystemStatusResult> GetSystemStatus() =>
		RunMethodAsync<GetSystemStatusResult>("GetSystemStatus");

	public Task<GetNetworkInfoResult> GetNetworkInfo() =>
		RunMethodAsync<GetNetworkInfoResult>("GetNetworkInfo", true);

	public Task<GetConnectionStateResult> GetConnectionState() =>
		RunMethodAsync<GetConnectionStateResult>("GetConnectionState", true);

	public Task<GetWanSettingsResult> GetWanSettings() =>
		RunMethodAsync<GetWanSettingsResult>("GetWanSettings", true);

	public Task<GetCurrentProfileResult> GetCurrentProfile() =>
		RunMethodAsync<GetCurrentProfileResult>("getCurrentProfile", true);

	public Task<GetDeviceNewVersionResult> GetDeviceNewVersion() =>
		RunMethodAsync<GetDeviceNewVersionResult>("GetDeviceNewVersion");

	public Task<GetUsageSettingsResult> GetUsageSettings() =>
		RunMethodAsync<GetUsageSettingsResult>("GetUsageSettings", true);

	public Task<GetLoginStateResult> GetLoginState(bool pCallLoggedIn = false) =>
		RunMethodAsync<GetLoginStateResult>("GetLoginState", pCallLoggedIn);

	public Task<GetLanPortInfoResult> GetLanPortInfo() =>
		RunMethodAsync<GetLanPortInfoResult>("GetLanPortInfo", true);

	private Task<string> GetTokenAsync() => _MemoryCache.GetOrCreateAsync("token", async pEntry =>
	{
		pEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

		LoginResult lResult = await RunMethodAsync<LoginResult, LoginParams>("Login", new LoginParams
		{
			Username = _Config.Username.Encrypt(_Config.EncryptionKey),
			Password = _Config.Password.Encrypt(_Config.EncryptionKey)
		});

		return lResult.Token.Encrypt(_Config.EncryptionKey);
	})!;

	private Task<TResult> RunMethodAsync<TResult>(string pMethod, bool pAuthRequired = false) where TResult : IResult =>
		RunMethodAsync<TResult, NullParams>(pMethod, null, pAuthRequired);

	private async Task<TResult> RunMethodAsync<TResult, TParam>(string pMethod, TParam? pParams = default, bool pAuthRequired = false, int pRetry = 3) where TResult : IResult where TParam : IParams
	{
		using HttpRequestMessage lRequest = new(HttpMethod.Post, "/jrd/webapi");
		if (pAuthRequired)
			lRequest.Headers.Add("_TclRequestVerificationToken", await GetTokenAsync());
		Request<TParam> lRequestData = new()
		{
			Method = pMethod
		};
		if (pParams != null)
			lRequestData.Params = pParams;
		lRequest.Content = new StringContent(JsonSerializer.Serialize(lRequestData));

		_Logger.LogInformation($"Running method '{pMethod}'");
		using HttpResponseMessage lResponse = await _HttpClient.SendAsync(lRequest);
		if (!lResponse.IsSuccessStatusCode)
			throw new HttpRequestException($"Failed to run method '{pMethod}': {lResponse.StatusCode} - {await lResponse.Content.ReadAsStringAsync()}");

		Response<TResult> lResult = (await lResponse.Content.ReadFromJsonAsync<Response<TResult>>())!;
		if (lResult.Error == null)
			return lResult.Result!;
		_Logger.LogError($"Failed to run method '{pMethod}': {lResult.Error.Code} - {lResult.Error.Message}");
		if (lResult.Error.Code != "-32698")
			throw new Exception($"Failed to run {pMethod}: {lResult.Error.Code} - {lResult.Error.Message}");
		_Logger.LogWarning($"Token expired, forcing re-login");
		_MemoryCache.Remove("token");
		if (pRetry > 0)
			return await RunMethodAsync<TResult, TParam>(pMethod, pParams, pAuthRequired, --pRetry);
		_Logger.LogCritical($"Failed to run method '{pMethod}' after retries");
		throw new Exception($"Failed to run {pMethod} after multiple retries: ${lResult.Error.Message}");
	}
}