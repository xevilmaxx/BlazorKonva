﻿using BlazorKonva.Helpers;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Node;
using BlazorKonva.KonvaClasses.Stage;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Rect
{
    public class KonvaRect : KonvaNode
    {

        public KonvaRectConfigsDTO Configs { get; set; }
        public override KonvaNodeConfigsDTO CommonConfigs { get; set; }

        private IJSRuntime JS { get; set; }

        public EventHandler OnMouseOver { get; set; }
        public EventHandler OnMouseOut { get; set; }

        private KonvaLayer ParentLayer { get; set; }

        public KonvaRect SetLayer(KonvaLayer Data)
        {
            ParentLayer = Data;
            return this;
        }

        public KonvaRect SetJsRuntime(IJSRuntime JsRuntime)
        {
            JS = JsRuntime;
            return this;
        }

        public KonvaRect SetConfigs(KonvaRectConfigsDTO Data)
        {
            Configs = Data;
            CommonConfigs = Data;
            return this;
        }

        public async Task<KonvaRect> Build()
        {
            var args = JsonHelper.Serialize(Configs);
            var JSHandler = DotNetObjectReference.Create(this);
            var result = await JS.InvokeAsync<dynamic>("CustomKonvaWrapper.CreateRectFromJson", ParentLayer.Configs.Id, JSHandler, args);
            //Id = result;
            return this;
        }

        /// <summary>
        /// Only public modifier works, private and others dont, and attribute MUST be specified
        /// </summary>
        [JSInvokable]
        public void JsOnMouseOver()
        {
            OnMouseOver?.Invoke(this, null);
        }

        /// <summary>
        /// Only public modifier works, private and others dont, and attribute MUST be specified
        /// </summary>
        [JSInvokable]
        public void JsOnMouseOut()
        {
            OnMouseOut?.Invoke(this, null);
        }

    }
}
