using Newtonsoft.Json;

public class Story
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Title { get; set; }

    [JsonProperty("url")]
    public string Uri { get; set; }

    [JsonProperty("by")]
    public string PostedBy { get; set; }

    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime Time { get; set; }
    public int Score { get; set; }

    [JsonProperty("descendants")]
    public int CommentCount { get; set; }
}
