using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Tag
{

    /// <summary>
    /// Insufficient docs (?)
    /// </summary>
    public class KonvaTagConfigsDTO
    {

        [JsonPropertyName("pointerDirection")]
        public string? PointerDirection { get; set; }

        [JsonPropertyName("pointerWidth")]
        public int? PointerWidth { get; set; }

        [JsonPropertyName("pointerHeight")]
        public int? PointerHeight { get; set; }

        [JsonPropertyName("cornerRadius")]
        public int? CornerRadius { get; set; }

    }
}
