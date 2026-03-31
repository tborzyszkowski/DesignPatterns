using KiedyStosowac;
using Xunit;

namespace Examples.Tests;

public class EnemyCloneTests
{
    [Fact]
    public void Goblin_Clone_CopiesProperties()
    {
        var goblin = new Goblin();

        var clone = (Goblin)goblin.Clone();

        Assert.Equal("Goblin", clone.Name);
        Assert.Equal(30, clone.MaxHp);
        Assert.Equal(5, clone.AttackPower);
    }

    [Fact]
    public void Goblin_Clone_DeepCopiesAbilities()
    {
        var goblin = new Goblin();

        var clone = goblin.Clone();

        Assert.False(ReferenceEquals(goblin.Abilities, clone.Abilities));
        Assert.Equal(goblin.Abilities, clone.Abilities);
    }

    [Fact]
    public void Orc_Clone_CopiesProperties()
    {
        var orc = new Orc();

        var clone = (Orc)orc.Clone();

        Assert.Equal("Orc", clone.Name);
        Assert.Equal(120, clone.MaxHp);
        Assert.Equal(20, clone.AttackPower);
    }

    [Fact]
    public void Dragon_Clone_IncludesFireDamage()
    {
        var dragon = new Dragon();

        var clone = (Dragon)dragon.Clone();

        Assert.Equal(40, clone.FireDamage);
        Assert.Equal(500, clone.MaxHp);
    }

    [Fact]
    public void Spawn_SetsPosition()
    {
        var goblin = new Goblin();

        var spawned = goblin.Spawn(42, 99);

        Assert.Equal(42, spawned.X);
        Assert.Equal(99, spawned.Y);
    }

    [Fact]
    public void Spawn_DoesNotAffectOriginal()
    {
        var goblin = new Goblin();

        goblin.Spawn(42, 99);

        Assert.Equal(0, goblin.X);
        Assert.Equal(0, goblin.Y);
    }
}

public class EnemyRegistryTests
{
    [Fact]
    public void Spawn_ReturnsClone()
    {
        var registry = new EnemyRegistry();
        registry.Register("goblin", new Goblin());

        var spawned = registry.Spawn("goblin", 10, 20);

        Assert.Equal("Goblin", spawned.Name);
        Assert.Equal(10, spawned.X);
        Assert.Equal(20, spawned.Y);
    }

    [Fact]
    public void Spawn_ReturnsIndependentInstances()
    {
        var registry = new EnemyRegistry();
        registry.Register("orc", new Orc());

        var a = registry.Spawn("orc", 1, 1);
        var b = registry.Spawn("orc", 2, 2);

        Assert.False(ReferenceEquals(a, b));
        Assert.False(ReferenceEquals(a.Abilities, b.Abilities));
    }

    [Fact]
    public void Spawn_UnknownKey_Throws()
    {
        var registry = new EnemyRegistry();

        Assert.Throws<KeyNotFoundException>(() => registry.Spawn("unknown", 0, 0));
    }

    [Fact]
    public void Keys_ReturnsRegisteredKeys()
    {
        var registry = new EnemyRegistry();
        registry.Register("goblin", new Goblin());
        registry.Register("dragon", new Dragon());

        Assert.Contains("goblin", registry.Keys);
        Assert.Contains("dragon", registry.Keys);
    }

    [Fact]
    public void Unregister_RemovesKey()
    {
        var registry = new EnemyRegistry();
        registry.Register("goblin", new Goblin());

        registry.Unregister("goblin");

        Assert.DoesNotContain("goblin", registry.Keys);
    }
}

public class CounterexampleTests
{
    [Fact]
    public void Point_WithExpression_CreatesNewInstance()
    {
        var p1 = new Point(3.0, 4.0);

        var p2 = p1 with { X = 10.0 };

        Assert.Equal(3.0, p1.X);
        Assert.Equal(10.0, p2.X);
        Assert.Equal(4.0, p2.Y);
    }

    [Fact]
    public void OrderFactory_CreatesUniqueIds()
    {
        var o1 = OrderFactory.Create("C1", [("SKU", 1, 10m)]);
        var o2 = OrderFactory.Create("C1", [("SKU", 1, 10m)]);

        Assert.NotEqual(o1.OrderId, o2.OrderId);
    }

    [Fact]
    public void ReportRow_Total_CalculatesCorrectly()
    {
        var row = new ReportRow("Widget", 5, 9.99m);

        Assert.Equal(49.95m, row.Total);
    }

    [Fact]
    public void ReportRow_WithExpression_CreatesModifiedCopy()
    {
        var row = new ReportRow("Widget", 5, 9.99m);

        var adjusted = row with { Quantity = 10 };

        Assert.Equal(5, row.Quantity);
        Assert.Equal(10, adjusted.Quantity);
        Assert.Equal(99.90m, adjusted.Total);
    }
}
