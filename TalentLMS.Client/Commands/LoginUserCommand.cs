using System.Text.Json.Serialization;

namespace TalentLMS.Client.Commands
{
    public class LoginUserCommand
    {
        [JsonPropertyName("login")] public string Login { get; set; }
        [JsonPropertyName("password")] public string Password { get; set; }

        /// <summary>
        ///     Optional, the url to redirect the user when he logs out from your TalentLMS domain.
        /// </summary>
        [JsonPropertyName("logout_redirect")]
        public string RedirectUrl { get; set; }
    }
}