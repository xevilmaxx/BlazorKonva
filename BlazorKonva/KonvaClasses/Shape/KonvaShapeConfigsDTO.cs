using BlazorKonva.KonvaClasses.Node;
using BlazorKonva.KonvaCommonDTO;
using System.Drawing;
using System.Text.Json.Serialization;

namespace BlazorKonva.KonvaClasses.Shape
{
    public class KonvaShapeConfigsDTO : KonvaNodeConfigsDTO
    {

        [JsonPropertyName("fill")]
        public string? Fill { get; set; }

        [JsonPropertyName("fillPatternImage")]
        public object? FillPatternImage { get; set; }

        [JsonPropertyName("fillPatternX")]
        public int? FillPatternX { get; set; }

        [JsonPropertyName("fillPatternY")]
        public int? FillPatternY { get; set; }

        [JsonPropertyName("fillPatternOffset")]
        public KonvaOffsetDTO? FillPatternOffset { get; set; }

        [JsonPropertyName("fillPatternOffsetX")]
        public int? FillPatternOffsetX { get; set; }

        [JsonPropertyName("fillPatternOffsetY")]
        public int? FillPatternOffsetY { get; set; }

        [JsonPropertyName("fillPatternScale")]
        public KonvaScaleDTO? FillPatternScale { get; set; }

        [JsonPropertyName("fillPatternScaleX")]
        public int? FillPatternScaleX { get; set; }

        [JsonPropertyName("fillPatternScaleY")]
        public int? FillPatternScaleY { get; set; }

        [JsonPropertyName("fillPatternRotation")]
        public int? FillPatternRotation { get; set; }

        /// <summary>
        /// "repeat", "repeat-x", "repeat-y", or "no-repeat". The default is "no-repeat"
        /// </summary>
        [JsonPropertyName("fillPatternRepeat")]
        public string? FillPatternRepeat { get; set; }

        [JsonPropertyName("FillLinearGradientStartPoint")]
        public KonvaFillLinearGradientDTO? FillLinearGradientStartPoint { get; set; }

        [JsonPropertyName("fillLinearGradientStartPointX")]
        public int? FillLinearGradientStartPointX { get; set; }

        [JsonPropertyName("fillLinearGradientStartPointY")]
        public int? FillLinearGradientStartPointY { get; set; }

        [JsonPropertyName("fillLinearGradientEndPoint")]
        public KonvaFillLinearGradientDTO? FillLinearGradientEndPoint { get; set; }

        [JsonPropertyName("fillLinearGradientEndPointX")]
        public double? FillLinearGradientEndPointX { get; set; }

        [JsonPropertyName("fillLinearGradientEndPointY")]
        public double? FillLinearGradientEndPointY { get; set; }

        [JsonPropertyName("fillLinearGradientColorStops")]
        public KonvaFillRadialGradientDTO[]? FillLinearGradientColorStops { get; set; }

        [JsonPropertyName("fillRadialGradientStartPoint")]
        public KonvaFillRadialGradientDTO? FillRadialGradientStartPoint { get; set; }

        [JsonPropertyName("fillRadialGradientStartPointX")]
        public double? FillRadialGradientStartPointX { get; set; }

        [JsonPropertyName("fillRadialGradientStartPointY")]
        public double? FillRadialGradientStartPointY { get; set; }

        [JsonPropertyName("fillRadialGradientEndPoint")]
        public KonvaFillRadialGradientDTO? FillRadialGradientEndPoint { get; set; }

        [JsonPropertyName("fillRadialGradientEndPointX")]
        public double? FillRadialGradientEndPointX { get; set; }

        [JsonPropertyName("fillRadialGradientEndPointY")]
        public double? FillRadialGradientEndPointY { get; set; }

        [JsonPropertyName("fillRadialGradientStartRadius")]
        public double? FillRadialGradientStartRadius { get; set; }

        [JsonPropertyName("fillRadialGradientEndRadius")]
        public double? FillRadialGradientEndRadius { get; set; }

        [JsonPropertyName("fillRadialGradientColorStops")]
        public KonvaFillRadialGradientDTO[]? FillRadialGradientColorStops { get; set; }

        [JsonPropertyName("fillEnabled")]
        public bool? FillEnabled { get; set; }

        [JsonPropertyName("fillPriority")]
        public string? FillPriority { get; set; } = "color";

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
        public int? ShadowBlur { get; set; }

        [JsonPropertyName("shadowOffset")]
        public KonvaShadowOffsetDTO? ShadowOffset { get; set; }

        [JsonPropertyName("shadowOffsetX")]
        public int? ShadowOffsetX { get; set; }

        [JsonPropertyName("shadowOffsetY")]
        public int? ShadowOffsetY { get; set; }

        [JsonPropertyName("shadowOpacity")]
        public double? ShadowOpacity { get; set; }

        [JsonPropertyName("shadowEnabled")]
        public bool? ShadowEnabled { get; set; }

        [JsonPropertyName("dash")]
        public double[]? Dash { get; set; }

        [JsonPropertyName("dashEnabled")]
        public bool? DashEnabled { get; set; }

    }
}
