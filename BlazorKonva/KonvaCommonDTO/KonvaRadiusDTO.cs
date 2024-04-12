using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaCommonDTO
{
    public class KonvaRadiusDTO
    {
        [JsonPropertyName("x")]
        public int X { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
}
