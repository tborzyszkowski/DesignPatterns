using Xunit;

public class MediaFacadeTests
{
    [Fact]
    public void SimpleMediaFacade_Play_ReturnsExpectedUrl()
    {
        var facade = new SimpleMediaFacade(new CatalogService(), new PlayerService());

        var result = facade.Play("movie-1");

        Assert.Contains("movie-1", result);
        Assert.Contains("Odtwarzanie", result);
    }

    [Fact]
    public void SecureMediaFacade_Admin_CanPlay()
    {
        var facade = new SecureMediaFacade(
            new CatalogService(),
            new PlayerService(),
            new AuthorizationService());

        var result = facade.PlayAs("admin", "movie-2");

        Assert.Contains("Odtwarzanie", result);
        Assert.Contains("movie-2", result);
    }

    [Fact]
    public void SecureMediaFacade_UnauthorizedRole_ReturnsDenied()
    {
        var facade = new SecureMediaFacade(
            new CatalogService(),
            new PlayerService(),
            new AuthorizationService());

        var result = facade.PlayAs("guest", "movie-2");

        Assert.Contains("uprawnie", result);
    }

    [Fact]
    public void AuthorizationService_TeacherRole_CanPlay()
    {
        var auth = new AuthorizationService();

        Assert.True(auth.CanPlay("teacher"));
    }

    [Fact]
    public void AuthorizationService_GuestRole_CannotPlay()
    {
        var auth = new AuthorizationService();

        Assert.False(auth.CanPlay("guest"));
    }

    [Fact]
    public async Task AsyncMediaFacade_PlayAsync_ReturnsExpectedUrl()
    {
        var facade = new AsyncMediaFacade(new CatalogService(), new PlayerService());

        var result = await facade.PlayAsync("movie-3");

        Assert.Contains("movie-3", result);
        Assert.Contains("Odtwarzanie", result);
    }
}
