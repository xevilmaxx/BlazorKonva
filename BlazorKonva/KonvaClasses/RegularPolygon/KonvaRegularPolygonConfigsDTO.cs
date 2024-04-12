using BlazorKonva.KonvaClasses.Shape;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.RegularPolygon
{
    public class KonvaRegularPolygonConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("sides")]
        public int? Sides { get; set; }

        [JsonPropertyName("radius")]
        public int? Radius { get; set; }

    }
}