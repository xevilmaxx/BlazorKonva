using BlazorKonva.KonvaClasses.Shape;
using System.Text.Json.Serialization;

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

        /// <summary>
        /// Custom Javascript function to execute for each frame of the animation
        /// <para/>
        /// I dont think you can writea javascript func in c# and auto-translate into javascript easily
        /// <para/>
        /// so will leave it as string where you can eventually inject a javascript function
        /// </summary>
        [JsonPropertyName("kerningFunc")]
        public string? KerningFunc { get; set; }

    }
}
