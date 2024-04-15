using BlazorKonva.KonvaClasses.Shape;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Circle
{
    public class KonvaCircleConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("radius")]
        public int? Radius { get; set; }

    }
}