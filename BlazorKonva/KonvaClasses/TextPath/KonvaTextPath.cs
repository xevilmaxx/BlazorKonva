using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.TextPath
{
    public class KonvaTextPath : KonvaShape
    {

        public override KonvaTextPath SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaTextPath)base.SetJsRuntime(JsRuntime);
        }

        public KonvaTextPath SetConfigs(KonvaTextPathConfigsDTO Data)
        {
            return (KonvaTextPath)base.SetConfigs(Data);
        }

        public KonvaTextPath SetLayer(KonvaLayer Data)
        {
            base.SetParent(Data);
            return this;
        }

        public KonvaTextPathConfigsDTO GetCastedConfigs()
        {
            return (KonvaTextPathConfigsDTO)Configs;
        }

        public async Task<KonvaTextPath> Build()
        {
            return (KonvaTextPath)(await base.Build("CreateTextPathFromJson"));
        }

    }
}
