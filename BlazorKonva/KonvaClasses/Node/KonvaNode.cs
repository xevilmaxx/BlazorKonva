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

        /// <summary>
        /// Accessible From every Node (castable to original type)
        /// </summary>
        public KonvaNodeConfigsDTO Configs { get; set; }

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
        public virtual KonvaNode SetJsRuntime(IJSRuntime JsRuntime)
        {
            JS = JsRuntime;
            return this;
        }

        /// <summary>
        /// Will populate internal Configs var it will be stored in generic Node configs way,
        /// yet can be casted back to specific type any time
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Mainly will create appropriate object javascript wrapper side
        /// </summary>
        /// <param name="MethodName"></param>
        /// <returns></returns>
        public async Task<KonvaNode> Build(string MethodName)
        {
            var args = JsonHelper.Serialize(Configs);
            var result = await JS.InvokeAsync<dynamic>($"CustomKonvaWrapper.{MethodName}", args);
            return this;
        }

        /// <summary>
        /// Will add a SubNode to current Node (this)
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task<bool> AddNode(KonvaNode Data)
        {
            var result = await JS.InvokeAsync<bool>("CustomKonvaWrapper.AddSubNode", this.Configs.Id, Data.Configs.Id);
            return result;
        }

    }
}
