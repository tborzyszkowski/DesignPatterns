using Cqrs.Biblioteka;
using Xunit;

namespace Cqrs.Biblioteka.Tests;

// ============================================================
// Testy domeny — Ksiazka (Aggregate)
// ============================================================

public class KsiazkaAggregateTests
{
    private static Ksiazka UtworzKsiazke(string tytul = "Testowa Książka")
        => Ksiazka.Stworz(Guid.NewGuid(), tytul, "Testowy Autor", "978-00-00-00-0", 2020);

    [Fact]
    public void Stworz_Poprawne_Dane_TworzyKsiazke()
    {
        var id = Guid.NewGuid();
        var k = Ksiazka.Stworz(id, "Wzorce projektowe", "GoF", "978-0-20-16-3", 1994);
        Assert.Equal(id, k.Id);
        Assert.Equal("Wzorce projektowe", k.Tytul);
        Assert.True(k.CzyDostepna);
        Assert.Empty(k.Wypozyczenia);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Stworz_PustyTytul_RzucaArgumentException(string tytul)
    {
        Assert.Throws<ArgumentException>(() =>
            Ksiazka.Stworz(Guid.NewGuid(), tytul, "Autor", "isbn", 2020));
    }

    [Fact]
    public void Stworz_NieprawidlowyRok_RzucaArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            Ksiazka.Stworz(Guid.NewGuid(), "Tytuł", "Autor", "isbn", 1300));
    }

    [Fact]
    public void Wypozycz_DostepnaKsiazka_DodajeWypozyczenie()
    {
        var k = UtworzKsiazke();
        var uid = Guid.NewGuid();
        k.Wypozycz(uid, "Jan Kowalski", DateTime.UtcNow);
        Assert.False(k.CzyDostepna);
        Assert.Single(k.Wypozyczenia);
        Assert.Equal(StatusWypozyczenia.Aktywne, k.Wypozyczenia[0].Status);
    }

    [Fact]
    public void Wypozycz_WypozyczonaKsiazka_RzucaInvalidOperationException()
    {
        var k = UtworzKsiazke();
        k.Wypozycz(Guid.NewGuid(), "Jan", DateTime.UtcNow);
        var ex = Assert.Throws<InvalidOperationException>(() =>
            k.Wypozycz(Guid.NewGuid(), "Anna", DateTime.UtcNow));
        Assert.Contains("aktualnie wypożyczona", ex.Message);
    }

    [Fact]
    public void Zwroc_AktywneWypozyczenie_ZmieniaStatus()
    {
        var k = UtworzKsiazke();
        var uid = Guid.NewGuid();
        k.Wypozycz(uid, "Jan", DateTime.UtcNow);
        k.Zwroc(uid, DateTime.UtcNow.AddDays(7));
        Assert.True(k.CzyDostepna);
        Assert.Equal(StatusWypozyczenia.Zwrocone, k.Wypozyczenia[0].Status);
    }

    [Fact]
    public void Zwroc_BrakAktywnegoWypozyczenia_RzucaException()
    {
        var k = UtworzKsiazke();
        var uid = Guid.NewGuid();
        Assert.Throws<InvalidOperationException>(() =>
            k.Zwroc(uid, DateTime.UtcNow));
    }

    [Fact]
    public void Zwroc_PrzezInnegoUzytkownika_RzucaException()
    {
        var k = UtworzKsiazke();
        var uid1 = Guid.NewGuid();
        var uid2 = Guid.NewGuid();
        k.Wypozycz(uid1, "Jan", DateTime.UtcNow);
        Assert.Throws<InvalidOperationException>(() =>
            k.Zwroc(uid2, DateTime.UtcNow));
    }

    [Fact]
    public void Wycofaj_DostepnaKsiazka_DeaktywujeJa()
    {
        var k = UtworzKsiazke();
        k.Wycofaj();
        Assert.False(k.CzyDostepna);
        Assert.False(k.Aktywna);  // sprawdzenie że pole jest faktycznie ustawione
    }

    [Fact]
    public void Wycofaj_WypozyczonaKsiazka_RzucaException()
    {
        var k = UtworzKsiazke();
        k.Wypozycz(Guid.NewGuid(), "Jan", DateTime.UtcNow);
        Assert.Throws<InvalidOperationException>(() => k.Wycofaj());
    }

    [Fact]
    public void WielokrotneWypozyczenia_PoKazdymZwrocie_KsiazkaJestDostepna()
    {
        var k = UtworzKsiazke();
        var uid1 = Guid.NewGuid();
        var uid2 = Guid.NewGuid();

        k.Wypozycz(uid1, "Jan", DateTime.UtcNow);
        k.Zwroc(uid1, DateTime.UtcNow.AddDays(3));
        k.Wypozycz(uid2, "Anna", DateTime.UtcNow.AddDays(4));
        k.Zwroc(uid2, DateTime.UtcNow.AddDays(10));

        Assert.True(k.CzyDostepna);
        Assert.Equal(2, k.Wypozyczenia.Count);
        Assert.All(k.Wypozyczenia, w => Assert.Equal(StatusWypozyczenia.Zwrocone, w.Status));
    }
}

