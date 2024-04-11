using BlazorKonva.KonvaClasses.Node;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Layer
{
    public class KonvaAnimation : KonvaNode
    {

        public override KonvaAnimation SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaAnimation)base.SetJsRuntime(JsRuntime);
        }

        public KonvaAnimation SetConfigs(KonvaAnimationConfigsDTO Data)
        {
            return (KonvaAnimation)base.SetConfigs(Data);
        }

        /// <summary>
        /// Will return whole configs as correct to the class
        /// </summary>
        /// <returns></returns>
        public KonvaAnimationConfigsDTO GetCastedConfigs()
        {
            return (KonvaAnimationConfigsDTO)Configs;
        }

        public async Task<KonvaAnimation> Build()
        {
            return (KonvaAnimation)(await base.Build("CreateAnimationFromJson"));
        }

    }
}
