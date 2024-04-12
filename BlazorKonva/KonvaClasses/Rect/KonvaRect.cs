using BlazorKonva.Enums;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Rect
{
    public class KonvaRect : KonvaShape
    {

        public EventHandler OnMouseOver { get; set; }
        public EventHandler OnMouseOut { get; set; }

        private KonvaLayer ParentLayer { get; set; }

        public override KonvaRect SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaRect)base.SetJsRuntime(JsRuntime);
        }

        public KonvaRect SetConfigs(KonvaRectConfigsDTO Data)
        {
            return (KonvaRect)base.SetConfigs(Data);
        }

        public KonvaRect SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaRectConfigsDTO GetCastedConfigs()
        {
            return (KonvaRectConfigsDTO)Configs;
        }

        public async Task<KonvaRect> Build()
        {
            //return (KonvaRect)(await base.Build("CreateRectFromJson", ParentLayer.Configs.Id));
            return (KonvaRect)(await base.Build("CreateRectFromJson"));
        }

        public async Task<bool> ListenForEvents()
        {
            var JSHandler = DotNetObjectReference.Create(this);

            var result = await base.SubscribeToJsEvent(KonvaJsEvent.Mouseover, JSHandler, nameof(JsOnMouseOver));
            var result2 = await base.SubscribeToJsEvent(KonvaJsEvent.Mouseout, JSHandler, nameof(JsOnMouseOut));

            //var result = await JS.InvokeAsync<bool>("CustomKonvaWrapper.SubscribeEvent", Configs.Id, KonvaJsEvent.Mouseover, JSHandler, nameof(JsOnMouseOver));
            //var result2 = await JS.InvokeAsync<bool>("CustomKonvaWrapper.SubscribeEvent", Configs.Id, KonvaJsEvent.Mouseout, JSHandler, nameof(JsOnMouseOut));
            //Id = result;

            return result && result2;
        }

        /// <summary>
        /// Only public modifier works, private and others dont, and attribute MUST be specified
        /// </summary>
        [JSInvokable]
        public void JsOnMouseOver()
        {
            OnMouseOver?.Invoke(this, null);
        }

        /// <summary>
        /// Only public modifier works, private and others dont, and attribute MUST be specified
        /// </summary>
        [JSInvokable]
        public void JsOnMouseOut()
        {
            OnMouseOut?.Invoke(this, null);
        }

    }
}
