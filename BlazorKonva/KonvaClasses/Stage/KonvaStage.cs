using BlazorKonva.Helpers;
using BlazorKonva.KonvaClasses.Node;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Stage
{
    public class KonvaStage : KonvaNode
    {

        public KonvaStageConfigsDTO Configs { get; set; }
        public override KonvaNodeConfigsDTO CommonConfigs { get; set; }

        private IJSRuntime JS { get; set; }

        public KonvaStage SetJsRuntime(IJSRuntime JsRuntime)
        {
            JS = JsRuntime;
            return this;
        }

        public KonvaStage SetConfigs(KonvaStageConfigsDTO Data)
        {
            Configs = Data;
            CommonConfigs = Data;
            return this;
        }

        public async Task<KonvaStage> Build()
        {
            var args = JsonHelper.Serialize(Configs);
            var result = await JS.InvokeAsync<dynamic>("CustomKonvaWrapper.CreateStageFromJson", args);
            //Id = result;
            return this;
        }

        public async Task<bool> AddNode(KonvaNode Data)
        {
            var result = await JS.InvokeAsync<bool>("CustomKonvaWrapper.AddSubNode", this.Configs.Id, Data.CommonConfigs.Id);
            return result;
        }

    }
}
