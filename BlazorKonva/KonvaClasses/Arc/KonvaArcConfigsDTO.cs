using BlazorKonva.KonvaClasses.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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