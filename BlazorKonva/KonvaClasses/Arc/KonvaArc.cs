using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Arc
{
    public class KonvaArc : KonvaShape
    {

        private KonvaLayer ParentLayer { get; set; }

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
            ParentLayer = Data;
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
