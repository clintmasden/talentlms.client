using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class RateLimitQuery
    {
        [JsonPropertyName("limit")] public string Limit { get; set; }
        [JsonPropertyName("remaining")] public int Remaining { get; set; }
        [JsonPropertyName("reset")] public string Reset { get; set; }
        [JsonPropertyName("formatted_reset")] public string FormattedReset { get; set; }
    }
}