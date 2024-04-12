using BlazorKonva.KonvaClasses.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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