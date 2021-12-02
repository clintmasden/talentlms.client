using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class UpdateBranchStatusQuery
    {
        [JsonPropertyName("branch_id")] public string Id { get; set; }
        [JsonPropertyName("status")] public string Status { get; set; }
    }
}