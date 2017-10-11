namespace Sureal.Auth.Common.JSonConverter
{
    using Newtonsoft.Json;

    /// <summary>
    /// Implementation using Newtonsoft.Json
    /// </summary>
    public class JsonConverter : IJsonConverter
    {
        /// <summary>
        /// Deserialize a json object into a proper C# POCO
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>
        /// This will load the whole file into memory, if the file is too big be careful. 
        /// </remarks>
        public TResult DeserializeObject<TResult>(string value)
        {
            return JsonConvert.DeserializeObject<TResult>(value);
        }

        /// <summary>
        /// Serialize a json object into a string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
