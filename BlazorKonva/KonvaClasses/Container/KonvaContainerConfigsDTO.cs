using BlazorKonva.KonvaClasses.Node;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Container
{
    public class KonvaContainerConfigsDTO : KonvaNodeConfigsDTO
    {

        [JsonPropertyName("clipX")]
        public int? ClipX { get; set; }

        [JsonPropertyName("clipY")]
        public int? ClipY { get; set; }

        [JsonPropertyName("clipWidth")]
        public int? ClipWidth { get; set; }

        [JsonPropertyName("clipHeight")]
        public int? ClipHeight { get; set; }

        /// <summary>
        /// Custom Javascript function to execute for each frame of the animation
        /// <para/>
        /// I dont think you can writea javascript func in c# and auto-translate into javascript easily
        /// <para/>
        /// so will leave it as string where you can eventually inject a javascript function
        /// </summary>
        [JsonPropertyName("clipFunc")]
        public string? ClipFunc { get; set; }

    }
}