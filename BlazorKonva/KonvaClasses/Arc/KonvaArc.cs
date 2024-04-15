using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Arc
{
    public class KonvaArc : KonvaShape
    {

        public override KonvaArc SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaArc)base.SetJsRuntime(JsRuntime);
        }

        public KonvaArc SetConfigs(KonvaArcConfigsDTO Data)
        {
            return (KonvaArc)base.SetConfigs(Data);
        }

        public KonvaArc SetLayer(KonvaLayer Data)
        {
            base.SetParent(Data);
            return this;
        }

        public KonvaArcConfigsDTO GetCastedConfigs()
        {
            return (KonvaArcConfigsDTO)Configs;
        }

        public async Task<KonvaArc> Build()
        {
            return (KonvaArc)(await base.Build("CreateArcFromJson"));
        }

    }
}
