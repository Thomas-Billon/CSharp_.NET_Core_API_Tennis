using System.Text.Json;

namespace Tennis.Utilities
{
    public class JsonReader : IJsonReader
    {
        public T? Read<T>(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        Converters =
                        {
                            new BoolConverter()
                        },
                        PropertyNameCaseInsensitive = true
                    };

                    T? data = JsonSerializer.Deserialize<T>(json, options);

                    return data;
                }
            }
            catch (Exception ex)
            {
                // Exception thrown:
                //  - The json file is missing
                //  - The json file doesn't have the proper read access
                //  - The json file has a typo in it

                throw new JsonException("Error: Unattainable or unreadable JSON file", ex);
            }
        }
    }
}
