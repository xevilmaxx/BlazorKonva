using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Sprite
{
    /// <summary>
    /// TODO
    /// </summary>
    public class KonvaSprite : KonvaShape
    {

        public override KonvaSprite SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaSprite)base.SetJsRuntime(JsRuntime);
        }

        public KonvaSprite SetConfigs(KonvaSpriteConfigsDTO Data)
        {
            return (KonvaSprite)base.SetConfigs(Data);
        }

        public KonvaSprite SetLayer(KonvaLayer Data)
        {
            base.SetParent(Data);
            return this;
        }

        public KonvaSpriteConfigsDTO GetCastedConfigs()
        {
            return (KonvaSpriteConfigsDTO)Configs;
        }

        public async Task<KonvaSprite> Build()
        {
            //TODO
            return (KonvaSprite)(await base.Build("CreateSpriteFromJson"));
        }

    }
}
