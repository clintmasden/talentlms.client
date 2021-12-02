using System;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class UsersQuery
    {
        public class User
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("login")] public string Login { get; set; }
            [JsonPropertyName("first_name")] public string FirstName { get; set; }
            [JsonPropertyName("last_name")] public string LastName { get; set; }
            [JsonPropertyName("email")] public string Email { get; set; }
            [JsonPropertyName("restrict_email")] public string RestrictEmail { get; set; }
            [JsonPropertyName("user_type")] public string UserType { get; set; }
            [JsonPropertyName("timezone")] public string Timezone { get; set; }
            [JsonPropertyName("language")] public string Language { get; set; }
            [JsonPropertyName("status")] public string Status { get; set; }
            [JsonPropertyName("deactivation_date")] public DateTime? DeactivationDate { get; set; }
            [JsonPropertyName("level")] public string Level { get; set; }
            [JsonPropertyName("points")] public string Points { get; set; }
            [JsonPropertyName("created_on")] public DateTime CreatedOn { get; set; }
            [JsonPropertyName("last_updated")] public DateTime LastUpdated { get; set; }
            [JsonPropertyName("last_updated_timestamp")] public string LastUpdatedTimestamp { get; set; }
            [JsonPropertyName("avatar")] public string Avatar { get; set; }
            [JsonPropertyName("bio")] public string Bio { get; set; }
            [JsonPropertyName("login_key")] public string LoginKey { get; set; }
            [JsonPropertyName("custom_field_1")] public string CustomField1 { get; set; }
            [JsonPropertyName("custom_field_2")] public string CustomField2 { get; set; }


            public override string ToString()
            {
                return $"{Id}: {FirstName} {LastName} | {Email}";
            }
        }
    }
}