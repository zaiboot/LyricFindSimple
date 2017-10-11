using Newtonsoft.Json;

public class LyricFindResponse
{
    [JsonProperty(propertyName: "Response")]
    public ReponseNode Response { get; set; }
    public TrackResponse track { get; set; }
}

public class ReponseNode
{
    public int Code { get; set; }
    
    public string Description { get; set; }
   
}

public class TrackResponse
{
    [JsonProperty(propertyName: "lyrics")]
    public string Lyrics { get; set; }
}