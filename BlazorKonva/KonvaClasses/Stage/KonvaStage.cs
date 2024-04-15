using BlazorKonva.Helpers;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Node;
using Microsoft.JSInterop;
using System.Reflection;

namespace BlazorKonva.KonvaClasses.Stage
{
    public class KonvaStage : KonvaNode
    {

        public override KonvaStage SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaStage)base.SetJsRuntime(JsRuntime);
        }

        public KonvaStage SetConfigs(KonvaStageConfigsDTO Data)
        {
            return (KonvaStage)base.SetConfigs(Data);
        }

        public KonvaStageConfigsDTO GetCastedConfigs()
        {
            return (KonvaStageConfigsDTO)Configs;
        }

        public async Task<KonvaStage> Build()
        {
            return (KonvaStage)(await base.Build("CreateStageFromJson"));
        }

        public async Task<KonvaLayer> AddLayer(KonvaLayerConfigsDTO Data)
        {
            var layer = await new KonvaLayer()
                .SetJsRuntime(JS)
                .SetStage(this)
                .SetConfigs(Data)
                .Build();

            var result = await AddNode(layer);

            return layer;
        }

        public async Task<KonvaStage> AttachZoomOnMouseWheel(double? ScaleFactor = null)
        {

            var result = await JS.InvokeAsync<dynamic>($"CustomKonvaWrapperExtensions.AttachZoomOnStage", Configs.Id, ScaleFactor);

            return this;

        }

        public async Task<KonvaStage> DetachZoomOnMouseWheel()
        {

            var result = await JS.InvokeAsync<dynamic>($"CustomKonvaWrapperExtensions.DetachZoomOnStage", Configs.Id);

            return this;

        }

    }
}
