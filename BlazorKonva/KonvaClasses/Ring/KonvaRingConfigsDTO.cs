using BlazorKonva.KonvaClasses.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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