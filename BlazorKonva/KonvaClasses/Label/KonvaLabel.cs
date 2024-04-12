using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Node;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Label
{
    public class KonvaLabel : KonvaNode
    {

        private KonvaLayer ParentLayer { get; set; }

        public override KonvaLabel SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaLabel)base.SetJsRuntime(JsRuntime);
        }

        public KonvaLabel SetConfigs(KonvaLabelConfigsDTO Data)
        {
            return (KonvaLabel)base.SetConfigs(Data);
        }

        public KonvaLabel SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaLabelConfigsDTO GetCastedConfigs()
        {
            return (KonvaLabelConfigsDTO)Configs;
        }

        public async Task<KonvaLabel> Build()
        {
            return (KonvaLabel)(await base.Build("CreateLabelFromJson"));
        }

    }
}
