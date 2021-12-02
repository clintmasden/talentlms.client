using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class CategoriesQuery
    {
        public class Category
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("price")] public string Price { get; set; }
            [JsonPropertyName("parent_category_id")] public string ParentCategoryId { get; set; }


            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }
    }
}