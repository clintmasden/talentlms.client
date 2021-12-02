using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class GroupsQuery
    {
        public class Group
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("description")] public string Description { get; set; }
            [JsonPropertyName("key")] public string Key { get; set; }
            [JsonPropertyName("price")] public string Price { get; set; }
            [JsonPropertyName("owner_id")] public string OwnerId { get; set; }
            [JsonPropertyName("belongs_to_branch")] public string BelongsToBranch { get; set; }
            [JsonPropertyName("max_redemptions")] public string MaxRedemptions { get; set; }
            [JsonPropertyName("redemptions_sofar")] public string RedemptionsSofar { get; set; }

            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }
    }
}