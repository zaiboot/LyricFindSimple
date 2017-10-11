namespace Sureal.Auth.Common.JSonConverter
{
    /// <summary>
    /// Wrapper to decouple json operations.
    /// </summary>
    public interface IJsonConverter
    {
        TResult DeserializeObject<TResult>(string value);

        string SerializeObject(object obj);
    }
}