using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class GroupQuery
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("key")] public string Key { get; set; }
        [JsonPropertyName("price")] public string Price { get; set; }
        [JsonPropertyName("owner_id")] public string OwnerId { get; set; }
        [JsonPropertyName("belongs_to_branch")] public object BelongsToBranch { get; set; }
        [JsonPropertyName("max_redemptions")] public object MaxRedemptions { get; set; }
        [JsonPropertyName("redemptions_sofar")] public object RedemptionsSofar { get; set; }
        [JsonPropertyName("users")] public List<User> Users { get; set; }
        [JsonPropertyName("courses")] public List<Course> Courses { get; set; }


        public override string ToString()
        {
            return $"{Id}: {Name}";
        }


        public class User
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }

            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }

        public class Course
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }

            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }
    }
}