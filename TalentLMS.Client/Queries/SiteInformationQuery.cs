using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class SiteInformationQuery
    {
        [JsonPropertyName("total_users")] public string TotalUsers { get; set; }
        [JsonPropertyName("total_courses")] public string TotalCourses { get; set; }
        [JsonPropertyName("total_categories")] public string TotalCategories { get; set; }
        [JsonPropertyName("total_groups")] public string TotalGroups { get; set; }
        [JsonPropertyName("total_branches")] public string TotalBranches { get; set; }
        [JsonPropertyName("monthly_active_users")] public int MonthlyActiveUsers { get; set; }
        [JsonPropertyName("signup_method")] public string SignupMethod { get; set; }
        [JsonPropertyName("signup_type")] public string SignupType { get; set; }
        [JsonPropertyName("verification")] public string Verification { get; set; }
        [JsonPropertyName("paypal_email")] public string PaypalEmail { get; set; }
        [JsonPropertyName("domain_map")] public string DomainMap { get; set; }
        [JsonPropertyName("date_format")] public string DateFormat { get; set; }
    }
}