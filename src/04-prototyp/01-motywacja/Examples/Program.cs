using Motywacja.Expensive;

Console.WriteLine("=== Singleton vs Fabryka vs Prototyp ===\n");
Console.WriteLine("Pytanie: mamy 3 wzorce kreacyjne (Fabryka, Builder, Prototyp).");
Console.WriteLine("Dlaczego potrzebujemy jeszcze jednego?\n");

// ─────────────────────────────────────────────────────────────────────────────
// Scenariusz 1: Bez Prototypu — każde tworzenie jest kosztowne
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("─── Scenariusz 1: Bez Prototypu (każde tworzenie = pełna inicjalizacja) ───");
var sw = System.Diagnostics.Stopwatch.StartNew();

var c1 = ServerConfig.LoadFromServer("production");
var c2 = ServerConfig.LoadFromServer("production");   // te same dane!
var c3 = ServerConfig.LoadFromServer("production");

sw.Stop();
Console.WriteLine($"\n3 konfiguracje w: {sw.ElapsedMilliseconds} ms (≈ 3 × 500 ms)");
Console.WriteLine($"c1: {c1}");
Console.WriteLine($"c2: {c2}");
Console.WriteLine();

// ─────────────────────────────────────────────────────────────────────────────
// Scenariusz 2: Z Prototypem — kosztowna inicjalizacja tylko raz
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("─── Scenariusz 2: Z Prototypem (inicjalizacja raz, klonowanie błyskawiczne) ───");
sw.Restart();

var prototype = ServerConfig.LoadFromServer("production");   // raz (kosztowne)

var clone1 = prototype.Clone();                              // ~0 ms
var clone2 = prototype.Clone();                              // ~0 ms
var clone3 = prototype.CloneWith(poolSize: 50);              // klonuj z modyfikacją

sw.Stop();
Console.WriteLine($"\n1 + 3 egzemplarze w: {sw.ElapsedMilliseconds} ms (≈ 1 × 500 ms)");
Console.WriteLine($"prototype: {prototype}");
Console.WriteLine($"clone1:    {clone1}");
Console.WriteLine($"clone3:    {clone3}");
Console.WriteLine();

// ─────────────────────────────────────────────────────────────────────────────
// Weryfikacja niezależności klonu
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("─── Weryfikacja: klon jest niezależny od oryginału ───");
Console.WriteLine($"Porównanie AllowedIps (lista):");
Console.WriteLine($"  prototype.AllowedIps == clone1.AllowedIps (referencja): {ReferenceEquals(prototype.AllowedIps, clone1.AllowedIps)}");
Console.WriteLine($"  (false = głęboka kopia — niezależność)");
