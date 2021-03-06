using Flurl;
using Flurl.Http;
using Tally.Bootswatch.Models;

namespace Tally.Bootswatch;

public class BootswatchClient
{
    private readonly string _baseUrl;
    
    public const string DefaultBaseUrl = "https://bootswatch.com/api";

    public BootswatchClient(string baseUrl = DefaultBaseUrl) => _baseUrl = baseUrl;

    public async Task<ThemeData> GetThemesAsync(int version, CancellationToken cancellationToken = default)
    {
        return await _baseUrl.AppendPathSegment($"{version}.json")
            .GetJsonAsync<ThemeData>(cancellationToken)
            .ConfigureAwait(false);
    }
}