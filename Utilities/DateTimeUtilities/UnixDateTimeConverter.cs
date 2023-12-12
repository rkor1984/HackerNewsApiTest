using Newtonsoft.Json;

public class UnixDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null)
        {
            return DateTime.MinValue;
        }

        long unixTimeStamp = Convert.ToInt64(reader.Value);
        DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        return unixEpoch.AddSeconds(unixTimeStamp);
    }

    public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
    {        
        writer.WriteValue(value.ToString());
    }
}

