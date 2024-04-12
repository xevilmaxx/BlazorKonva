﻿using BlazorKonva.KonvaClasses.Circle;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Ring
{
    public class KonvaRing : KonvaShape
    {

        private KonvaLayer ParentLayer { get; set; }

        public override KonvaRing SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaRing)base.SetJsRuntime(JsRuntime);
        }

        public KonvaRing SetConfigs(KonvaRingConfigsDTO Data)
        {
            return (KonvaRing)base.SetConfigs(Data);
        }

        public KonvaRing SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaRingConfigsDTO GetCastedConfigs()
        {
            return (KonvaRingConfigsDTO)Configs;
        }

        public async Task<KonvaRing> Build()
        {
            return (KonvaRing)(await base.Build("CreateRingFromJson"));
        }

    }
}
