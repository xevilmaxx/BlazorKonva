using BlazorKonva.Helpers;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Node;
using BlazorKonva.KonvaClasses.Shape;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Image
{
    public class KonvaImage : KonvaShape
    {

        private KonvaLayer ParentLayer { get; set; }

        public override KonvaImage SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaImage)base.SetJsRuntime(JsRuntime);
        }

        public KonvaImage SetConfigs(KonvaImageConfigsDTO Data)
        {
            return (KonvaImage)base.SetConfigs(Data);
        }

        public KonvaImage SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaImageConfigsDTO GetCastedConfigs()
        {
            return (KonvaImageConfigsDTO)Configs;
        }

        public override async Task<KonvaNode> Build(string ImagePath)
        {
            var args = JsonHelper.Serialize(Configs);

            var imageType = new FileInfo(ImagePath).Extension.Trim('.');
            var imageBase64 = Convert.ToBase64String(File.ReadAllBytes(ImagePath));
            var result = await JS.InvokeAsync<dynamic>($"CustomKonvaWrapper.CreateImageFromJson", ParentLayer.Configs.Id, imageBase64, imageType, args);
            return this;
        }

    }
}
