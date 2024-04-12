﻿using BlazorKonva.KonvaClasses.Circle;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.TextPath
{
    public class KonvaTextPath : KonvaShape
    {

        private KonvaLayer ParentLayer { get; set; }

        public override KonvaTextPath SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaTextPath)base.SetJsRuntime(JsRuntime);
        }

        public KonvaTextPath SetConfigs(KonvaTextPathConfigsDTO Data)
        {
            return (KonvaTextPath)base.SetConfigs(Data);
        }

        public KonvaTextPath SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaTextPathConfigsDTO GetCastedConfigs()
        {
            return (KonvaTextPathConfigsDTO)Configs;
        }

        public async Task<KonvaTextPath> Build()
        {
            return (KonvaTextPath)(await base.Build("CreateTextPathFromJson"));
        }

    }
}
