using BlazorKonva.KonvaClasses.Shape;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Rect
{
    public class KonvaRectConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("cornerRadius")]
        public double? CornerRadius { get; set; } // Nullable double

    }
}
