using BlazorKonva.KonvaClasses.Circle;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Ellipse
{
    public class KonvaEllipse : KonvaShape
    {

        private KonvaLayer ParentLayer { get; set; }

        public override KonvaEllipse SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaEllipse)base.SetJsRuntime(JsRuntime);
        }

        public KonvaEllipse SetConfigs(KonvaEllipseConfigsDTO Data)
        {
            return (KonvaEllipse)base.SetConfigs(Data);
        }

        public KonvaEllipse SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaEllipseConfigsDTO GetCastedConfigs()
        {
            return (KonvaEllipseConfigsDTO)Configs;
        }

        public async Task<KonvaEllipse> Build()
        {
            return (KonvaEllipse)(await base.Build("CreateEllipseFromJson"));
        }

    }
}
