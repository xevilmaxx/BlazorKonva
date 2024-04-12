using BlazorKonva.KonvaClasses.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorKonva.KonvaClasses.Path
{
    public class KonvaPathConfigsDTO : KonvaShapeConfigsDTO
    {

        /// <summary>
        /// SVG data string
        /// </summary>
        [JsonPropertyName("data")]
        public string? Data { get; set; }

    }
}
