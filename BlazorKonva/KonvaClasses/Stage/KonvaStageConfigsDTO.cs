using BlazorKonva.KonvaClasses.Stage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Xml;

namespace BlazorKonva.KonvaClasses.Stage
{
    public class KonvaStageConfigsDTO
    {
        
        [JsonPropertyName("container")]
        public string ContainerId { get; set; }
        
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonPropertyName("x")]
        public int? X { get; set; }
        
        [JsonPropertyName("y")]
        public int? Y { get; set; }
        
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        
        [JsonPropertyName("listening")]
        public bool? Listening { get; set; }

        /// <summary>
        /// its needed, becouse Konva doesnt use ids by default,
        /// but if we will have more objects and need retrive them later we will need it
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("opacity")]
        public double? Opacity { get; set; }

        [JsonPropertyName("scale")]
        public object? Scale { get; set; }

        [JsonPropertyName("scaleX")]
        public int? ScaleX { get; set; }
        
        [JsonPropertyName("scaleY")]
        public int? ScaleY { get; set; }

        [JsonPropertyName("rotation")]
        public int? Rotation { get; set; }

        [JsonPropertyName("offset")]
        public object? Offset { get; set; }

        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }

        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }

        [JsonPropertyName("draggable")]
        public bool? Dtaggable { get; set; }

        [JsonPropertyName("dragDistance")]
        public int? DragDistance { get; set; }

        [JsonPropertyName("dragBoundFunc")]
        public object? DragBoundFunc { get; set; }
    }
}