using BlazorKonva.KonvaClasses.Shape;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Line
{
    public class KonvaLineConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("points")]
        public int[] Points { get; set; }

        [JsonPropertyName("tension")]
        public int? Tension { get; set; }

        [JsonPropertyName("closed")]
        public bool? Closed { get; set; }

        [JsonPropertyName("bezier")]
        public bool? Bezier { get; set; }

    }
}