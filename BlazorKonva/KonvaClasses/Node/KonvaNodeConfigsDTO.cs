using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        public object? Scale { get; set; }

        [JsonPropertyName("scaleX")]
        public double? ScaleX { get; set; }

        [JsonPropertyName("scaleY")]
        public double? ScaleY { get; set; }

        [JsonPropertyName("rotation")]
        public double? Rotation { get; set; }

        [JsonPropertyName("offset")]
        public object? Offset { get; set; }

        [JsonPropertyName("offsetX")]
        public double? OffsetX { get; set; }

        [JsonPropertyName("offsetY")]
        public double? OffsetY { get; set; }

        [JsonPropertyName("draggable")]
        public bool? Draggable { get; set; }

        [JsonPropertyName("dragDistance")]
        public double? DragDistance { get; set; }

        [JsonPropertyName("dragBoundFunc")]
        public object? DragBoundFunc { get; set; }

    }
}
