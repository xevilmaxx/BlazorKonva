using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Wedge
{
    public class KonvaWedge : KonvaShape
    {

        public override KonvaWedge SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaWedge)base.SetJsRuntime(JsRuntime);
        }

        public KonvaWedge SetConfigs(KonvaWedgeConfigsDTO Data)
        {
            return (KonvaWedge)base.SetConfigs(Data);
        }

        public KonvaWedge SetLayer(KonvaLayer Data)
        {
            base.SetParent(Data);
            return this;
        }

        public KonvaWedgeConfigsDTO GetCastedConfigs()
        {
            return (KonvaWedgeConfigsDTO)Configs;
        }

        public async Task<KonvaWedge> Build()
        {
            return (KonvaWedge)(await base.Build("CreateWedgeFromJson"));
        }

    }
}
