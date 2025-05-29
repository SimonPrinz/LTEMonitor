using System.Net.Http.Json;
using System.Text;

namespace SimonPrinz.LTE;

public static class Helpers
{
	public static string Encrypt(this long pValue, string pMagicConst) => pValue.ToString("D").Encrypt(pMagicConst);

	public static string Encrypt(this string pValue, string pMagicConst)
	{
		if (string.IsNullOrEmpty(pValue))
			return "";

		List<byte> lBytes = [];

		for (int lIndex = 0; lIndex < pValue.Length; lIndex++)
		{
			char lChar = pValue[lIndex];
			int lMagicOffset = pMagicConst[lIndex % pMagicConst.Length];

			lBytes.Add((byte) (240 & lMagicOffset | 15 & lChar ^ 15 & lMagicOffset));
			lBytes.Add((byte) (240 & lMagicOffset | lChar >> 4 ^ 15 & lMagicOffset));
		}

		return lBytes.Aggregate(new StringBuilder(), (pBuilder, pByte) => pBuilder.Append((char) pByte)).ToString();
	}

	public static Task<T?> ReadFromAnonymousJsonAsync<T>(this HttpContent pContent, T pStructure, CancellationToken pCancellationToken = default) =>
		pContent.ReadFromJsonAsync<T>(pCancellationToken);
}