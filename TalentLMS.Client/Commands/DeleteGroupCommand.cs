using System.Text.Json.Serialization;

namespace TalentLMS.Client.Commands
{
    public class DeleteGroupCommand
    {
        [JsonPropertyName("group_id")] public string Id { get; set; }

        /// <summary>
        ///     Optional, the user who is responsible for the deletion of the branch.  If omitted then the owner of the
        ///     account(super-administrator) is responsible for the deletion.
        /// </summary>
        [JsonPropertyName("deleted_by_user_id")]
        public string DeletedByUserId { get; set; }
    }
}