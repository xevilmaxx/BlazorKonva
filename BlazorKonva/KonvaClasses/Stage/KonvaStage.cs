using BlazorKonva.Helpers;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Node;
using BlazorKonva.KonvaClasses.Rect;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Stage
{
    public class KonvaStage : KonvaNode
    {

        public override KonvaNodeConfigsDTO Configs { get; set; }

        private IJSRuntime JS { get; set; }

        public KonvaStage SetJsRuntime(IJSRuntime JsRuntime)
        {
            JS = JsRuntime;
            return this;
        }

        public KonvaStage SetConfigs(KonvaStageConfigsDTO Data)
        {
            Configs = Data;
            return this;
        }

        public KonvaStageConfigsDTO GetCastedConfigs()
        {
            return (KonvaStageConfigsDTO)Configs;
        }

        public async Task<KonvaStage> Build()
        {
            var args = JsonHelper.Serialize(Configs);
            var result = await JS.InvokeAsync<dynamic>("CustomKonvaWrapper.CreateStageFromJson", args);
            //Id = result;
            return this;
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

        public async Task<bool> AddNode(KonvaNode Data)
        {
            var result = await JS.InvokeAsync<bool>("CustomKonvaWrapper.AddSubNode", this.Configs.Id, Data.Configs.Id);
            return result;
        }

    }
}
