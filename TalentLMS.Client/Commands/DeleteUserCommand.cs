using System.Text.Json.Serialization;

namespace TalentLMS.Client.Commands
{
    public class DeleteUserCommand
    {
        [JsonPropertyName("user_id")] public string Id { get; set; }

        /// <summary>
        ///     Optional, the user who is responsible for the deletion of the user.  If omitted then the owner of the
        ///     account(super-administrator) is responsible for the deletion.
        /// </summary>
        [JsonPropertyName("deleted_by_user_id")]
        public string DeletedByUserId { get; set; }

        /// <summary>
        ///     If the user is deleted permanently. (‘yes’ or ‘no’ as possible values)
        /// </summary>
        [JsonPropertyName("permanent")]
        public string IsPermanent { get; set; }
    }
}