using BlazorKonva.KonvaClasses.Shape;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Wedge
{
    public class KonvaWedgeConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("angle")]
        public int? Angle { get; set; }

        [JsonPropertyName("radius")]
        public int? Radius { get; set; }

        [JsonPropertyName("clockwise")]
        public bool? Clockwise { get; set; }

    }
}