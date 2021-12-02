using System.Text.Json.Serialization;

namespace TalentLMS.Client.Commands
{
    public class LogoutUserCommand
    {
        [JsonPropertyName("user_id")] public string Id { get; set; }

        /// <summary>
        ///     Optional, the url to redirect the user when he logs out from your TalentLMS domain.
        /// </summary>
        [JsonPropertyName("next")]
        public string RedirectUrl { get; set; }
    }
}