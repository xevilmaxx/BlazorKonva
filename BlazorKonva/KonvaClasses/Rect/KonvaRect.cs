using BlazorKonva.Enums;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Rect
{
    public class KonvaRect : KonvaShape
    {

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
            base.SetParent(Data);
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

            var result = await base.SubscribeToJsEvent(KonvaJsEvent.Mouseover);
            var result2 = await base.SubscribeToJsEvent(KonvaJsEvent.Mouseout);
            _ = await base.SubscribeToJsEvent(KonvaJsEvent.Click);
            _ = await base.SubscribeToJsEvent(KonvaJsEvent.Contextmenu);

            //var result = await JS.InvokeAsync<bool>("CustomKonvaWrapper.SubscribeEvent", Configs.Id, KonvaJsEvent.Mouseover, JSHandler, nameof(JsOnMouseOver));
            //var result2 = await JS.InvokeAsync<bool>("CustomKonvaWrapper.SubscribeEvent", Configs.Id, KonvaJsEvent.Mouseout, JSHandler, nameof(JsOnMouseOut));
            //Id = result;

            return result && result2;
        }

    }
}
