﻿using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.RegularPolygon
{
    public class KonvaRegularPolygon : KonvaShape
    {

        public override KonvaRegularPolygon SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaRegularPolygon)base.SetJsRuntime(JsRuntime);
        }

        public KonvaRegularPolygon SetConfigs(KonvaRegularPolygonConfigsDTO Data)
        {
            return (KonvaRegularPolygon)base.SetConfigs(Data);
        }

        public KonvaRegularPolygon SetLayer(KonvaLayer Data)
        {
            base.SetParent(Data);
            return this;
        }

        public KonvaRegularPolygonConfigsDTO GetCastedConfigs()
        {
            return (KonvaRegularPolygonConfigsDTO)Configs;
        }

        public async Task<KonvaRegularPolygon> Build()
        {
            return (KonvaRegularPolygon)(await base.Build("CreateRegularPolygonFromJson"));
        }

    }
}
