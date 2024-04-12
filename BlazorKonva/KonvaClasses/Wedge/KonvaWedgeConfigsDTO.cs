using BlazorKonva.KonvaClasses.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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