// ============================================================
// Testy Command Handlerów
// ============================================================

public class CommandHandlerTests
{
    private static (InMemoryKsiazkaWriteRepository repo, DodajKsiazkeHandler handler) SetupDodaj()
    {
        var repo = new InMemoryKsiazkaWriteRepository();
        return (repo, new DodajKsiazkeHandler(repo));
    }

    [Fact]
    public async Task DodajKsiazke_NowaDane_ZapisujePomyslnie()
    {
        var (repo, handler) = SetupDodaj();
        var id = Guid.NewGuid();
        await handler.HandleAsync(new DodajKsiazkeCommand(id, "Tytuł", "Autor", "isbn", 2020));
        var k = await repo.PobierzAsync(id);
        Assert.NotNull(k);
        Assert.Equal("Tytuł", k.Tytul);
    }

    [Fact]
    public async Task DodajKsiazke_IstniejaceId_RzucaException()
    {
        var (repo, handler) = SetupDodaj();
        var id = Guid.NewGuid();
        await handler.HandleAsync(new DodajKsiazkeCommand(id, "Tytuł", "Autor", "isbn", 2020));
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.HandleAsync(new DodajKsiazkeCommand(id, "Inny", "Autor2", "isbn2", 2021)));
    }

    [Fact]
    public async Task WypozyczKsiazke_DostepnaKsiazka_UdajenSie()
    {
        var repo = new InMemoryKsiazkaWriteRepository();
        var dodajH = new DodajKsiazkeHandler(repo);
        var wypozyczH = new WypozyczKsiazkeHandler(repo);
        var id = Guid.NewGuid();
        var uid = Guid.NewGuid();

        await dodajH.HandleAsync(new DodajKsiazkeCommand(id, "Tytuł", "Autor", "isbn", 2020));
        await wypozyczH.HandleAsync(new WypozyczKsiazkeCommand(id, uid, "Jan"));

        var k = await repo.PobierzAsync(id);
        Assert.NotNull(k);
        Assert.False(k.CzyDostepna);
    }

    [Fact]
    public async Task WypozyczKsiazke_NieIstniejacaKsiazka_RzucaException()
    {
        var repo = new InMemoryKsiazkaWriteRepository();
        var handler = new WypozyczKsiazkeHandler(repo);
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.HandleAsync(new WypozyczKsiazkeCommand(Guid.NewGuid(), Guid.NewGuid(), "Jan")));
    }

    [Fact]
    public async Task ZwrocKsiazke_AktywneWypozyczenie_UdajeSie()
    {
        var repo = new InMemoryKsiazkaWriteRepository();
        var dodajH   = new DodajKsiazkeHandler(repo);
        var wypozyczH = new WypozyczKsiazkeHandler(repo);
        var zwrocH   = new ZwrocKsiazkeHandler(repo);
        var id = Guid.NewGuid();
        var uid = Guid.NewGuid();

        await dodajH.HandleAsync(new DodajKsiazkeCommand(id, "Tytuł", "Autor", "isbn", 2020));
        await wypozyczH.HandleAsync(new WypozyczKsiazkeCommand(id, uid, "Jan"));
        await zwrocH.HandleAsync(new ZwrocKsiazkeCommand(id, uid));

        var k = await repo.PobierzAsync(id);
        Assert.NotNull(k);
        Assert.True(k.CzyDostepna);
    }
}

// ============================================================
// Testy Query Handlerów
// ============================================================

public class QueryHandlerTests
{
    private async Task<InMemoryKsiazkaWriteRepository> SetupRepoAsync()
    {
        var repo = new InMemoryKsiazkaWriteRepository();
        var dodajH = new DodajKsiazkeHandler(repo);

        await dodajH.HandleAsync(new DodajKsiazkeCommand(
            Guid.Parse("11111111-0000-0000-0000-000000000000"), "Ksiazka A", "Autor 1", "isbn1", 2001));
        await dodajH.HandleAsync(new DodajKsiazkeCommand(
            Guid.Parse("22222222-0000-0000-0000-000000000000"), "Ksiazka B", "Autor 2", "isbn2", 2002));
        await dodajH.HandleAsync(new DodajKsiazkeCommand(
            Guid.Parse("33333333-0000-0000-0000-000000000000"), "Ksiazka C", "Autor 3", "isbn3", 2003));
        return repo;
    }

