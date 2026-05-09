// =============================================================
// ADO.NET abstractions + provider bazodanowy — Most w .NET
// =============================================================
// Abstrakcja:  DbConnection, DbCommand, DbDataReader (klasy abstrakcyjne)
// Implementory: SqliteConnection (tu), SqlConnection, NpgsqlConnection (inne pakiety)
// =============================================================
// Uruchamia SQLite in-memory — nie wymaga żadnego serwera bazy danych.
// Ten sam kod (GetProductNamesAsync, ProductRepository) działa bez zmian
// z SQL Server i PostgreSQL — wystarczy podmienić DbConnection w kompozycji.
// =============================================================

using System.Data.Common;
using Microsoft.Data.Sqlite;

// ---- Kompozycja: wybieramy Concrete Implementor ---------------
// W produkcji: new SqlConnection(...) lub new NpgsqlConnection(...)
await using DbConnection connection = new SqliteConnection("Data Source=:memory:");
await connection.OpenAsync();

// Przygotowanie schematu (specyficzne dla SQLite in-memory)
await using (DbCommand setup = connection.CreateCommand())
{
    setup.CommandText = """
        CREATE TABLE Products (
            Id    INTEGER PRIMARY KEY AUTOINCREMENT,
            Name  TEXT    NOT NULL,
            Price REAL    NOT NULL
        );
        INSERT INTO Products (Name, Price) VALUES ('Widget', 9.99);
        INSERT INTO Products (Name, Price) VALUES ('Gadget', 24.99);
        INSERT INTO Products (Name, Price) VALUES ('Thing',  4.49);
        """;
    await setup.ExecuteNonQueryAsync();
}

// ---- Funkcja niezależna od providera --------------------------
var names = await GetProductNamesAsync(connection);
Console.WriteLine("Produkty (przez DbConnection):");
foreach (var n in names)
    Console.WriteLine($"  - {n}");

// ---- Repository niezależne od providera -----------------------
var repo = new ProductRepository(connection);
await repo.AddProductAsync("Sprocket", 14.99m);
Console.WriteLine("\nPo dodaniu Sprocket:");
foreach (var n in await GetProductNamesAsync(connection))
    Console.WriteLine($"  - {n}");

// =============================================================
// Funkcja korzystająca TYLKO z abstrakcji DbConnection/DbCommand
// =============================================================
static async Task<List<string>> GetProductNamesAsync(DbConnection connection)
{
    await using DbCommand cmd = connection.CreateCommand();
    cmd.CommandText = "SELECT Name FROM Products ORDER BY Name";

    var results = new List<string>();
    await using DbDataReader reader = await cmd.ExecuteReaderAsync();
    while (await reader.ReadAsync())
        results.Add(reader.GetString(0));

    return results;
}

// =============================================================
// Repository — zależy TYLKO od DbConnection (abstrakcja)
// =============================================================
class ProductRepository(DbConnection connection)
{
    public async Task<int> AddProductAsync(string name, decimal price)
    {
        await using DbCommand cmd = connection.CreateCommand();
        cmd.CommandText = "INSERT INTO Products (Name, Price) VALUES (@name, @price)";

        DbParameter pName = cmd.CreateParameter();
        pName.ParameterName = "@name";
        pName.Value = name;
        cmd.Parameters.Add(pName);

        DbParameter pPrice = cmd.CreateParameter();
        pPrice.ParameterName = "@price";
        pPrice.Value = (double)price;
        cmd.Parameters.Add(pPrice);

        return await cmd.ExecuteNonQueryAsync();
    }
}
