using System.Text.Json.Serialization;

namespace TalentLMS.Client.Commands
{
    public class CreateGroupCommand
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("key")] public string Key { get; set; }
        [JsonPropertyName("price")] public string Price { get; set; }
        [JsonPropertyName("creator_id")] public string CreatorId { get; set; }
    }
}