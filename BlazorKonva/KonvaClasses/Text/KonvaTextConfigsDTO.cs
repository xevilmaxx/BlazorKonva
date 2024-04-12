using BlazorKonva.KonvaClasses.Shape;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Text
{
    public class KonvaTextConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("direction")]
        public string? Direction { get; set; }

        [JsonPropertyName("fontFamily")]
        public string? FontFamily { get; set; }

        [JsonPropertyName("fontSize")]
        public int? FontSize { get; set; }

        [JsonPropertyName("fontStyle")]
        public string? FontStyle { get; set; }

        [JsonPropertyName("fontVariant")]
        public string? FontVariant { get; set; }

        [JsonPropertyName("textDecoration")]
        public string? TextDecoration { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("align")]
        public string? Align { get; set; }

        [JsonPropertyName("verticalAlign")]
        public string? VerticalAlign { get; set; }

        [JsonPropertyName("padding")]
        public double? Padding { get; set; }

        [JsonPropertyName("lineHeight")]
        public double? LineHeight { get; set; }

        [JsonPropertyName("wrap")]
        public string? Wrap { get; set; }

        [JsonPropertyName("ellipsis")]
        public bool? Ellipsis { get; set; } = false;

    }
}