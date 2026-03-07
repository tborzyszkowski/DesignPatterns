using PlytkieGleboke.Documents;

var original = new Document(
    "Umowa sprzedaży",
    new Person("Jan Kowalski", "jan@firma.pl"),
    ["prawny", "2024"],
    ["Strony umowy...", "Przedmiot umowy..."]
);

// ─────────────────────────────────────────────────────────────────────────────
// 1. Płytka kopia — pułapka ze współdzielonymi referencjami
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("=== 1. Płytka kopia (ShallowClone) ===\n");

var shallow = original.ShallowClone();

Console.WriteLine($"Przed modyfikacją:");
Console.WriteLine($"  oryginał: {original}");
Console.WriteLine($"  klon:     {shallow}");
Console.WriteLine($"  ReferenceEquals(Author): {ReferenceEquals(original.Author, shallow.Author)}");
Console.WriteLine($"  ReferenceEquals(Tags):   {ReferenceEquals(original.Tags,   shallow.Tags)}");

// Modyfikacja pola wartościowego (string — immutable, bezpieczne)
shallow.Title = "KOPIA Umowy";
Console.WriteLine($"\nPo shallow.Title = 'KOPIA Umowy':");
Console.WriteLine($"  oryginał.Title: '{original.Title}' (bez zmian ✅)");
Console.WriteLine($"  klon.Title:     '{shallow.Title}'");

// ⚠️ Modyfikacja zagnieżdżonego obiektu — NIEBEZPIECZNE
shallow.Author.Name = "Anna Nowak";
Console.WriteLine($"\nPo shallow.Author.Name = 'Anna Nowak':");
Console.WriteLine($"  oryginał.Author: {original.Author} ← ⚠️ ZMIENIONY przez modyfikację klonu!");
Console.WriteLine($"  klon.Author:     {shallow.Author}");

// ⚠️ Modyfikacja listy — NIEBEZPIECZNE
shallow.Tags.Add("pilne");
Console.WriteLine($"\nPo shallow.Tags.Add('pilne'):");
Console.WriteLine($"  oryginał.Tags: [{string.Join(", ", original.Tags)}] ← ⚠️ 'pilne' pojawiło się w oryginale!");
Console.WriteLine($"  klon.Tags:     [{string.Join(", ", shallow.Tags)}]");

// ─────────────────────────────────────────────────────────────────────────────
// 2. Głęboka kopia — konstruktor kopiujący
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("\n=== 2. Głęboka kopia — konstruktor kopiujący ===\n");

var fresh = new Document(
    "Umowa sprzedaży",
    new Person("Jan Kowalski", "jan@firma.pl"),
    ["prawny", "2024"],
    ["Strony umowy...", "Przedmiot umowy..."]
);

var deep = fresh.DeepCloneManual();

Console.WriteLine($"ReferenceEquals(Author): {ReferenceEquals(fresh.Author, deep.Author)} (false = niezależne ✅)");
Console.WriteLine($"ReferenceEquals(Tags):   {ReferenceEquals(fresh.Tags,   deep.Tags)}   (false ✅)");

deep.Author.Name = "Anna Nowak";
deep.Tags.Add("pilne");

Console.WriteLine($"\nPo modyfikacji klonu:");
Console.WriteLine($"  oryginał: {fresh}");
Console.WriteLine($"  klon:     {deep}");
Console.WriteLine($"  oryginał nienaruszony ✅");

// ─────────────────────────────────────────────────────────────────────────────
// 3. Głęboka kopia — JSON serialization
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("\n=== 3. Głęboka kopia — JSON serialization ===\n");

var jsonDoc = fresh.DeepCloneJson();

jsonDoc.Title = "Kopia JSON";
jsonDoc.Author.Email = "anna@nowa.pl";
jsonDoc.Tags.Clear();

Console.WriteLine($"oryginał po klonowaniu JSON: {fresh}");
Console.WriteLine($"klon JSON:                  {jsonDoc}");
Console.WriteLine($"oryginał nienaruszony ✅");
