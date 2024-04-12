using BlazorKonva.KonvaClasses.Shape;
using BlazorKonva.KonvaCommonDTO;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Ellipse
{
    public class KonvaEllipseConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("radius")]
        public KonvaRadiusDTO Radius { get; set; }

    }
}
