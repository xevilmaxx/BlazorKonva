using BlazorKonva.KonvaClasses.Node;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Stage
{
    public class KonvaStageConfigsDTO : KonvaNodeConfigsDTO
    {

        [JsonPropertyName("container")]
        public string ContainerId { get; set; }

    }
}