using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class UpdateUserStatusQuery
    {
        [JsonPropertyName("user_id")] public string Id { get; set; }
        [JsonPropertyName("status")] public string Status { get; set; }
    }
}