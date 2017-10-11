namespace Sureal.Auth.Common.HttpClient
{
    using System.Net.Http;

    public class JsonEncodedContent : StringContent
    {
        private const string CONTENT_TYPE = "application/json";

        public JsonEncodedContent(string content) : base(content, System.Text.Encoding.UTF8, CONTENT_TYPE)
        {

        }
    }
}
