﻿using BlazorKonva.KonvaClasses.Line;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Arrow
{
    /// <summary>
    /// IDK if its really inherited from line or from shape docs arent clear,
    /// <para/>
    /// Methods doesnt match even if docs say its line derivate
    /// </summary>
    public class KonvaArrowConfigsDTO : KonvaLineConfigsDTO
    {

        [JsonPropertyName("pointerLength")]
        public int? PointerLength { get; set; }

        [JsonPropertyName("pointerWidth")]
        public int? PointerWidth { get; set; }

        [JsonPropertyName("pointerAtBeginning")]
        public bool? PointerAtBeginning { get; set; }

        [JsonPropertyName("pointerAtEnding")]
        public bool? PointerAtEnding { get; set; }

    }
}