    [Fact]
    public async Task PobierzDostepneKsiazki_BezWypozyczen_ZwracaWszystkie()
    {
        var repo = await SetupRepoAsync();
        var handler = new PobierzDostepneKsiazkiHandler(repo);
        var wynik = await handler.HandleAsync(new PobierzDostepneKsiazki());
        Assert.Equal(3, wynik.Count);
        Assert.All(wynik, k => Assert.True(k.DostepnaDoWypozyczenia));
    }

    [Fact]
    public async Task PobierzDostepneKsiazki_JednaWypozyczona_ZwracaDwie()
    {
        var repo = await SetupRepoAsync();
        var k1Id = Guid.Parse("11111111-0000-0000-0000-000000000000");
        var wypozyczH = new WypozyczKsiazkeHandler(repo);
        await wypozyczH.HandleAsync(new WypozyczKsiazkeCommand(k1Id, Guid.NewGuid(), "Jan"));

        var handler = new PobierzDostepneKsiazkiHandler(repo);
        var wynik = await handler.HandleAsync(new PobierzDostepneKsiazki());
        Assert.Equal(2, wynik.Count);
    }

    [Fact]
    public async Task PobierzWypozyczeniaUzytkownika_BezWypozyczen_ZwracaPusto()
    {
        var repo = await SetupRepoAsync();
        var handler = new PobierzWypozyczeniaUzytkownikaHandler(repo);
        var wynik = await handler.HandleAsync(
            new PobierzWypozyczeniaUzytkownikaQuery(Guid.NewGuid()));
        Assert.Empty(wynik);
    }

    [Fact]
    public async Task PobierzWypozyczeniaUzytkownika_MaWypozyczenia_ZwracaJe()
    {
        var repo = await SetupRepoAsync();
        var uid = Guid.NewGuid();
        var k1 = Guid.Parse("11111111-0000-0000-0000-000000000000");
        var k2 = Guid.Parse("22222222-0000-0000-0000-000000000000");

        var wypozyczH = new WypozyczKsiazkeHandler(repo);
        await wypozyczH.HandleAsync(new WypozyczKsiazkeCommand(k1, uid, "Jan"));
        await wypozyczH.HandleAsync(new WypozyczKsiazkeCommand(k2, uid, "Jan"));

        var handler = new PobierzWypozyczeniaUzytkownikaHandler(repo);
        var wynik = await handler.HandleAsync(new PobierzWypozyczeniaUzytkownikaQuery(uid));
        Assert.Equal(2, wynik.Count);
        Assert.All(wynik, w => Assert.Equal("Aktywne", w.Status));
    }

    [Fact]
    public async Task PobierzHistorieKsiazki_NieIstniejaca_ZwracaNull()
    {
        var repo = await SetupRepoAsync();
        var handler = new PobierzHistorieKsiazkiHandler(repo);
        var wynik = await handler.HandleAsync(new PobierzHistorieKsiazkiQuery(Guid.NewGuid()));
        Assert.Null(wynik);
    }

    [Fact]
    public async Task PobierzHistorieKsiazki_PoWypozyczeniuIZwrocie_MaWpis()
    {
        var repo = await SetupRepoAsync();
        var uid = Guid.NewGuid();
        var k1 = Guid.Parse("11111111-0000-0000-0000-000000000000");

        var wypozyczH = new WypozyczKsiazkeHandler(repo);
        var zwrocH    = new ZwrocKsiazkeHandler(repo);
        await wypozyczH.HandleAsync(new WypozyczKsiazkeCommand(k1, uid, "Jan"));
        await zwrocH.HandleAsync(new ZwrocKsiazkeCommand(k1, uid));

        var handler = new PobierzHistorieKsiazkiHandler(repo);
        var wynik = await handler.HandleAsync(new PobierzHistorieKsiazkiQuery(k1));

        Assert.NotNull(wynik);
        Assert.Single(wynik.Historia);
        Assert.Equal("Zwrocone", wynik.Historia[0].Status);
        Assert.NotNull(wynik.Historia[0].DataZwrotu);
    }

    [Fact]
    public async Task PobierzWszystkieKsiazki_ZawszePobieraWszystkie()
    {
        var repo = await SetupRepoAsync();
        var handler = new PobierzWszystkieKsiazkiHandler(repo);

        // Wycofaj jedną
        var k1 = repo.All.First();
        k1.Wycofaj();

        var wynik = await handler.HandleAsync(new PobierzWszystkieKsiazki());
        // PobierzWszystkie zwraca wszystkie, nawet wycofane
        Assert.Equal(3, wynik.Count);
    }
}
