using BlazorKonva.KonvaClasses.Stage;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
            //var result = AsyncHelper.RunSync(async () => await JS.InvokeAsync<dynamic>("ExampleJsInterop.CreateStage", ContainerId, 100, 100));
            var args = JsonSerializer.Serialize(Configs, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
            var result = await JS.InvokeAsync<dynamic>("CustomKonvaWrapper.CreateLayerFromJson", ParentStage.Configs.Id, args);
            //Id = result;
            return this;
        }

    }
}
