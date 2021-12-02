using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    //The audacity of TalentLMS to make this a List of AddUserToCourseQuery with a single flipping item...
    public class AddUserToCourseQuery
    {
        [JsonPropertyName("course_id")] public string CourseId { get; set; }
        [JsonPropertyName("role")] public string Role { get; set; }
        [JsonPropertyName("user_id")] public string UserId { get; set; }
    }
}