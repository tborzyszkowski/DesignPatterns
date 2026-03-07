namespace TypyImplementacji.StepBuilder;

// ============================================================
// STEP BUILDER — kompilator wymusza kolejność kroków
// Przykład: budowanie zapytania SQL
// ============================================================

// ----- Produkt ---------------------------------------------------

public sealed class SqlQuery
{
    public string   Table       { get; }
    public string[] Columns     { get; }
    public string?  WhereClause { get; }
    public string?  OrderBy     { get; }
    public int?     Limit       { get; }

    internal SqlQuery(string table, string[] columns,
                      string? where, string? orderBy, int? limit)
    {
        Table       = table;
        Columns     = columns;
        WhereClause = where;
        OrderBy     = orderBy;
        Limit       = limit;
    }

    public string ToSql()
    {
        var cols = Columns.Length == 0 ? "*" : string.Join(", ", Columns);
        var sql  = $"SELECT {cols} FROM {Table}";
        if (!string.IsNullOrEmpty(WhereClause)) sql += $" WHERE {WhereClause}";
        if (!string.IsNullOrEmpty(OrderBy))     sql += $" ORDER BY {OrderBy}";
        if (Limit.HasValue)                     sql += $" LIMIT {Limit}";
        return sql;
    }
}

// ----- Interfejsy kroków (Step interfaces) ----------------------

/// <summary>
/// Krok 1: wybór tabeli — jedyny publiczny punkt wejścia.
/// </summary>
public interface IFromStep
{
    ISelectStep From(string table);
}

/// <summary>
/// Krok 2: wybór kolumn — wymagany przed WHERE lub Build.
/// </summary>
public interface ISelectStep
{
    IWhereStep Select(params string[] columns);
    IWhereStep SelectAll();
}

/// <summary>
/// Krok 3: opcjonalny filtr WHERE, lub od razu Build.
/// </summary>
public interface IWhereStep
{
    IBuildStep Where(string condition);
    SqlQuery   Build();
}

/// <summary>
/// Krok 4: opcjonalne ORDER BY, LIMIT i finalne Build.
/// </summary>
public interface IBuildStep
{
    IBuildStep OrderBy(string column, bool descending = false);
    IBuildStep Limit(int n);
    SqlQuery   Build();
}

// ----- Konkrety (wszystko w jednej klasie, wiele interfejsów) ---

/// <summary>
/// Jeden builder implementuje wszystkie interfejsy kroków.
/// Typ zwracany przez każdą metodę OGRANICZA dostępne kolejne kroki.
/// Kompilator pilnuje kolejności — nie możemy wywołać Build() bez From().
/// </summary>
public sealed class SqlQueryBuilder : IFromStep, ISelectStep, IWhereStep, IBuildStep
{
    private string   _table   = string.Empty;
    private string[] _columns = [];
    private string?  _where;
    private string?  _orderBy;
    private int?     _limit;

    // Prywatny konstruktor — jedynym wejściem jest statyczna metoda Query()
    private SqlQueryBuilder() { }

    /// <summary>Punkt wejścia — zwraca IFromStep, więc pierwszy krok to ZAWSZE From().</summary>
    public static IFromStep Query() => new SqlQueryBuilder();

    // Implementacja IFromStep
    public ISelectStep From(string table) { _table = table; return this; }

    // Implementacja ISelectStep
    public IWhereStep Select(params string[] columns) { _columns = columns; return this; }
    public IWhereStep SelectAll()                      { _columns = [];      return this; }

    // Implementacja IWhereStep
    public IBuildStep Where(string condition) { _where = condition; return this; }
    public SqlQuery   Build()                 => BuildQuery();

    // Implementacja IBuildStep
    public IBuildStep OrderBy(string column, bool descending = false)
    {
        _orderBy = descending ? $"{column} DESC" : column;
        return this;
    }
    public IBuildStep Limit(int n) { _limit = n; return this; }
    SqlQuery IBuildStep.Build()    => BuildQuery();

    private SqlQuery BuildQuery()
    {
        if (string.IsNullOrWhiteSpace(_table))
            throw new InvalidOperationException("Tabela jest wymagana");
        return new SqlQuery(_table, _columns, _where, _orderBy, _limit);
    }
}
