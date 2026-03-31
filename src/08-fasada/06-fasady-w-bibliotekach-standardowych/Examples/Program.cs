using System.Net;
using System.Net.Http;
using System.Text;

var httpClient = new HttpClient(new FakeHttpMessageHandler())
{
    BaseAddress = new Uri("https://api.local")
};

var facade = new ApiFacade(httpClient);
var user = await facade.GetUserSummaryAsync("42");
Console.WriteLine(user);

internal sealed class ApiFacade(HttpClient client)
{
    public async Task<string> GetUserSummaryAsync(string userId)
    {
        using var response = await client.GetAsync($"/users/{userId}");
        response.EnsureSuccessStatusCode();
        var payload = await response.Content.ReadAsStringAsync();
        return $"UserSummary[{userId}] => {payload}";
    }
}

internal sealed class FakeHttpMessageHandler : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _ = cancellationToken;
        var body = "{\"id\":\"42\",\"name\":\"Ada\",\"tier\":\"Gold\"}";

        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(body, Encoding.UTF8, "application/json"),
            RequestMessage = request
        });
    }
}
