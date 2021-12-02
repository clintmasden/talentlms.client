using System;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class IltSessionsQuery
    {
        public class IltSession
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("multiname")] public string Multiname { get; set; }
            [JsonPropertyName("linked_to")] public string LinkedTo { get; set; }
            [JsonPropertyName("type")] public string Type { get; set; }
            [JsonPropertyName("owner_id")] public string OwnerId { get; set; }
            [JsonPropertyName("instructor_id")] public string InstructorId { get; set; }
            [JsonPropertyName("description")] public string Description { get; set; }
            [JsonPropertyName("location")] public string Location { get; set; }
            [JsonPropertyName("start_timestamp")] public string StartTimestamp { get; set; }
            [JsonPropertyName("start_date")] public DateTime StartDate { get; set; }
            [JsonPropertyName("capacity")] public string Capacity { get; set; }
            [JsonPropertyName("duration_minutes")] public string DurationMinutes { get; set; }


            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }
    }
}