using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class AddCourseToGroupQuery
    {
        [JsonPropertyName("group_id")] public string GroupId { get; set; }
        [JsonPropertyName("group_name")] public string GroupName { get; set; }
        [JsonPropertyName("course_id")] public string CourseId { get; set; }
    }
}