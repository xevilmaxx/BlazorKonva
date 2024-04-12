using BlazorKonva.KonvaClasses.Shape;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Star
{
    public class KonvaStarConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("numPoints")]
        public int? NumPoints { get; set; }

        [JsonPropertyName("innerRadius")]
        public int? InnerRadius { get; set; }

        [JsonPropertyName("outerRadius")]
        public int? OuterRadius { get; set; }

    }
}
