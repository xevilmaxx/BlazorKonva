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

        [JsonPropertyName("clipFunc")]
        public object? ClipFunc { get; set; }

    }
}