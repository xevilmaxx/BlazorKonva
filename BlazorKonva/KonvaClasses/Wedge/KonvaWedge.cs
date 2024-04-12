using BlazorKonva.KonvaClasses.Circle;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Wedge
{
    public class KonvaWedge : KonvaShape
    {

        private KonvaLayer ParentLayer { get; set; }

        public override KonvaWedge SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaWedge)base.SetJsRuntime(JsRuntime);
        }

        public KonvaWedge SetConfigs(KonvaWedgeConfigsDTO Data)
        {
            return (KonvaWedge)base.SetConfigs(Data);
        }

        public KonvaWedge SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaWedgeConfigsDTO GetCastedConfigs()
        {
            return (KonvaWedgeConfigsDTO)Configs;
        }

        public async Task<KonvaWedge> Build()
        {
            return (KonvaWedge)(await base.Build("CreateWedgeFromJson"));
        }

    }
}
