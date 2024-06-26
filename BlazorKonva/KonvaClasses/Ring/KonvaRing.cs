﻿using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Ring
{
    public class KonvaRing : KonvaShape
    {

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
            base.SetParent(Data);
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
