using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class BranchesQuery
    {
        public class Branch
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("description")] public string Description { get; set; }
            [JsonPropertyName("avatar")] public string Avatar { get; set; }
            [JsonPropertyName("theme")] public string Theme { get; set; }
            [JsonPropertyName("badge_set_id")] public string BadgeSetId { get; set; }
            [JsonPropertyName("timezone")] public string Timezone { get; set; }
            [JsonPropertyName("signup_method")] public string SignupMethod { get; set; }
            [JsonPropertyName("signup_type")] public string SignupType { get; set; }
            [JsonPropertyName("verification")] public string Verification { get; set; }
            [JsonPropertyName("internal_announcement")] public string InternalAnnouncement { get; set; }
            [JsonPropertyName("external_announcement")] public string ExternalAnnouncement { get; set; }
            [JsonPropertyName("language")] public string Language { get; set; }
            [JsonPropertyName("user_type_id")] public string UserTypeId { get; set; }
            [JsonPropertyName("user_type")] public string UserType { get; set; }
            [JsonPropertyName("group_id")] public string GroupId { get; set; }
            [JsonPropertyName("registration_email_restriction")] public object RegistrationEmailRestriction { get; set; }
            [JsonPropertyName("users_limit")] public string UsersLimit { get; set; }
            [JsonPropertyName("disallow_global_login")] public string DisallowGlobalLogin { get; set; }
            [JsonPropertyName("payment_processor")] public string PaymentProcessor { get; set; }
            [JsonPropertyName("currency")] public string Currency { get; set; }
            [JsonPropertyName("paypal_email")] public string PaypalEmail { get; set; }
            [JsonPropertyName("ecommerce_subscription")] public string EcommerceSubscription { get; set; }
            [JsonPropertyName("ecommerce_subscription_price")] public string EcommerceSubscriptionPrice { get; set; }
            [JsonPropertyName("ecommerce_subscription_interval")] public string EcommerceSubscriptionInterval { get; set; }
            [JsonPropertyName("ecommerce_subscription_trial_period")] public string EcommerceSubscriptionTrialPeriod { get; set; }
            [JsonPropertyName("ecommerce_credits")] public string EcommerceCredits { get; set; }


            public override string ToString()
            {
                return $"{Id}: {Name}";
            }
        }
    }
}