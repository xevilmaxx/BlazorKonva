﻿using BlazorKonva.KonvaClasses.Node;
using BlazorKonva.KonvaClasses.Rect;
using BlazorKonva.KonvaClasses.Stage;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Layer
{
    public class KonvaLayer : KonvaNode
    {

        public override KonvaLayer SetJsRuntime(IJSRuntime JsRuntime)
        {
            return (KonvaLayer)base.SetJsRuntime(JsRuntime);
        }

        public KonvaLayer SetConfigs(KonvaLayerConfigsDTO Data)
        {
            return (KonvaLayer)base.SetConfigs(Data);
        }

        public KonvaLayer SetStage(KonvaStage Data)
        {
            base.SetParent(Data);
            return this;
        }

        /// <summary>
        /// Will return whole configs as correct to the class
        /// </summary>
        /// <returns></returns>
        public KonvaLayerConfigsDTO GetCastedConfigs()
        {
            return (KonvaLayerConfigsDTO)Configs;
        }

        public async Task<KonvaLayer> Build()
        {
            //return (KonvaLayer)(await base.Build("CreateLayerFromJson", ParentStage.Configs.Id));
            return (KonvaLayer)(await base.Build("CreateLayerFromJson"));
        }

        public async Task<KonvaRect> AddRect(KonvaRectConfigsDTO Data)
        {
            var rect = await new KonvaRect()
                .SetJsRuntime(JS)
                .SetLayer(this)
                .SetConfigs(Data)
                .Build();

            var result = await AddNode(rect);

            return rect;
        }

        public async Task<KonvaLayer> AttachObjectSnapper()
        {
            var result = await JS.InvokeAsync<dynamic>($"CustomKonvaWrapperExtensions.AttachObjectSnapper", ParentNode.Configs.Id, Configs.Id);
            return this;
        }

        public async Task<KonvaLayer> DetachObjectSnapper()
        {
            var result = await JS.InvokeAsync<dynamic>($"CustomKonvaWrapperExtensions.DetachObjectSnapper", Configs.Id);
            return this;
        }

    }
}
