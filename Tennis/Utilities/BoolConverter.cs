using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tennis.Utilities
{
    public class BoolConverter : JsonConverter<bool>
    {
        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteBooleanValue(value);
        }

        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.True:
                    return true;

                case JsonTokenType.False:
                    return false;

                case JsonTokenType.String:
                    if (bool.TryParse(reader.GetString(), out bool result))
                    {
                        return result;
                    }
                    else
                    {
                        throw new JsonException();
                    }

                case JsonTokenType.Number:
                    if (reader.TryGetInt64(out long valueLong))
                    {
                        return Convert.ToBoolean(valueLong);
                    }
                    else if (reader.TryGetDouble(out double valueDouble))
                    {
                        return Convert.ToBoolean(valueDouble);
                    }
                    else
                    {
                        return false;
                    }
            }

            throw new JsonException();
        }
    }
}
