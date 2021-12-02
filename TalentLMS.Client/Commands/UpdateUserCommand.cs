using System;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.Commands
{
    public class UpdateUserCommand
    {
        [JsonPropertyName("user_id")] public string Id { get; set; }
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
        [JsonPropertyName("bio")] public string Bio { get; set; }
        [JsonPropertyName("timezone")] public string Timezone { get; set; }

        /// <summary>
        ///     Optional, with a deactivation date on which the user will become automatically inactive. Note that deactivation
        ///     date can be set only if the user is  already active.  Passing an empty value will result on disabling deactivation
        ///     date.
        /// </summary>
        [JsonPropertyName("deactivation_date")]
        public DateTime? DeactivationDate { get; set; }

        /// <summary>
        /// Optional, will become a member of the corresponding branch.
        /// </summary>
        //[JsonPropertyName("branch_id")] public string BranchId { get; set; }

        /// <summary>
        /// Optional, will become a member of the corresponding group.
        /// </summary>
        //[JsonPropertyName("group_id")] public string GroupId { get; set; }

        /// <summary>
        /// Optional, assign a specific user type by providing the user type name.
        /// </summary>
        //[JsonPropertyName("user_type")] public string UserType { get; set; }

        /// <summary>
        /// Optional, assign a specific language by providing the code.
        /// </summary>
        //[JsonPropertyName("language")] public string Language { get; set; }
    }
}