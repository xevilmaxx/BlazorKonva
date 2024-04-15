using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Ellipse
{
    public class KonvaEllipse : KonvaShape
    {

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
            base.SetParent(Data);
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
