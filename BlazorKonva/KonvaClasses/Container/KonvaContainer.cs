using BlazorKonva.KonvaClasses.Circle;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Node;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Container
{
    public class KonvaContainer : KonvaNode
    {

        private KonvaLayer ParentLayer { get; set; }

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
            ParentLayer = Data;
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
