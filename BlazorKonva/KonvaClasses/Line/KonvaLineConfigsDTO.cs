using BlazorKonva.KonvaClasses.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Line
{
    public class KonvaLineConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("points")]
        public int[] Points { get; set; }

        [JsonPropertyName("tension")]
        public int? Tension { get; set; }

        [JsonPropertyName("closed")]
        public bool? Closed { get; set; }

        [JsonPropertyName("bezier")]
        public bool? Bezier { get; set; }

    }
}