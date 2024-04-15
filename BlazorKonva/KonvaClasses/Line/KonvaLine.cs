using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Line
{
    public class KonvaLine : KonvaShape
    {

        public override KonvaLine SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaLine)base.SetJsRuntime(JsRuntime);
        }

        public KonvaLine SetConfigs(KonvaLineConfigsDTO Data)
        {
            return (KonvaLine)base.SetConfigs(Data);
        }

        public KonvaLine SetLayer(KonvaLayer Data)
        {
            base.SetParent(Data);
            return this;
        }

        public KonvaLineConfigsDTO GetCastedConfigs()
        {
            return (KonvaLineConfigsDTO)Configs;
        }

        public async Task<KonvaLine> Build()
        {
            return (KonvaLine)(await base.Build("CreateLineFromJson"));
        }

    }
}
