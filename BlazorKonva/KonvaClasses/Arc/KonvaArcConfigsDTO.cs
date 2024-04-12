using BlazorKonva.KonvaClasses.Shape;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Arc
{
    public class KonvaArcConfigsDTO : KonvaShapeConfigsDTO
    {

        /// <summary>
        /// int in degrees
        /// </summary>
        [JsonPropertyName("angle")]
        public int Angle { get; set; }

        [JsonPropertyName("innerRadius")]
        public int InnerRadius { get; set; }

        [JsonPropertyName("outerRadius")]
        public int OuterRadius { get; set; }

        [JsonPropertyName("clockwise")]
        public bool? Clockwise { get; set; }

    }
}