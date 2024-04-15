using BlazorKonva.KonvaClasses.Node;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Layer
{
    public class KonvaLayerConfigsDTO : KonvaNodeConfigsDTO
    {
        [JsonPropertyName("clearBeforeDraw")]
        public bool? ClearBeforeDraw { get; set; } // Nullable boolean

        [JsonPropertyName("clipX")]
        public int? ClipX { get; set; } // Nullable double

        [JsonPropertyName("clipY")]
        public int? ClipY { get; set; } // Nullable double

        [JsonPropertyName("clipWidth")]
        public int? ClipWidth { get; set; } // Nullable double

        [JsonPropertyName("clipHeight")]
        public int? ClipHeight { get; set; } // Nullable double

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
