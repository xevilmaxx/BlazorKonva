﻿using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Path
{
    public class KonvaPath : KonvaShape
    {

        private KonvaLayer ParentLayer { get; set; }

        public override KonvaPath SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaPath)base.SetJsRuntime(JsRuntime);
        }

        public KonvaPath SetConfigs(KonvaPathConfigsDTO Data)
        {
            return (KonvaPath)base.SetConfigs(Data);
        }

        public KonvaPath SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaPathConfigsDTO GetCastedConfigs()
        {
            return (KonvaPathConfigsDTO)Configs;
        }

        public async Task<KonvaPath> Build()
        {
            return (KonvaPath)(await base.Build("CreatePathFromJson"));
        }

    }
}