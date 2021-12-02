using System.Text.Json.Serialization;

namespace TalentLMS.Client.Commands
{
    public class CreateBranchCommand
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("group_id")] public string GroupId { get; set; }
        [JsonPropertyName("language")] public string Language { get; set; }
        [JsonPropertyName("timezone")] public string Timezone { get; set; }
        [JsonPropertyName("signup_method")] public string SignupMethod { get; set; }
        [JsonPropertyName("ecommerce_processor")] public string EcommerceProcessor { get; set; }
        [JsonPropertyName("currency")] public string Currency { get; set; }
        [JsonPropertyName("paypal_email")] public string PaypalEmail { get; set; }
        [JsonPropertyName("ecommerce_subscription")] public string EcommerceSubscription { get; set; }
        [JsonPropertyName("ecommerce_subscription_price")] public string EcommerceSubscriptionPrice { get; set; }
        [JsonPropertyName("internal_announcement")] public string InternalAnnouncement { get; set; }
        [JsonPropertyName("external_announcement")] public string ExternalAnnouncement { get; set; }
        [JsonPropertyName("creator_id")] public string CreatorId { get; set; }
    }
}