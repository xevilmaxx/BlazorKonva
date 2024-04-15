using BlazorKonva.KonvaCommonDTO;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Node
{
    public class KonvaNodeConfigsDTO
    {

        [JsonPropertyName("x")]
        public double? X { get; set; }

        [JsonPropertyName("y")]
        public double? Y { get; set; }

        [JsonPropertyName("width")]
        public double? Width { get; set; }

        [JsonPropertyName("height")]
        public double? Height { get; set; }

        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }

        [JsonPropertyName("listening")]
        public bool? Listening { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("opacity")]
        public double? Opacity { get; set; }

        [JsonPropertyName("scale")]
        public KonvaScaleDTO? Scale { get; set; }

        [JsonPropertyName("scaleX")]
        public double? ScaleX { get; set; }

        [JsonPropertyName("scaleY")]
        public double? ScaleY { get; set; }

        [JsonPropertyName("rotation")]
        public double? Rotation { get; set; }

        [JsonPropertyName("offset")]
        public KonvaOffsetDTO? Offset { get; set; }

        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }

        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }

        [JsonPropertyName("draggable")]
        public bool? Draggable { get; set; }

        [JsonPropertyName("dragDistance")]
        public double? DragDistance { get; set; }

        /// <summary>
        /// Custom Javascript function to execute for each frame of the animation
        /// <para/>
        /// I dont think you can writea javascript func in c# and auto-translate into javascript easily
        /// <para/>
        /// so will leave it as string where you can eventually inject a javascript function
        /// </summary>
        [JsonPropertyName("dragBoundFunc")]
        public string? DragBoundFunc { get; set; }

    }
}
