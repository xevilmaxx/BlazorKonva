using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva
{
    public partial class KonvaStage : ComponentBase
    {

        [Parameter]
        public string ContainerId { get; set; } = "KonvaContainer";

        [Inject]
        public BlazorKonvaWrapper BKW { get; set; }

        private List<KonvaLayer> Layers { get; set; } = new List<KonvaLayer>();

        [JSInvokable]
        public void OnMouseOver()
        {

        }


        [JSInvokable]
        public void OnMouseOut()
        {

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if(firstRender == false)
            {
                return;
            }

            await BKW.Init();

            //_ = await ExampleJsInterop.CreateStage(ContainerId);

            await BKW.jsRuntime.InvokeAsync<dynamic>("ExampleJsInterop.CreateStage", ContainerId, 100, 100);

            await AddLayer();

            await AddBox();

            var JSHandler = DotNetObjectReference.Create(this);
            await BKW.jsRuntime.InvokeAsync<dynamic>("ExampleJsInterop.HandleBox", JSHandler);

        }

        private async Task AddLayer()
        {
            //Layers.Add(new KonvaLayer());
            var x = await BKW.jsRuntime.InvokeAsync<dynamic>("ExampleJsInterop.AddLayer");
        }

        private async Task AddBox()
        {
            //Layers.Add(new KonvaLayer());
            var x = await BKW.jsRuntime.InvokeAsync<dynamic>("ExampleJsInterop.AddBox");
        }

    }
}
