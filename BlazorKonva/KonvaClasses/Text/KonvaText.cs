using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Text
{
    public class KonvaText : KonvaShape
    {

        public override KonvaText SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaText)base.SetJsRuntime(JsRuntime);
        }

        public KonvaText SetConfigs(KonvaTextConfigsDTO Data)
        {
            return (KonvaText)base.SetConfigs(Data);
        }

        public KonvaText SetLayer(KonvaLayer Data)
        {
            base.SetParent(Data);
            return this;
        }

        public KonvaTextConfigsDTO GetCastedConfigs()
        {
            return (KonvaTextConfigsDTO)Configs;
        }

        public async Task<KonvaText> Build()
        {
            return (KonvaText)(await base.Build("CreateTextFromJson"));
        }

    }
}
