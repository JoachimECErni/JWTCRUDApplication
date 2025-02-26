using System.Text.Json;
using System.Text.Json.Serialization;
using CRUDApplication.Common;

namespace CRUDApplication.Converter
{
    public class CountryOfOriginConverter : JsonConverter<countryOfOrigin>
    {
        public override countryOfOrigin Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            return value switch
            {
                "JP" => countryOfOrigin.Japan,
                "US" => countryOfOrigin.UnitedStates,
                "DE" => countryOfOrigin.Germany,
                "GB" => countryOfOrigin.UnitedKingdom,
                "CA" => countryOfOrigin.Canada,
                "FR" => countryOfOrigin.France,
                _ => countryOfOrigin.Unknown
            };
        }

        public override void Write(Utf8JsonWriter writer, countryOfOrigin value, JsonSerializerOptions options)
        {
            var stringValue = value switch
            {
                countryOfOrigin.Japan => "JP",
                countryOfOrigin.UnitedStates => "US",
                countryOfOrigin.Germany => "DE",
                countryOfOrigin.UnitedKingdom => "GB",
                countryOfOrigin.Canada => "CA",
                countryOfOrigin.France => "FR",
                _ => "Unknown"
            };

            writer.WriteStringValue(stringValue);
        }
    }
}
