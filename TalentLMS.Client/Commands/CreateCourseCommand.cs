using System.Text.Json.Serialization;

namespace TalentLMS.Client.Commands
{
    public class CreateCourseCommand
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("price")] public string Price { get; set; }
        [JsonPropertyName("time_limit")] public string TimeLimit { get; set; }
        [JsonPropertyName("category_id")] public string CategoryId { get; set; }
        [JsonPropertyName("creator_id")] public string CreatorId { get; set; }
    }
}