using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace TalentLMS.Client.Exceptions
{
    public class TalentLMSHttpException : Exception
    {
        public TalentLMSHttpException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;

            try
            {
                //This is a disgusting hack, yet for whatever reason it's giving me an empty object with the built-in deserialize.
                var jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(message), new XmlDictionaryReaderQuotas());

                var root = XElement.Load(jsonReader);
                StatusType = root.XPathSelectElement("//type")?.Value;
                StatusMessage = root.XPathSelectElement("//message")?.Value;
            }
            catch
            {
                // ignored
            }
        }

        public HttpStatusCode StatusCode { get; set; }

        public string StatusType { get; set; }

        public string StatusMessage { get; set; }
    }
}