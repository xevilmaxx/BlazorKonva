using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Rect
{
    public class KonvaRectConfigsDTO
    {
        [JsonPropertyName("cornerRadius")]
        public double? CornerRadius { get; set; } // Nullable double

        [JsonPropertyName("fill")]
        public string? Fill { get; set; } // String (fill color)

        [JsonPropertyName("fillPatternImage")]
        public object? FillPatternImage { get; set; } // Image (fill pattern image)

        [JsonPropertyName("fillPatternX")]
        public double? FillPatternX { get; set; } // Nullable double

        [JsonPropertyName("fillPatternY")]
        public double? FillPatternY { get; set; } // Nullable double

        [JsonPropertyName("fillPatternOffset")]
        public object? FillPatternOffset { get; set; } // Nested object for fill pattern offset

        [JsonPropertyName("fillPatternOffsetX")]
        public double? FillPatternOffsetX { get; set; } // Nullable double (alternative to FillPatternOffset)

        [JsonPropertyName("fillPatternOffsetY")]
        public double? FillPatternOffsetY { get; set; } // Nullable double (alternative to FillPatternOffset)

        [JsonPropertyName("fillPatternScale")]
        public object? FillPatternScale { get; set; } // Nested object for fill pattern scale

        [JsonPropertyName("fillPatternScaleX")]
        public double? FillPatternScaleX { get; set; } // Nullable double (alternative to FillPatternScale)

        [JsonPropertyName("fillPatternScaleY")]
        public double? FillPatternScaleY { get; set; } // Nullable double (alternative to FillPatternScale)

        [JsonPropertyName("fillPatternRotation")]
        public double? FillPatternRotation { get; set; } // Nullable double

        [JsonPropertyName("fillPatternRepeat")]
        public string? FillPatternRepeat { get; set; } // String (repeat options)

        [JsonPropertyName("fillLinearGradientStartPoint")]
        public object? FillLinearGradientStartPoint { get; set; } // Nested object for fill linear gradient start point

        [JsonPropertyName("fillLinearGradientStartPointX")]
        public double? FillLinearGradientStartPointX { get; set; } // Nullable double (alternative to FillLinearGradientStartPoint)

        [JsonPropertyName("fillLinearGradientStartPointY")]
        public double? FillLinearGradientStartPointY { get; set; } // Nullable double (alternative to FillLinearGradientStartPoint)

        [JsonPropertyName("fillLinearGradientEndPoint")]
        public object? FillLinearGradientEndPoint { get; set; } // Nested object for fill linear gradient end point

        [JsonPropertyName("fillLinearGradientEndPointX")]
        public double? FillLinearGradientEndPointX { get; set; } // Nullable double (alternative to FillLinearGradientEndPoint)

        [JsonPropertyName("fillLinearGradientEndPointY")]
        public double? FillLinearGradientEndPointY { get; set; } // Nullable double (alternative to FillLinearGradientEndPoint)

        [JsonPropertyName("fillLinearGradientColorStops")]
        public object[]? FillLinearGradientColorStops { get; set; } // Array of color stops

        [JsonPropertyName("fillRadialGradientStartPoint")]
        public object? FillRadialGradientStartPoint { get; set; } // Nested object for fill radial gradient start point

        [JsonPropertyName("fillRadialGradientStartPointX")]
        public double? FillRadialGradientStartPointX { get; set; } // Nullable double (alternative to FillRadialGradientStartPoint)

        [JsonPropertyName("fillRadialGradientStartPointY")]
        public double? FillRadialGradientStartPointY { get; set; } // Nullable double (alternative to FillRadialGradientStartPoint)

        [JsonPropertyName("fillRadialGradientEndPoint")]
        public object? FillRadialGradientEndPoint { get; set; } // Nested object for fill radial gradient end point

        [JsonPropertyName("fillRadialGradientEndPointX")]
        public double? FillRadialGradientEndPointX { get; set; } // Nullable double (alternative to FillRadialGradientEndPoint)

        [JsonPropertyName("fillRadialGradientEndPointY")]
        public double? FillRadialGradientEndPointY { get; set; } // Nullable double (alternative to FillRadialGradientEndPoint)

        [JsonPropertyName("fillRadialGradientStartRadius")]
        public double? FillRadialGradientStartRadius { get; set; } // Nullable double

        [JsonPropertyName("fillRadialGradientEndRadius")]
        public double? FillRadialGradientEndRadius { get; set; } // Nullable double

        [JsonPropertyName("fillRadialGradientColorStops")]
        public object[]? FillRadialGradientColorStops { get; set; } // Array of color stops

        [JsonPropertyName("fillEnabled")]
        public bool? FillEnabled { get; set; }

        [JsonPropertyName("fillPriority")]
        public string? FillPriority { get; set; }

        [JsonPropertyName("stroke")]
        public string? Stroke { get; set; }

        [JsonPropertyName("strokeWidth")]
        public double? StrokeWidth { get; set; }

        [JsonPropertyName("fillAfterStrokeEnabled")]
        public bool? FillAfterStrokeEnabled { get; set; }

        [JsonPropertyName("hitStrokeWidth")]
        public double? HitStrokeWidth { get; set; }

        [JsonPropertyName("strokeHitEnabled")]
        public bool? StrokeHitEnabled { get; set; }

        [JsonPropertyName("perfectDrawEnabled")]
        public bool? PerfectDrawEnabled { get; set; }

        [JsonPropertyName("shadowForStrokeEnabled")]
        public bool? ShadowForStrokeEnabled { get; set; }

        [JsonPropertyName("strokeScaleEnabled")]
        public bool? StrokeScaleEnabled { get; set; }

        [JsonPropertyName("strokeEnabled")]
        public bool? StrokeEnabled { get; set; }

        [JsonPropertyName("lineJoin")]
        public string? LineJoin { get; set; }

        [JsonPropertyName("lineCap")]
        public string? LineCap { get; set; }

        [JsonPropertyName("shadowColor")]
        public string? ShadowColor { get; set; }

        [JsonPropertyName("shadowBlur")]
        public double? ShadowBlur { get; set; }

        [JsonPropertyName("shadowOffset")]
        public object? ShadowOffset { get; set; }

        [JsonPropertyName("shadowOpacity")]
        public double? ShadowOpacity { get; set; }

        [JsonPropertyName("shadowEnabled")]
        public bool? ShadowEnabled { get; set; }

        [JsonPropertyName("dashEnabled")]
        public bool? DashEnabled { get; set; }

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

        [JsonPropertyName("rotation")]
        public double? Rotation { get; set; }

        [JsonPropertyName("offset")]
        public object? Offset { get; set; }

        [JsonPropertyName("draggable")]
        public bool? Draggable { get; set; }

        [JsonPropertyName("dragDistance")]
        public double? DragDistance { get; set; }
    }
}
