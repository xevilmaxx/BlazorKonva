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

        public EventHandler OnMouseOverEvt { get; set; }
        public EventHandler OnMouseOutEvt { get; set; }

        private Layer.Layer ParentLayer { get; set; }

        public Rect SetLayer(Layer.Layer Data)
        {
            ParentLayer = Data;
            return this;
        }

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
            var result = await JS.InvokeAsync<dynamic>("CustomKonvaWrapper.CreateRectFromJson", ParentLayer.Configs.Id, JSHandler, args);
            //Id = result;
            return this;
        }

        /// <summary>
        /// Only public modifier works, private and others dont, and attribute MUST be specified
        /// </summary>
        [JSInvokable]
        public void JsOnMouseOver()
        {
            OnMouseOverEvt?.Invoke(this, null);
        }

        /// <summary>
        /// Only public modifier works, private and others dont, and attribute MUST be specified
        /// </summary>
        [JSInvokable]
        public void JsOnMouseOut()
        {
            OnMouseOutEvt?.Invoke(this, null);
        }

    }
}
