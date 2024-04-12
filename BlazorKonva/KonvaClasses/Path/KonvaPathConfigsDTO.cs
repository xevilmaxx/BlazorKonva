using BlazorKonva.KonvaClasses.Shape;
using System.Text.Json.Serialization;

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
