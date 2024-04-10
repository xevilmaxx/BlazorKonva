using BlazorKonva.KonvaClasses.Layer;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Rect
{
    public class Rect
    {

        public RectConfigsDTO Configs { get; set; }

        private IJSRuntime JS { get; set; }

        public Rect SetJsRuntime(IJSRuntime JsRuntime)
        {
            JS = JsRuntime;
            return this;
        }

        public Rect SetConfigs(RectConfigsDTO Data)
        {
            Configs = Data;
            return this;
        }

        public async Task<Rect> Build()
        {
            //var result = AsyncHelper.RunSync(async () => await JS.InvokeAsync<dynamic>("ExampleJsInterop.CreateStage", ContainerId, 100, 100));
            var args = JsonSerializer.Serialize(Configs, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
            var JSHandler = DotNetObjectReference.Create(this);
            var result = await JS.InvokeAsync<dynamic>("ExampleJsInterop.CreateRectFromJson", JSHandler, args);
            //Id = result;
            return this;
        }

        [JSInvokable]
        public void OnMouseOver()
        {

        }


        [JSInvokable]
        public void OnMouseOut()
        {

        }

    }
}
