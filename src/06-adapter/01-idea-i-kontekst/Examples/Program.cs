namespace Examples;

public interface IPaymentGateway
{
	string Charge(decimal amount, string currency);
}

public sealed class LegacyPaymentSystem
{
	public string MakePayment(double value, string isoCurrency)
	{
		return $"LEGACY_OK:{value:0.00}:{isoCurrency}";
	}
}

public sealed class LegacyGatewayAdapter : IPaymentGateway
{
	private readonly LegacyPaymentSystem _legacy;

	public LegacyGatewayAdapter(LegacyPaymentSystem legacy)
	{
		_legacy = legacy;
	}

	public string Charge(decimal amount, string currency)
	{
		return _legacy.MakePayment((double)amount, currency);
	}
}

public static class Program
{
	public static void Main()
	{
		IPaymentGateway gateway = new LegacyGatewayAdapter(new LegacyPaymentSystem());
		var result = gateway.Charge(120.50m, "PLN");
		Console.WriteLine(result);
	}
}
