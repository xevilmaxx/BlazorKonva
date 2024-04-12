using BlazorKonva.KonvaClasses.Circle;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Line;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Arrow
{
    public class KonvaArrow : KonvaLine
    {

        private KonvaLayer ParentLayer { get; set; }

        public override KonvaArrow SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaArrow)base.SetJsRuntime(JsRuntime);
        }

        public KonvaArrow SetConfigs(KonvaArrowConfigsDTO Data)
        {
            return (KonvaArrow)base.SetConfigs(Data);
        }

        public KonvaArrow SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaArrowConfigsDTO GetCastedConfigs()
        {
            return (KonvaArrowConfigsDTO)Configs;
        }

        public async Task<KonvaArrow> Build()
        {
            return (KonvaArrow)(await base.Build("CreateArrowFromJson"));
        }

    }
}
