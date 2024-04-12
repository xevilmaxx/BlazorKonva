﻿using BlazorKonva.KonvaClasses.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Star
{
    public class KonvaStarConfigsDTO : KonvaShapeConfigsDTO
    {

        [JsonPropertyName("numPoints")]
        public int? NumPoints { get; set; }

        [JsonPropertyName("innerRadius")]
        public int? InnerRadius { get; set; }

        [JsonPropertyName("outerRadius")]
        public int? OuterRadius { get; set; }

    }
}
