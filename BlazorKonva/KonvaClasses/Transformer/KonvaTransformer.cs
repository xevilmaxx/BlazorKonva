using BlazorKonva.Helpers;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Node;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Transformer
{
    public class KonvaTransformer
    {

        private KonvaLayer ParentLayer { get; set; }

        public List<KonvaNode> TransformableNodes { get; set; }

        /// <summary>
        /// Accessible From every Node (castable to original type)
        /// </summary>
        public KonvaTransformerConfigsDTO Configs { get; set; }

        /// <summary>
        /// Accessible From every Node
        /// </summary>
        public IJSRuntime JS { get; set; }

        /// <summary>
        /// Simply propagates JavascriptRuntime through every single node
        /// <para/>
        /// Its passed implicitly by reference so not heavy stuff, yet gives us ability to incapsulate class logics
        /// </summary>
        /// <param name="JsRuntime"></param>
        /// <returns></returns>
        public KonvaTransformer SetJsRuntime(IJSRuntime JsRuntime)
        {
            JS = JsRuntime;
            return this;
        }

        public KonvaTransformer SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        /// <summary>
        /// Will populate internal Configs var it will be stored in generic Node configs way,
        /// yet can be casted back to specific type any time
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public KonvaTransformer SetConfigs(KonvaTransformerConfigsDTO Data)
        {
            Configs = Data;
            return this;
        }

        public KonvaTransformer SetTransformableNodes(List<KonvaNode> Data)
        {
            TransformableNodes = Data;
            return this;
        }

        /// <summary>
        /// Mainly will create appropriate object javascript wrapper side
        /// </summary>
        /// <param name="MethodName"></param>
        /// <returns></returns>
        public async Task<KonvaTransformer> Build()
        {
            var args = JsonHelper.Serialize(Configs);
            var transormableNodes = this.TransformableNodes.Select(x => x.Configs.Id).ToList();
            var result = await JS.InvokeAsync<dynamic>($"CustomKonvaWrapper.CreateTransformerFromJson", ParentLayer.Configs.Id, transormableNodes, args);
            return this;
        }

        public async Task<KonvaTransformer> UpdateNodes(List<KonvaNode> Data)
        {
            var transormableNodes = this.TransformableNodes.Select(x => x.Configs.Id).ToList();
            var result = await JS.InvokeAsync<dynamic>($"CustomKonvaWrapper.SetTransformerNodes", transormableNodes);
            return this;
        }

        public async Task<KonvaTransformer> RemoveTransormer(List<KonvaNode> Data)
        {
            var transormableNodes = this.TransformableNodes.Select(x => x.Configs.Id).ToList();
            var result = await JS.InvokeAsync<dynamic>($"CustomKonvaWrapper.RemoveTransformer", ParentLayer.Configs.Id);
            return this;
        }

    }
}
