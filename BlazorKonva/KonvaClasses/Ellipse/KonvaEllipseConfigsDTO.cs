using BlazorKonva.KonvaClasses.Shape;
using BlazorKonva.KonvaCommonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Ellipse
{
    public class KonvaEllipseConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("radius")]
        public KonvaRadiusDTO Radius { get; set; }

    }
}
