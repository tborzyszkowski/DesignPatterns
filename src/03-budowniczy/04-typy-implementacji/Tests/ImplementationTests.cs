using TypyImplementacji.StepBuilder;
using TypyImplementacji.ImmutableBuilder;
using Xunit;

namespace Examples.Tests;

public class SqlQueryBuilderTests
{
    [Fact]
    public void Build_SelectAll_GeneratesStarQuery()
    {
        var query = SqlQueryBuilder.Query()
            .From("employees")
            .SelectAll()
            .Build();

        Assert.Equal("SELECT * FROM employees", query.ToSql());
    }

    [Fact]
    public void Build_SelectColumns_ListsColumns()
    {
        var query = SqlQueryBuilder.Query()
            .From("orders")
            .Select("id", "total")
            .Build();

        Assert.Equal("SELECT id, total FROM orders", query.ToSql());
    }

    [Fact]
    public void Build_WithWhere_IncludesWhereClause()
    {
        var query = SqlQueryBuilder.Query()
            .From("products")
            .SelectAll()
            .Where("price > 100")
            .Build();

        Assert.Contains("WHERE price > 100", query.ToSql());
    }

    [Fact]
    public void Build_WithOrderBy_IncludesOrderByClause()
    {
        var query = SqlQueryBuilder.Query()
            .From("employees")
            .SelectAll()
            .Where("active = 1")
            .OrderBy("salary", descending: true)
            .Build();

        Assert.Contains("ORDER BY salary DESC", query.ToSql());
    }

    [Fact]
    public void Build_WithLimit_IncludesLimitClause()
    {
        var query = SqlQueryBuilder.Query()
            .From("logs")
            .SelectAll()
            .Where("level = 'ERROR'")
            .Limit(50)
            .Build();

        Assert.Contains("LIMIT 50", query.ToSql());
    }

    [Fact]
    public void Build_FullQuery_AllClauses()
    {
        var query = SqlQueryBuilder.Query()
            .From("employees")
            .Select("name", "salary")
            .Where("department = 'IT'")
            .OrderBy("salary", descending: true)
            .Limit(10)
            .Build();

        var sql = query.ToSql();
        Assert.Contains("SELECT name, salary", sql);
        Assert.Contains("FROM employees", sql);
        Assert.Contains("WHERE department = 'IT'", sql);
        Assert.Contains("ORDER BY salary DESC", sql);
        Assert.Contains("LIMIT 10", sql);
    }

    [Fact]
    public void SqlQuery_Properties_SetCorrectly()
    {
        var query = SqlQueryBuilder.Query()
            .From("users")
            .Select("id", "email")
            .Where("active = true")
            .OrderBy("id")
            .Limit(5)
            .Build();

        Assert.Equal("users", query.Table);
        Assert.Equal(new[] { "id", "email" }, query.Columns);
        Assert.Equal("active = true", query.WhereClause);
        Assert.Equal("id", query.OrderBy);
        Assert.Equal(5, query.Limit);
    }
}

public class PersonBuilderTests
{
    [Fact]
    public void Build_DefaultValues_CreatesValidPerson()
    {
        var person = new PersonBuilder().Build();

        Assert.Equal("Imię", person.FirstName);
        Assert.Equal("Nazwisko", person.LastName);
        Assert.Equal(0, person.Age);
    }

    [Fact]
    public void Build_WithAllFields_SetsCorrectly()
    {
        var person = new PersonBuilder()
            .WithFirstName("Katarzyna")
            .WithLastName("Wiśniewska")
            .WithAge(28)
            .WithEmail("kasia@firma.pl")
            .Build();

        Assert.Equal("Katarzyna", person.FirstName);
        Assert.Equal("Wiśniewska", person.LastName);
        Assert.Equal(28, person.Age);
        Assert.Equal("kasia@firma.pl", person.Email);
    }

    [Fact]
    public void Build_GeneratesUniqueId()
    {
        var p1 = new PersonBuilder().Build();
        var p2 = new PersonBuilder().Build();

        Assert.NotEqual(p1.Id, p2.Id);
    }

    [Fact]
    public void FullName_CombinesFirstAndLast()
    {
        var person = new PersonBuilder()
            .WithFirstName("Jan")
            .WithLastName("Nowak")
            .Build();

        Assert.Equal("Jan Nowak", person.FullName);
    }

    [Fact]
    public void Build_NegativeAge_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new PersonBuilder().WithAge(-5).Build());
    }

    [Fact]
    public void Build_AgeOver150_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new PersonBuilder().WithAge(200).Build());
    }

    [Fact]
    public void Build_InvalidEmail_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new PersonBuilder().WithEmail("nieprawidlowy").Build());
    }

    [Fact]
    public void Build_EmptyEmail_IsAllowed()
    {
        var person = new PersonBuilder().WithEmail("").Build();

        Assert.Equal("", person.Email);
    }
}

public class RecordWithTests
{
    [Fact]
    public void WithExpression_CreatesModifiedCopy()
    {
        var original = new Person(Guid.NewGuid(), "Anna", "Kowalska", 30, "anna@firma.pl");

        var older = original with { Age = 31 };

        Assert.Equal(30, original.Age);
        Assert.Equal(31, older.Age);
        Assert.Equal(original.FirstName, older.FirstName);
    }

    [Fact]
    public void WithExpression_ExactCopy_HasValueEquality()
    {
        var original = new Person(Guid.NewGuid(), "Anna", "Kowalska", 30, "anna@firma.pl");

        var copy = original with { };

        Assert.Equal(original, copy);
        Assert.False(ReferenceEquals(original, copy));
    }
}
