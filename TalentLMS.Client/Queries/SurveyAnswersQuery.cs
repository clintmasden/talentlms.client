using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.Queries
{
    public class SurveyAnswersQuery
    {
        [JsonPropertyName("survey_id")] public string SurveyId { get; set; }
        [JsonPropertyName("survey_name")] public string SurveyName { get; set; }
        [JsonPropertyName("user_id")] public string UserId { get; set; }
        [JsonPropertyName("user_name")] public string UserName { get; set; }
        [JsonPropertyName("completion_status")] public string CompletionStatus { get; set; }
        [JsonPropertyName("completed_on")] public DateTime CompletedOn { get; set; }
        [JsonPropertyName("completed_on_timestamp")] public string CompletedOnTimestamp { get; set; }
        [JsonPropertyName("total_time")] public string TotalTime { get; set; }
        [JsonPropertyName("questions")] public List<Question> Questions { get; set; }


        public override string ToString()
        {
            return $"{SurveyId}: {SurveyName}";
        }

        public class Question
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("text")] public string Text { get; set; }
            [JsonPropertyName("type")] public string Type { get; set; }
            [JsonPropertyName("answers")] public IDictionary<string, string> Answers { get; set; }
            [JsonPropertyName("user_answers")] public IDictionary<string, string> UserAnswers { get; set; }


            public override string ToString()
            {
                return $"{Id}: {Text}";
            }
        }
    }
}