using BlazorKonva.Helpers;
using BlazorKonva.KonvaClasses.Node;
using BlazorKonva.KonvaClasses.Stage;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Layer
{
    public class KonvaLayer : KonvaNode
    {

        public override KonvaNodeConfigsDTO Configs { get; set; }

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

        /// <summary>
        /// Will return whole configs as correct to the class
        /// </summary>
        /// <returns></returns>
        public KonvaLayerConfigsDTO GetCastedConfigs()
        {
            return (KonvaLayerConfigsDTO)Configs;
        }

        public async Task<KonvaLayer> Build()
        {
            var args = JsonHelper.Serialize(Configs);
            var result = await JS.InvokeAsync<dynamic>("CustomKonvaWrapper.CreateLayerFromJson", ParentStage.Configs.Id, args);
            //Id = result;
            return this;
        }

        public async Task<bool> AddNode(KonvaNode Data)
        {
            var args = JsonHelper.Serialize(Configs);
            var result = await JS.InvokeAsync<bool>("CustomKonvaWrapper.AddSubNode", this.Configs.Id, Data.Configs.Id);
            return result;
        }

    }
}
