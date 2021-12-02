using System.Text.Json.Serialization;

namespace TalentLMS.Client.Commands
{
    /// <summary>
    ///     At least LMS uses a post here, yet they should have stayed consistently terrible thru-out...
    /// </summary>
    internal class AddUserToCourseCommand
    {
        [JsonPropertyName("course_id")] public string CourseId { get; set; }
        [JsonPropertyName("role")] public string Role { get; set; }
        [JsonPropertyName("user_id")] public string UserId { get; set; }
    }
}