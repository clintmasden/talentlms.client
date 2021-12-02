using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class CourseQuery
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
        [JsonPropertyName("level")] public object Level { get; set; }
        [JsonPropertyName("shared")] public string Shared { get; set; }
        [JsonPropertyName("shared_url")] public string SharedUrl { get; set; }
        [JsonPropertyName("avatar")] public string Avatar { get; set; }
        [JsonPropertyName("big_avatar")] public string BigAvatar { get; set; }
        [JsonPropertyName("certification")] public string Certification { get; set; }
        [JsonPropertyName("certification_duration")] public string CertificationDuration { get; set; }
        [JsonPropertyName("custom_field_1")] public string CustomField1 { get; set; }
        [JsonPropertyName("custom_field_2")] public object CustomField2 { get; set; }
        [JsonPropertyName("users")] public List<User> Users { get; set; }
        [JsonPropertyName("units")] public List<Unit> Units { get; set; }
        [JsonPropertyName("rules")] public List<string> Rules { get; set; }
        [JsonPropertyName("prerequisites")] public List<object> Prerequisites { get; set; }
        [JsonPropertyName("prerequisite_rule_sets")] public List<object> PrerequisiteRuleSets { get; set; }


        public override string ToString()
        {
            return $"{Id}: {Name}";
        }

        public class User
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("role")] public string Role { get; set; }
            [JsonPropertyName("enrolled_on")] public DateTime EnrolledOn { get; set; }
            [JsonPropertyName("enrolled_on_timestamp")] public string EnrolledOnTimestamp { get; set; }
            [JsonPropertyName("completed_on")] public DateTime? CompletedOn { get; set; }
            [JsonPropertyName("completed_on_timestamp")] public string CompletedOnTimestamp { get; set; }
            [JsonPropertyName("completion_percentage")] public string CompletionPercentage { get; set; }
            [JsonPropertyName("expired_on")] public DateTime? ExpiredOn { get; set; }
            [JsonPropertyName("expired_on_timestamp")] public object ExpiredOnTimestamp { get; set; }
            [JsonPropertyName("total_time")] public string TotalTime { get; set; }
            [JsonPropertyName("total_time_seconds")] public int TotalTimeSeconds { get; set; }

            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }

        public class Unit
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("type")] public string Type { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("url")] public string Url { get; set; }

            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }
    }
}