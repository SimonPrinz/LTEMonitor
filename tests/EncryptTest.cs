namespace SimonPrinz.LTE.Test;

public class EncryptTest
{
	[Test]
	[TestCaseSource(nameof(EncryptTestCases))]
	public void TestEncrypt(string pInput, string pExpectedOutput)
	{
		string lResult = pInput.Encrypt("e5dl12XYVggihggafXWf0f2YSf2Xngd1");

		Assert.That(lResult, Is.EqualTo(pExpectedOutput));
	}

	private static object[] EncryptTestCases() =>
	[
		new object[] { "", "" },
		new object[] { "admin", "dc13ibej?7" },
		new object[] { "test", "ab03gchk" },
		new object[] { "secretPassword", "fb03gbnk4765X]X_UQd```fojoca" }
	];
}