using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.Extensions
{
    internal static class FormUrlEncodeExtensions
    {
        /// <summary>
        ///     TalentLMS wants integrations to be painful/terrible, some endpoints will accept JSON, some will only accept FormContent.
        /// </summary>
        /// <param name="classObject"></param>
        /// <returns></returns>
        internal static FormUrlEncodedContent GetFormUrlEncodedContent(this object classObject)
        {
            var propertyInfos = classObject.GetType().GetProperties();
            var data = new Dictionary<string, string>();

            foreach (var propertyInfo in propertyInfos)
            {
                var attributes = propertyInfo.GetCustomAttributes(true);
                var attribute = (JsonPropertyNameAttribute) attributes.FirstOrDefault(a => a is JsonPropertyNameAttribute);

                var value = propertyInfo.GetValue(classObject, null);

                // TalentLMS does not accept empty strings for optional parameters /sigh
                if (value != null)
                {
                    data.Add(attribute is null ? propertyInfo.Name : attribute.Name, value.ToString());
                }

                // data.Add(attribute is null ? propertyInfo.Name : attribute.Name, value is null ? string.Empty : value.ToString());
            }

            return new FormUrlEncodedContent(data);
        }
    }
}