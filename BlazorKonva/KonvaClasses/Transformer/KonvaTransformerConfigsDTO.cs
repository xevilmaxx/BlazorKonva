﻿using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Transformer
{
    public class KonvaTransformerConfigsDTO
    {

        [JsonPropertyName("resizeEnabled")]
        public bool? ResizeEnabled { get; set; }

        [JsonPropertyName("rotateEnabled")]
        public bool? RotateEnabled { get; set; }

        [JsonPropertyName("rotateLineVisible")]
        public bool? RotateLineVisible { get; set; }

        [JsonPropertyName("rotationSnaps")]
        public double[]? RotationSnaps { get; set; }

        [JsonPropertyName("rotationSnapTolerance")]
        public double? RotationSnapTolerance { get; set; }

        [JsonPropertyName("rotateAnchorOffset")]
        public double? RotateAnchorOffset { get; set; }

        [JsonPropertyName("rotateAnchorCursor")]
        public string? RotateAnchorCursor { get; set; }

        [JsonPropertyName("padding")]
        public double? Padding { get; set; }

        [JsonPropertyName("borderEnabled")]
        public bool? BorderEnabled { get; set; }

        [JsonPropertyName("borderStroke")]
        public string? BorderStroke { get; set; }

        [JsonPropertyName("borderStrokeWidth")]
        public double? BorderStrokeWidth { get; set; }

        [JsonPropertyName("borderDash")]
        public double[]? BorderDash { get; set; }

        [JsonPropertyName("anchorFill")]
        public string? AnchorFill { get; set; }

        [JsonPropertyName("anchorStroke")]
        public string? AnchorStroke { get; set; }

        [JsonPropertyName("anchorCornerRadius")]
        public string? AnchorCornerRadius { get; set; }

        [JsonPropertyName("anchorStrokeWidth")]
        public double? AnchorStrokeWidth { get; set; }

        [JsonPropertyName("anchorSize")]
        public double? AnchorSize { get; set; }

        [JsonPropertyName("keepRatio")]
        public bool? KeepRatio { get; set; }

        [JsonPropertyName("shiftBehavior")]
        public string? ShiftBehavior { get; set; }

        [JsonPropertyName("centeredScaling")]
        public bool? CenteredScaling { get; set; }

        [JsonPropertyName("enabledAnchors")]
        public string[]? EnabledAnchors { get; set; }

        [JsonPropertyName("flipEnabled")]
        public bool? FlipEnabled { get; set; }

        /// <summary>
        /// Custom Javascript function to execute for each frame of the animation
        /// <para/>
        /// I dont think you can writea javascript func in c# and auto-translate into javascript easily
        /// <para/>
        /// so will leave it as string where you can eventually inject a javascript function
        /// </summary>
        [JsonPropertyName("boundBoxFunc")]
        public string? BoundBoxFunc { get; set; }

        /// <summary>
        /// Custom Javascript function to execute for each frame of the animation
        /// <para/>
        /// I dont think you can writea javascript func in c# and auto-translate into javascript easily
        /// <para/>
        /// so will leave
        [JsonPropertyName("ignoreStroke")]
        public string? IgnoreStroke { get; set; }

        [JsonPropertyName("useSingleNodeRotation")]
        public bool? UseSingleNodeRotation { get; set; }

        [JsonPropertyName("shouldOverdrawWholeArea")]
        public bool? ShouldOverdrawWholeArea { get; set; }

    }
}
