using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class LogoutUserQuery
    {
        [JsonPropertyName("redirect_url")] public string RedirectUrl { get; set; }
    }
}