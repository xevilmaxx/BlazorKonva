using BlazorKonva.KonvaClasses.Node;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Layer
{
    public class KonvaAnimationConfigsDTO : KonvaNodeConfigsDTO
    {
        [JsonPropertyName("func")]
        public object? Func { get; set; }

        [JsonPropertyName("layers")]
        public List<KonvaLayer> Layers { get; set; }
    }
}
