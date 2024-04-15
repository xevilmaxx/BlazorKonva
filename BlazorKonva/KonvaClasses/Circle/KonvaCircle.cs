using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Circle
{
    public class KonvaCircle : KonvaShape
    {

        public override KonvaCircle SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaCircle)base.SetJsRuntime(JsRuntime);
        }

        public KonvaCircle SetConfigs(KonvaCircleConfigsDTO Data)
        {
            return (KonvaCircle)base.SetConfigs(Data);
        }

        public KonvaCircle SetLayer(KonvaLayer Data)
        {
            base.SetParent(Data);
            return this;
        }

        public KonvaCircleConfigsDTO GetCastedConfigs()
        {
            return (KonvaCircleConfigsDTO)Configs;
        }

        public async Task<KonvaCircle> Build()
        {
            return (KonvaCircle)(await base.Build("CreateCircleFromJson"));
        }

    }
}
