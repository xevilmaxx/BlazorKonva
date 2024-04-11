using BlazorKonva.Helpers;
using BlazorKonva.KonvaClasses.Rect;
using BlazorKonva.KonvaClasses.Stage;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Node
{
    public abstract class KonvaNode
    {

        public KonvaNodeConfigsDTO Configs { get; set; }

        public IJSRuntime JS { get; set; }

        public virtual KonvaNode SetJsRuntime(IJSRuntime JsRuntime)
        {
            JS = JsRuntime;
            return this;
        }

        public KonvaNode SetConfigs(KonvaNodeConfigsDTO Data)
        {
            Configs = Data;
            return this;
        }

        //public async Task<KonvaNode> Build(string MethodName, string ParentId)
        //{
        //    var args = JsonHelper.Serialize(Configs);
        //    var result = await JS.InvokeAsync<dynamic>($"CustomKonvaWrapper.{MethodName}", ParentId, args);
        //    return this;
        //}

        public async Task<KonvaNode> Build(string MethodName)
        {
            var args = JsonHelper.Serialize(Configs);
            var result = await JS.InvokeAsync<dynamic>($"CustomKonvaWrapper.{MethodName}", args);
            return this;
        }

        public async Task<bool> AddNode(KonvaNode Data)
        {
            var result = await JS.InvokeAsync<bool>("CustomKonvaWrapper.AddSubNode", this.Configs.Id, Data.Configs.Id);
            return result;
        }

    }
}
