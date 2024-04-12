﻿using BlazorKonva.KonvaClasses.Container;
using BlazorKonva.KonvaClasses.Layer;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Group
{
    public class KonvaGroup : KonvaContainer
    {

        private KonvaLayer ParentLayer { get; set; }

        public override KonvaGroup SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaGroup)base.SetJsRuntime(JsRuntime);
        }

        public KonvaGroup SetConfigs(KonvaGroupConfigsDTO Data)
        {
            return (KonvaGroup)base.SetConfigs(Data);
        }

        public KonvaGroup SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaGroupConfigsDTO GetCastedConfigs()
        {
            return (KonvaGroupConfigsDTO)Configs;
        }

        public async Task<KonvaGroup> Build()
        {
            return (KonvaGroup)(await base.Build("CreateGroupFromJson"));
        }

    }
}
