using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Layer
{
    public class KonvaLayerConfigsDTO
    {
        [JsonPropertyName("clearBeforeDraw")]
        public bool? ClearBeforeDraw { get; set; } // Nullable boolean

        [JsonPropertyName("x")]
        public double? X { get; set; } // Nullable double

        [JsonPropertyName("y")]
        public double? Y { get; set; } // Nullable double

        [JsonPropertyName("width")]
        public double? Width { get; set; } // Nullable double

        [JsonPropertyName("height")]
        public double? Height { get; set; } // Nullable double

        [JsonPropertyName("visible")]
        public bool? Visible { get; set; } // Nullable boolean

        [JsonPropertyName("listening")]
        public bool? Listening { get; set; } // Nullable boolean

        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("name")]
        public string? Name { get; set; } // String

        [JsonPropertyName("opacity")]
        public double? Opacity { get; set; } // Nullable double

        [JsonPropertyName("scale")]
        public object? Scale { get; set; } // Nested object for scale

        [JsonPropertyName("scaleX")]
        public double? ScaleX { get; set; } // Nullable double (alternative to Scale)

        [JsonPropertyName("scaleY")]
        public double? ScaleY { get; set; } // Nullable double (alternative to Scale)

        [JsonPropertyName("rotation")]
        public double? Rotation { get; set; } // Nullable double

        [JsonPropertyName("offset")]
        public object? Offset { get; set; } // Nested object for offset

        [JsonPropertyName("offsetX")]
        public double? OffsetX { get; set; } // Nullable double (alternative to Offset)

        [JsonPropertyName("offsetY")]
        public double? OffsetY { get; set; } // Nullable double (alternative to Offset)

        [JsonPropertyName("draggable")]
        public bool? Draggable { get; set; } // Nullable boolean

        [JsonPropertyName("dragDistance")]
        public double? DragDistance { get; set; } // Nullable double

        // Function properties (dragBoundFunc, clipFunc) are not directly translatable to C# properties.
        // You'll need to handle these separately in your application logic.

        // Clip properties (clipX, clipY, clipWidth, clipHeight) can be included as nullable doubles if needed.

    }
}
