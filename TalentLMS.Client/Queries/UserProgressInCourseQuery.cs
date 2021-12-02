using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class UserProgressInCourseQuery
    {
        [JsonPropertyName("role")] public string Role { get; set; }
        [JsonPropertyName("enrolled_on")] public DateTime EnrolledOn { get; set; }
        [JsonPropertyName("enrolled_on_timestamp")] public string EnrolledOnTimestamp { get; set; }
        [JsonPropertyName("completion_status")] public string CompletionStatus { get; set; }
        [JsonPropertyName("completion_percentage")] public string CompletionPercentage { get; set; }
        [JsonPropertyName("completed_on")] public DateTime? CompletedOn { get; set; }
        [JsonPropertyName("completed_on_timestamp")] public string CompletedOnTimestamp { get; set; }
        [JsonPropertyName("expired_on")] public DateTime? ExpiredOn { get; set; }
        [JsonPropertyName("expired_on_timestamp")] public object ExpiredOnTimestamp { get; set; }
        [JsonPropertyName("total_time")] public string TotalTime { get; set; }
        [JsonPropertyName("total_time_seconds")] public int TotalTimeSeconds { get; set; }
        [JsonPropertyName("units")] public List<Unit> Units { get; set; }


        public class Unit
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("type")] public string Type { get; set; }
            [JsonPropertyName("completion_status")] public string CompletionStatus { get; set; }
            [JsonPropertyName("completed_on")] public DateTime? CompletedOn { get; set; }
            [JsonPropertyName("completed_on_timestamp")] public string CompletedOnTimestamp { get; set; }
            [JsonPropertyName("score")] public string Score { get; set; }
            [JsonPropertyName("total_time")] public string TotalTime { get; set; }
            [JsonPropertyName("total_time_seconds")] public int TotalTimeSeconds { get; set; }


            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }
    }
}