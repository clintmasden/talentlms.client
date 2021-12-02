using System;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class CoursesQuery
    {
        public class Course
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("code")] public string Code { get; set; }
            [JsonPropertyName("category_id")] public string CategoryId { get; set; }
            [JsonPropertyName("description")] public string Description { get; set; }
            [JsonPropertyName("price")] public string Price { get; set; }
            [JsonPropertyName("status")] public string Status { get; set; }
            [JsonPropertyName("creation_date")] public DateTime CreationDate { get; set; }
            [JsonPropertyName("last_update_on")] public DateTime LastUpdateOn { get; set; }
            [JsonPropertyName("creator_id")] public string CreatorId { get; set; }
            [JsonPropertyName("hide_from_catalog")] public string HideFromCatalog { get; set; }
            [JsonPropertyName("time_limit")] public string TimeLimit { get; set; }
            [JsonPropertyName("start_datetime")] public object StartDatetime { get; set; }
            [JsonPropertyName("expiration_datetime")] public object ExpirationDatetime { get; set; }
            [JsonPropertyName("level")] public string Level { get; set; }
            [JsonPropertyName("shared")] public string Shared { get; set; }
            [JsonPropertyName("shared_url")] public string SharedUrl { get; set; }
            [JsonPropertyName("avatar")] public string Avatar { get; set; }
            [JsonPropertyName("big_avatar")] public string BigAvatar { get; set; }
            [JsonPropertyName("certification")] public string Certification { get; set; }
            [JsonPropertyName("certification_duration")] public string CertificationDuration { get; set; }
            [JsonPropertyName("custom_field_1")] public string CustomField1 { get; set; }
            [JsonPropertyName("custom_field_2")] public string CustomField2 { get; set; }

            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }
    }
}