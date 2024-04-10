using BlazorKonva.KonvaClasses;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Rect;
using BlazorKonva.KonvaClasses.Stage;
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

            if (firstRender == false)
            {
                return;
            }

            await BKW.Init();

            //_ = await ExampleJsInterop.CreateStage(ContainerId);

            var stage = await new Stage()
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new StageConfigsDTO()
                {
                    ContainerId = ContainerId,
                    //Width = 500,
                    //Height = 500
                })
                .Build();

            var layer = await new Layer()
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new LayerConfigsDTO())
                .Build();

            var rect = await new Rect()
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new RectConfigsDTO()
                {
                    X = 50,
                    Y = 50,
                    Width = 100,
                    Height = 50,
                    Fill = "#00D2FF",
                    Stroke = "black",
                    StrokeWidth = 4,
                    Draggable = true
                })
                .Build();

            //await BKW.jsRuntime.InvokeAsync<dynamic>("ExampleJsInterop.CreateStage", ContainerId, 100, 100);

            //await AddLayer();

            //await AddBox();

            //var JSHandler = DotNetObjectReference.Create(this);
            //await BKW.jsRuntime.InvokeAsync<dynamic>("ExampleJsInterop.HandleBox", JSHandler);

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
