using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class LoginUserQuery
    {
        [JsonPropertyName("user_id")] public string Id { get; set; }
        [JsonPropertyName("login_key")] public string LoginKey { get; set; }
    }
}