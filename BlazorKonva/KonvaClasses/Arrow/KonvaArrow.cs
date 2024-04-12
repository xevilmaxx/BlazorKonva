﻿using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Line;
using Microsoft.JSInterop;

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
