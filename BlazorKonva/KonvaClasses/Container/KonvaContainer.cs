using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Node;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Container
{
    public class KonvaContainer : KonvaNode
    {

        public override KonvaContainer SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaContainer)base.SetJsRuntime(JsRuntime);
        }

        public KonvaContainer SetConfigs(KonvaContainerConfigsDTO Data)
        {
            return (KonvaContainer)base.SetConfigs(Data);
        }

        public KonvaContainer SetLayer(KonvaLayer Data)
        {
            base.SetParent(Data);
            return this;
        }

        public KonvaContainerConfigsDTO GetCastedConfigs()
        {
            return (KonvaContainerConfigsDTO)Configs;
        }

        public async Task<KonvaContainer> Build()
        {
            return (KonvaContainer)(await base.Build("CreateContainerFromJson"));
        }

    }
}
