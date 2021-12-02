using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class CategoryQuery
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("price")] public string Price { get; set; }
        [JsonPropertyName("parent_category_id")] public string ParentCategoryId { get; set; }
        [JsonPropertyName("courses")] public List<Course> Courses { get; set; }


        public override string ToString()
        {
            return $"{Id}: {Name}";
        }


        public class Course
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("description")] public string Description { get; set; }
            [JsonPropertyName("price")] public string Price { get; set; }
            [JsonPropertyName("status")] public string Status { get; set; }
            [JsonPropertyName("hide_from_catalog")] public string HideFromCatalog { get; set; }
            [JsonPropertyName("level")] public object Level { get; set; }
            [JsonPropertyName("shared")] public string Shared { get; set; }
            [JsonPropertyName("shared_url")] public string SharedUrl { get; set; }
            [JsonPropertyName("avatar")] public string Avatar { get; set; }
            [JsonPropertyName("big_avatar")] public string BigAvatar { get; set; }


            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }
    }
}