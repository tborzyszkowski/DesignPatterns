Console.WriteLine("=== Simple ===");
var simple = new SimpleMediaFacade(new CatalogService(), new PlayerService());
Console.WriteLine(simple.Play("movie-1"));

Console.WriteLine("=== Secure ===");
var secure = new SecureMediaFacade(new CatalogService(), new PlayerService(), new AuthorizationService());
Console.WriteLine(secure.PlayAs("admin", "movie-2"));

Console.WriteLine("=== Async ===");
var asyncFacade = new AsyncMediaFacade(new CatalogService(), new PlayerService());
Console.WriteLine(await asyncFacade.PlayAsync("movie-3"));

internal sealed class SimpleMediaFacade(CatalogService catalog, PlayerService player)
{
    public string Play(string mediaId) => player.Play(catalog.GetUrl(mediaId));
}

internal sealed class SecureMediaFacade(CatalogService catalog, PlayerService player, AuthorizationService auth)
{
    public string PlayAs(string userRole, string mediaId)
    {
        if (!auth.CanPlay(userRole))
        {
            return "Brak uprawnień.";
        }

        return player.Play(catalog.GetUrl(mediaId));
    }
}

internal sealed class AsyncMediaFacade(CatalogService catalog, PlayerService player)
{
    public async Task<string> PlayAsync(string mediaId)
    {
        var url = await catalog.GetUrlAsync(mediaId);
        return await player.PlayAsync(url);
    }
}

internal sealed class CatalogService
{
    public string GetUrl(string mediaId) => $"https://media.local/{mediaId}.mp4";
    public Task<string> GetUrlAsync(string mediaId) => Task.FromResult(GetUrl(mediaId));
}

internal sealed class PlayerService
{
    public string Play(string url) => $"Odtwarzanie: {url}";
    public Task<string> PlayAsync(string url) => Task.FromResult(Play(url));
}

internal sealed class AuthorizationService
{
    public bool CanPlay(string role) => role is "admin" or "teacher";
}
