namespace Examples;

public static class Program
{
	public static void Main()
	{
		Console.WriteLine("=== 05. Adapter vs alternatywy ===");

		Console.WriteLine("[Adapter]  Klient -> Adapter -> LegacyApi");
		Console.WriteLine("[Facade]   Klient -> Facade (uproszczone API)");
		Console.WriteLine("[Refactor] Klient i usługa na wspólnym kontrakcie");

		Console.WriteLine();
		Console.WriteLine("Wniosek:");
		Console.WriteLine("- jeśli obie strony są pod kontrolą, refaktoryzacja kontraktu jest zwykle najlepsza,");
		Console.WriteLine("- adapter jest świetny przy integracji z cudzym API i migracji etapowej.");
	}
}
