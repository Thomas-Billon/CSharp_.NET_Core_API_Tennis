using System.Text.Json;
using Tennis.Utilities;

namespace Tennis.Data
{
    public class JsonReader : IJsonReader
    {
        public T Read<T>(string filePath) where T : new()
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();
                    var options = new JsonSerializerOptions
                    {
                        Converters = { new BoolConverter() },
                        PropertyNameCaseInsensitive = true
                    };

                    T? data = JsonSerializer.Deserialize<T>(json, options);

                    return (data == null) ? new T() : data;
                }
            }
            catch (Exception)
            {
                // Exception thrown:
                //  - The json file is missing
                //  - The json file doesn't have the proper read access
                //  - The json file has a typo in it
                // In any case we return an empty player list
                return new T();
            }
        }
    }
}
