using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Star
{
    public class KonvaStar : KonvaShape
    {

        private KonvaLayer ParentLayer { get; set; }

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
            ParentLayer = Data;
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
