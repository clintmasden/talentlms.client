using System.Text.Json.Serialization;

namespace TalentLMS.Client.Commands
{
    public class CreateUserCommand
    {
        [JsonPropertyName("first_name")] public string FirstName { get; set; }
        [JsonPropertyName("last_name")] public string LastName { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }

        /// <summary>
        ///     Optional, with value 'on' to exclude the user from emails or 'off' if you’d want the user to receive emails from
        ///     the system.
        /// </summary>
        [JsonPropertyName("restrict_email")]
        public string RestrictEmail { get; set; }

        [JsonPropertyName("login")] public string Login { get; set; }
        [JsonPropertyName("password")] public string Password { get; set; }

        /// <summary>
        ///     Optional, will become a member of the corresponding branch.
        /// </summary>
        [JsonPropertyName("branch_id")]
        public string BranchId { get; set; }

        /// <summary>
        ///     Optional, will become a member of the corresponding group.
        /// </summary>
        [JsonPropertyName("group_id")]
        public string GroupId { get; set; }

        /// <summary>
        ///     Optional, assign a specific user type by providing the user type name.
        /// </summary>
        [JsonPropertyName("user_type")]
        public string UserType { get; set; }

        /// <summary>
        ///     Optional, assign a specific language by providing the code.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}