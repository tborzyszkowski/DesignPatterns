using System.Text.Json;
using System.Text.Json.Serialization;

namespace Problems;

// ─────────────────────────────────────────────────────────────────────────────
// PROBLEM: Serializacja tworzy nową instancję zamiast zwracać singleton
// ─────────────────────────────────────────────────────────────────────────────

/// <summary>
/// Singleton, który NIE chroni się przed serializacją.
/// Aby wywołać problem, konstruktor musi być publiczny (lub JSON + [JsonConstructor]).
/// Wtedy deserializacja tworzy NOWY obiekt, naruszając wzorzec Singleton.
///
/// DEMONSTRACJA PROBLEMU: nawet prosta serializacja/deserializacja klasy
/// posiadającej publiczny konstruktor tworzy nową instancję obiektu.
/// </summary>
public class UnprotectedConfig
{
    private static readonly UnprotectedConfig _instance = new UnprotectedConfig("singleton");

    // JsonSerializer wymaga publicznego konstruktora do deserializacji —
    // to właśnie powoduje problem: może tworzyć dodatkowe instancje przez JSON.
    [System.Text.Json.Serialization.JsonConstructor]
    public UnprotectedConfig() { }

    private UnprotectedConfig(string _origin) { }

    public static UnprotectedConfig Instance => _instance;

    public string Environment { get; set; } = "Production";
    public int MaxConnections { get; set; } = 10;
}

// ─────────────────────────────────────────────────────────────────────────────
// ROZWIĄZANIE: Własny JsonConverter przywracający singleton
// ─────────────────────────────────────────────────────────────────────────────

/// <summary>
/// Singleton chroniony przed deserializacją.
/// Własny JsonConverter zawsze zwraca istniejącą instancję.
/// </summary>
[JsonConverter(typeof(ProtectedConfigConverter))]
public sealed class ProtectedConfig
{
    private static readonly ProtectedConfig _instance = new ProtectedConfig();
    private ProtectedConfig() { }
    public static ProtectedConfig Instance => _instance;

    public string Environment { get; set; } = "Production";
    public int MaxConnections { get; set; } = 10;
}

/// <summary>
/// Konwerter JSON, który przy deserializacji zwraca istniejącą instancję singletona
/// zamiast tworzyć nowy obiekt.
/// </summary>
public class ProtectedConfigConverter : JsonConverter<ProtectedConfig>
{
    public override ProtectedConfig? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        // Parsujemy JSON do dokumentu, ale ignorujemy jego zawartość —
        // zawsze zwracamy istniejący singleton
        using var doc = JsonDocument.ParseValue(ref reader);
        // Opcjonalnie: zastosuj wartości z JSON do istniejącej instancji
        var instance = ProtectedConfig.Instance;
        if (doc.RootElement.TryGetProperty("Environment", out var env))
            instance.Environment = env.GetString() ?? instance.Environment;
        if (doc.RootElement.TryGetProperty("MaxConnections", out var max))
            instance.MaxConnections = max.GetInt32();
        return instance;
    }

    public override void Write(Utf8JsonWriter writer, ProtectedConfig value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("Environment", value.Environment);
        writer.WriteNumber("MaxConnections", value.MaxConnections);
        writer.WriteEndObject();
    }
}
