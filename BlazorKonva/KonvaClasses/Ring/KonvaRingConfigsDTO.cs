using BlazorKonva.KonvaClasses.Shape;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Ring
{
    public class KonvaRingConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("innerRadius")]
        public int? InnerRadius { get; set; }

        [JsonPropertyName("outerRadius")]
        public int? OuterRadius { get; set; }

    }
}