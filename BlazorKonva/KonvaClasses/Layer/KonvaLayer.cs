using BlazorKonva.Helpers;
using BlazorKonva.KonvaClasses.Stage;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Layer
{
    public class KonvaLayer
    {

        public KonvaLayerConfigsDTO Configs { get; set; }

        private IJSRuntime JS { get; set; }

        private KonvaStage ParentStage { get; set; }

        public KonvaLayer SetStage(KonvaStage Data)
        {
            ParentStage = Data;
            return this;
        }

        public KonvaLayer SetJsRuntime(IJSRuntime JsRuntime)
        {
            JS = JsRuntime;
            return this;
        }

        public KonvaLayer SetConfigs(KonvaLayerConfigsDTO Data)
        {
            Configs = Data;
            return this;
        }

        public async Task<KonvaLayer> Build()
        {
            var args = JsonHelper.Serialize(Configs);
            var result = await JS.InvokeAsync<dynamic>("CustomKonvaWrapper.CreateLayerFromJson", ParentStage.Configs.Id, args);
            //Id = result;
            return this;
        }

    }
}
