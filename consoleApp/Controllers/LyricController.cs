using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sureal.Auth.Common.HttpClient;
using Sureal.Auth.Common.JSonConverter;

[Route("api/[controller]")]
public class LyricController : Controller
{
    private readonly IHttpClient httpClient;
    private readonly IJsonConverter jsonConverter;
    private readonly Settings settings;

    public LyricController(IHttpClient httpClient, IOptions<Settings> optionSettings, IJsonConverter jsonConverter )
    {
        this.httpClient = httpClient;
        this.jsonConverter = jsonConverter;
        this.settings = optionSettings.Value;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery]LyricRequest request)
    {
        var url = $"{settings.Lyrics.Endpoint}?apikey={settings.Lyrics.ApiKey}&territory=US&lrckey={settings.Lyrics.lrckey}&reqtype=default&trackid=artistname:{request.ArtistName.Replace(" ", "+")},trackname:{request.SongName.Replace(" ", "+")}&format=lrconly,clean&output={settings.Lyrics.Output}";
        
        var result = await httpClient.GetAsync(url);        
        var lyricFindResponse = jsonConverter.DeserializeObject<LyricFindResponse>(await result.Content.ReadAsStringAsync());
        
        return base.Ok(lyricFindResponse) ;
    }
}