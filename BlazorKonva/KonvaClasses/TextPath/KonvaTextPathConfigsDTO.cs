using BlazorKonva.KonvaClasses.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.TextPath
{
    public class KonvaTextPathConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("fontFamily")]
        public string? FontFamily { get; set; }

        [JsonPropertyName("fontSize")]
        public int? FontSize { get; set; }

        [JsonPropertyName("fontStyle")]
        public string? FontStyle { get; set; }

        [JsonPropertyName("fontVariant")]
        public string? FontVariant { get; set; }

        [JsonPropertyName("textBaseline")]
        public string? TextBaseline { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("data")]
        public string? Data { get; set; }

        [JsonPropertyName("kerningFunc")]
        public object? KerningFunc { get; set; }

    }
}
