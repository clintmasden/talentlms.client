using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class UserQuery
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("login")] public string Login { get; set; }
        [JsonPropertyName("first_name")] public string FirstName { get; set; }
        [JsonPropertyName("last_name")] public string LastName { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
        [JsonPropertyName("restrict_email")] public string RestrictEmail { get; set; }
        [JsonPropertyName("user_type")] public string UserType { get; set; }
        [JsonPropertyName("timezone")] public string Timezone { get; set; }
        [JsonPropertyName("language")] public string Language { get; set; }
        [JsonPropertyName("status")] public string Status { get; set; }
        [JsonPropertyName("deactivation_date")] public DateTime? DeactivationDate { get; set; }
        [JsonPropertyName("level")] public string Level { get; set; }
        [JsonPropertyName("points")] public string Points { get; set; }
        [JsonPropertyName("created_on")] public DateTime CreatedOn { get; set; }
        [JsonPropertyName("last_updated")] public DateTime LastUpdated { get; set; }
        [JsonPropertyName("last_updated_timestamp")] public string LastUpdatedTimestamp { get; set; }
        [JsonPropertyName("avatar")] public string Avatar { get; set; }
        [JsonPropertyName("bio")] public string Bio { get; set; }
        [JsonPropertyName("login_key")] public string LoginKey { get; set; }
        [JsonPropertyName("custom_field_1")] public object CustomField1 { get; set; }
        [JsonPropertyName("custom_field_2")] public object CustomField2 { get; set; }
        [JsonPropertyName("courses")] public List<Course> Courses { get; set; }
        [JsonPropertyName("branches")] public List<Branch> Branches { get; set; }
        [JsonPropertyName("groups")] public List<Group> Groups { get; set; }
        [JsonPropertyName("certifications")] public List<Certification> Certifications { get; set; }
        [JsonPropertyName("badges")] public List<Badge> Badges { get; set; }


        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName} | {Email}";
        }

        public class Course
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("role")] public string Role { get; set; }
            [JsonPropertyName("enrolled_on")] public DateTime EnrolledOn { get; set; }
            [JsonPropertyName("enrolled_on_timestamp")] public string EnrolledOnTimestamp { get; set; }
            [JsonPropertyName("completed_on")] public DateTime? CompletedOn { get; set; }
            [JsonPropertyName("completed_on_timestamp")] public string CompletedOnTimestamp { get; set; }
            [JsonPropertyName("completion_status")] public string CompletionStatus { get; set; }
            [JsonPropertyName("completion_status_formatted")] public string CompletionStatusFormatted { get; set; }
            [JsonPropertyName("completion_percentage")] public string CompletionPercentage { get; set; }
            [JsonPropertyName("expired_on")] public DateTime? ExpiredOn { get; set; }
            [JsonPropertyName("expired_on_timestamp")] public string ExpiredOnTimestamp { get; set; }
            [JsonPropertyName("total_time")] public string TotalTime { get; set; }
            [JsonPropertyName("total_time_seconds")] public int TotalTimeSeconds { get; set; }
            [JsonPropertyName("last_accessed_unit_url")] public string LastAccessedUnitUrl { get; set; }

            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }

        public class Branch
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }

            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }

        public class Group
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }

            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }

        public class Certification
        {
            [JsonPropertyName("course_id")] public string CourseId { get; set; }
            [JsonPropertyName("course_name")] public string CourseName { get; set; }
            [JsonPropertyName("unique_id")] public string UniqueId { get; set; }
            [JsonPropertyName("issued_date")] public DateTime IssuedDate { get; set; }
            [JsonPropertyName("issued_date_timestamp")] public int IssuedDateTimestamp { get; set; }
            [JsonPropertyName("expiration_date")] public DateTime? ExpirationDate { get; set; }
            [JsonPropertyName("expiration_date_timestamp")] public int ExpirationDateTimestamp { get; set; }
            [JsonPropertyName("download_url")] public string DownloadUrl { get; set; }
            [JsonPropertyName("public_url")] public string PublicUrl { get; set; }


            public override string ToString()
            {
                return $"{CourseId}: {CourseName}";
            }
        }

        public class Badge
        {
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("type")] public string Type { get; set; }
            [JsonPropertyName("image_url")] public string ImageUrl { get; set; }
            [JsonPropertyName("criteria")] public string Criteria { get; set; }
            [JsonPropertyName("issued_on")] public DateTime IssuedOn { get; set; }
            [JsonPropertyName("issued_on_timestamp")] public int IssuedOnTimestamp { get; set; }
            [JsonPropertyName("badge_set_id")] public string BadgeSetId { get; set; }


            public override string ToString()
            {
                return $"{Name}";
            }
        }
    }
}