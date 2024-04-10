using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System.ComponentModel;
using System.Reflection;

namespace BlazorKonva
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class BlazorKonvaWrapper : IAsyncDisposable
    {

        public IJSRuntime jsRuntime { get; private set; }

        //private readonly Lazy<Task<IJSObjectReference>> moduleTask;
        //private readonly Lazy<Task<IJSObjectReference>> moduleTaskExt;

        private bool IsExternalLibImported { get; set; }
        private bool IsIntermediateLibImported { get; set; }

        public BlazorKonvaWrapper(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;

            //_ = jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorKonva/exampleJsInterop2.js");

            //moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            //    "import", "./_content/BlazorKonva/exampleJsInterop2.js").AsTask());


            //_ = jsRuntime.InvokeVoidAsync("eval", jsRuntime.InvokeAsync<string>("fetch", "./_content/BlazorKonva/exampleJsInterop2.js"));

            //_ = jsRuntime.InvokeVoidAsync("eval", jsRuntime.InvokeAsync<string>("fetch", "./_content/BlazorKonva/javascript/konva.min.js"));


            //moduleTaskExt = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            //    "import", "./_content/BlazorKonva/javascript/konva.min.js").AsTask());
        }

        /// <summary>
        /// To use if scripts werent imported manually, works good if invoked inside OnAfterRenderAsync(...) method
        /// </summary>
        /// <returns></returns>
        public async ValueTask<bool> Init()
        {

            if(IsIntermediateLibImported == false)
            {
                await jsRuntime.InvokeAsync<dynamic>("import", "./_content/BlazorKonva/exampleJsInterop2.js");
                IsIntermediateLibImported = true;
            }

            if (IsExternalLibImported == false)
            {
                await jsRuntime.InvokeAsync<dynamic>("import", "./_content/BlazorKonva/javascript/konva.min.js");
                IsExternalLibImported = true;
            }

            return true;

        }

        //public async ValueTask<string> Prompt(string message)
        //{
        //    var module = await moduleTask.Value;
        //    return await module.InvokeAsync<string>("showPrompt", message);
        //}

        public async ValueTask<dynamic> CreateStage(string ContainerId)
        {
            //var module = await moduleTask.Value;
            //return await module.InvokeAsync<dynamic>("CreateStage", "Test", 100, 100);
            await jsRuntime.InvokeAsync<dynamic>("ExampleJsInterop.CreateStage", ContainerId, 100, 100);
            //await jsRuntime.InvokeAsync<dynamic>("ExampleJsInterop.CreateStage1");

            return null;
        }

        public async ValueTask DisposeAsync()
        {
            //if (moduleTask.IsValueCreated)
            //{
            //    var module = await moduleTask.Value;
            //    await module.DisposeAsync();
            //}
            //if (moduleTaskExt.IsValueCreated)
            //{
            //    var module = await moduleTaskExt.Value;
            //    await module.DisposeAsync();
            //}
        }

    }
}
