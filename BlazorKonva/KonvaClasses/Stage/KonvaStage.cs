using BlazorKonva.Helpers;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
            //var result = AsyncHelper.RunSync(async () => await JS.InvokeAsync<dynamic>("ExampleJsInterop.CreateStage", ContainerId, 100, 100));
            var args = JsonSerializer.Serialize(Configs, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
            var result = await JS.InvokeAsync<dynamic>("CustomKonvaWrapper.CreateStageFromJson", args);
            //Id = result;
            return this;
        }

    }
}
