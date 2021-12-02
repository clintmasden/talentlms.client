using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class AddUserToGroupQuery
    {
        [JsonPropertyName("group_id")] public string GroupId { get; set; }
        [JsonPropertyName("group_name")] public string GroupName { get; set; }
        [JsonPropertyName("user_id")] public string UserId { get; set; }
    }
}