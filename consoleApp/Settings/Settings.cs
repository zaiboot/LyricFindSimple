public class Settings
{
    public LyricsSettings  Lyrics { get; set; }
}

public class LyricsSettings
{
    public string Endpoint { get; set; }
    public string ApiKey { get; set; }
    public string Territory { get; set; }
    public string Output { get; set; }
}