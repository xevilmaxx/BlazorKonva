using BlazorKonva.KonvaClasses.Node;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Layer
{
    public class KonvaAnimationConfigsDTO : KonvaNodeConfigsDTO
    {
        /// <summary>
        /// Custom Javascript function to execute for each frame of the animation
        /// <para/>
        /// I dont think you can writea javascript func in c# and auto-translate into javascript easily
        /// <para/>
        /// so will leave it as string where you can eventually inject a javascript function
        /// </summary>
        [JsonPropertyName("func")]
        public string? Func { get; set; }

        [JsonPropertyName("layers")]
        public List<KonvaLayer> Layers { get; set; }
    }
}
