using BlazorKonva.Helpers;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Stage
{
    public class KonvaStage
    {

        public KonvaStageConfigsDTO Configs { get; set; }

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

        public async Task<KonvaStage> Build()
        {
            var args = JsonHelper.Serialize(Configs);
            var result = await JS.InvokeAsync<dynamic>("CustomKonvaWrapper.CreateStageFromJson", args);
            //Id = result;
            return this;
        }

        public async Task<bool> AddNode()
        {
            var args = JsonHelper.Serialize(Configs);
            var result = await JS.InvokeAsync<dynamic>("CustomKonvaWrapper.CreateStageFromJson", args);
            //Id = result;
            return true;
        }

    }
}
