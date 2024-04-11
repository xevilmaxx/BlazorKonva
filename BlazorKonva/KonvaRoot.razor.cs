using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Rect;
using BlazorKonva.KonvaClasses.Stage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorKonva
{
    public partial class KonvaRoot : ComponentBase
    {

        [Parameter]
        public string ContainerId { get; set; } = Guid.NewGuid().ToString();

        [Inject]
        public BlazorKonvaWrapper BKW { get; set; }

        //private List<KonvaLayer> Layers { get; set; } = new List<KonvaLayer>();

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

            //await BuildWay0();

            //await BuildWay1();

            await BuildWay2();

            //await BuildWayRaw();

        }

        private async Task BuildWayRaw()
        {

            //_ = await ExampleJsInterop.CreateStage(ContainerId);

            await BKW.jsRuntime.InvokeAsync<dynamic>("ExampleJsInterop.CreateStage", ContainerId, 100, 100);

            await AddLayer();

            await AddBox();

            var JSHandler = DotNetObjectReference.Create(this);
            await BKW.jsRuntime.InvokeAsync<dynamic>("ExampleJsInterop.HandleBox", JSHandler);
        }

        private async Task BuildWay0()
        {
            var stage = await new KonvaStage()
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaStageConfigsDTO()
                {
                    ContainerId = ContainerId,
                    //Width = 500,
                    //Height = 500
                })
                .Build();

            var layer = await new KonvaLayer()
                .SetStage(stage)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaLayerConfigsDTO())
                .Build();

            var rect = await new KonvaRect()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaRectConfigsDTO()
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
        }

        private async Task BuildWay1()
        {
            var stage = await new KonvaStage()
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaStageConfigsDTO()
                {
                    ContainerId = ContainerId,
                    //Width = 500,
                    //Height = 500
                })
                .Build();

            //var sss = stage.GetCastedConfigs();

            var layer = await new KonvaLayer()
                .SetStage(stage)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaLayerConfigsDTO())
                .Build();

            await stage.AddNode(layer);

            var rect = await new KonvaRect()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaRectConfigsDTO()
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

            //var sss2 = rect.GetCastedConfigs();

            await layer.AddNode(rect);

        }

        private async Task BuildWay2()
        {

            var stage = await new KonvaStage()
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaStageConfigsDTO()
                {
                    ContainerId = ContainerId,
                    //Width = 500,
                    //Height = 500
                })
                .Build();

            var layer = await stage.AddLayer(new KonvaLayerConfigsDTO());

            var rect = await layer.AddRect(new KonvaRectConfigsDTO()
            {
                X = 50,
                Y = 50,
                Width = 100,
                Height = 50,
                Fill = "#00D2FF",
                Stroke = "black",
                StrokeWidth = 4,
                Draggable = true
            });

            await rect.ListenForEvents();

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
