using BlazorKonva.Enums;
using BlazorKonva.Helpers;
using Microsoft.JSInterop;

namespace BlazorKonva.KonvaClasses.Node
{
    public abstract class KonvaNode
    {

        public EventHandler OnMouseOver { get; set; }
        public EventHandler OnMouseOut { get; set; }
        public EventHandler OnClick { get; set; }
        public EventHandler OnContextMenu { get; set; }

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
        public virtual KonvaNode SetConfigs(KonvaNodeConfigsDTO Data)
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
        public virtual async Task<KonvaNode> Build(string MethodName)
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
        public virtual async Task<bool> AddNode(KonvaNode Data)
        {
            return await AddNode(Data.Configs.Id);
            //var result = await JS.InvokeAsync<bool>("CustomKonvaWrapper.AddSubNode", this.Configs.Id, Data.Configs.Id);
            //return result;
        }

        public virtual async Task<bool> AddNode(string DestNodeId)
        {
            var result = await JS.InvokeAsync<bool>("CustomKonvaWrapper.AddSubNode", this.Configs.Id, DestNodeId);
            return result;
        }

        public virtual async Task<bool> RemoveNode(string ParentLayerNodeId)
        {
            var result = await JS.InvokeAsync<bool>("CustomKonvaWrapper.RemoveNode", ParentLayerNodeId, this.Configs.Id);
            return result;
        }

        /// <summary>
        /// Allows us receive Javascript events, here you can pass original object eventually
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SubscribeToJsEvent(string EventType, object JsHandler, string CsharpInvokableMethodName)
        {
            var result = await JS.InvokeAsync<bool>("CustomKonvaWrapper.SubscribeEvent", Configs.Id, EventType, JsHandler, CsharpInvokableMethodName);
            return result;
        }

        public async Task<bool> SubscribeToJsEvent(string EventType)
        {
            var JsHandler = DotNetObjectReference.Create(this);

            string methodName = "";

            if (EventType == KonvaJsEvent.Mouseover)
            {
                methodName = nameof(JsOnMouseOver);
            }
            else if (EventType == KonvaJsEvent.Mouseout)
            {
                methodName = nameof(JsOnMouseOut);
            }
            else if (EventType == KonvaJsEvent.Click)
            {
                methodName = nameof(JsOnClick);
            }
            else if (EventType == KonvaJsEvent.Contextmenu)
            {
                methodName = nameof(JsOnContextMenu);
            }

            var result = await SubscribeToJsEvent(EventType, JsHandler, methodName);

            return result;
        }


        #region JsInvokables

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

        /// <summary>
        /// Only public modifier works, private and others dont, and attribute MUST be specified
        /// </summary>
        [JSInvokable]
        public void JsOnClick()
        {
            OnClick?.Invoke(this, null);
        }

        /// <summary>
        /// Only public modifier works, private and others dont, and attribute MUST be specified
        /// </summary>
        [JSInvokable]
        public void JsOnContextMenu()
        {
            OnContextMenu?.Invoke(this, null);
        }

        #endregion

    }
}
