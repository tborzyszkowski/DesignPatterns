using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

public class ApiFacadeTests
{
    private static ApiFacade BuildFacade(string responseBody)
    {
        var handler = new StaticHttpMessageHandler(responseBody);
        var client = new HttpClient(handler) { BaseAddress = new Uri("https://api.local") };
        return new ApiFacade(client);
    }

    [Fact]
    public async Task GetUserSummaryAsync_ReturnsUserSummaryString()
    {
        var facade = BuildFacade("{\"id\":\"42\",\"name\":\"Ada\"}");

        var result = await facade.GetUserSummaryAsync("42");

        Assert.Contains("UserSummary", result);
        Assert.Contains("42", result);
    }

    [Fact]
    public async Task GetUserSummaryAsync_IncludesPayloadInResult()
    {
        var facade = BuildFacade("{\"tier\":\"Gold\"}");

        var result = await facade.GetUserSummaryAsync("7");

        Assert.Contains("Gold", result);
    }

    private sealed class StaticHttpMessageHandler(string body) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _ = cancellationToken;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
                RequestMessage = request
            });
        }
    }
}
