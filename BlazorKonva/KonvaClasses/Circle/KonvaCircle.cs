using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Node;
using BlazorKonva.KonvaClasses.Rect;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Circle
{
    public class KonvaCircle : KonvaShape
    {

        private KonvaLayer ParentLayer { get; set; }

        public override KonvaCircle SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaCircle)base.SetJsRuntime(JsRuntime);
        }

        public KonvaCircle SetConfigs(KonvaCircleConfigsDTO Data)
        {
            return (KonvaCircle)base.SetConfigs(Data);
        }

        public KonvaCircle SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaCircleConfigsDTO GetCastedConfigs()
        {
            return (KonvaCircleConfigsDTO)Configs;
        }

        public async Task<KonvaCircle> Build()
        {
            return (KonvaCircle)(await base.Build("CreateCircleFromJson"));
        }

    }
}
