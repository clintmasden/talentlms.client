using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class AddCourseToBranchQuery
    {
        [JsonPropertyName("branch_id")] public string BranchId { get; set; }
        [JsonPropertyName("branch_name")] public string BranchName { get; set; }
        [JsonPropertyName("course_id")] public string CourseId { get; set; }
    }
}