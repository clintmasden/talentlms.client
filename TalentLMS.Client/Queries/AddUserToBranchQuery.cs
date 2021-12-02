using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class AddUserToBranchQuery
    {
        [JsonPropertyName("branch_id")] public string BranchId { get; set; }
        [JsonPropertyName("branch_name")] public string BranchName { get; set; }
        [JsonPropertyName("user_id")] public string UserId { get; set; }
    }
}