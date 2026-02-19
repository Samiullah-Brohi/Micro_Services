using System.Text.Json.Serialization;

namespace supportservices.Models;

public class SupportServiceRecord
{
    [JsonPropertyName("1stlogin")]
    public DateTime? FirstLogin { get; set; }

    [JsonPropertyName("2ndlogin")]
    public DateTime? SecondLogin { get; set; }

    [JsonPropertyName("1stswipe")]
    public DateTime? FirstSwipe { get; set; }

    [JsonPropertyName("2ndswipe")]
    public DateTime? SecondSwipe { get; set; }
}