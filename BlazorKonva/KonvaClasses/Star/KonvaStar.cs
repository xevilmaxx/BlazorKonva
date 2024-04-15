using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Star
{
    public class KonvaStar : KonvaShape
    {

        public override KonvaStar SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaStar)base.SetJsRuntime(JsRuntime);
        }

        public KonvaStar SetConfigs(KonvaStarConfigsDTO Data)
        {
            return (KonvaStar)base.SetConfigs(Data);
        }

        public KonvaStar SetLayer(KonvaLayer Data)
        {
            base.SetParent(Data);
            return this;
        }

        public KonvaStarConfigsDTO GetCastedConfigs()
        {
            return (KonvaStarConfigsDTO)Configs;
        }

        public async Task<KonvaStar> Build()
        {
            return (KonvaStar)(await base.Build("CreateStarFromJson"));
        }

    }
}
