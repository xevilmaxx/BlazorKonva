using BlazorKonva.KonvaClasses.Arc;
using BlazorKonva.KonvaClasses.Arrow;
using BlazorKonva.KonvaClasses.Circle;
using BlazorKonva.KonvaClasses.Ellipse;
using BlazorKonva.KonvaClasses.Image;
using BlazorKonva.KonvaClasses.Label;
using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Path;
using BlazorKonva.KonvaClasses.Rect;
using BlazorKonva.KonvaClasses.RegularPolygon;
using BlazorKonva.KonvaClasses.Ring;
using BlazorKonva.KonvaClasses.Stage;
using BlazorKonva.KonvaClasses.Star;
using BlazorKonva.KonvaClasses.Text;
using BlazorKonva.KonvaClasses.TextPath;
using BlazorKonva.KonvaClasses.Transformer;
using BlazorKonva.KonvaClasses.Wedge;
using BlazorKonva.KonvaCommonDTO;
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

            //////////////////////////////////////////////////////////

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

            //////////////////////////////////////////////////////////

            var circle = await new KonvaCircle()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaCircleConfigsDTO()
                {
                    X = 100,
                    Y = 100,
                    Radius = 70,
                    Fill = "#00D2FF",
                    Stroke = "black",
                    StrokeWidth = 4,
                    Draggable = true,
                    Opacity = 0.5
                })
                .Build();

            await layer.AddNode(circle);

            //////////////////////////////////////////////////////////

            var arc = await new KonvaArc()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaArcConfigsDTO()
                {
                    Angle = 50,
                    InnerRadius = 10,
                    OuterRadius = 10,
                    X = 200,
                    Y = 100,
                    Width = 100,
                    Height = 100,
                    Fill = "#00D2FF",
                    Stroke = "black",
                    StrokeWidth = 4,
                    Draggable = true,
                    Opacity = 0.5
                })
                .Build();

            await layer.AddNode(arc);

            //////////////////////////////////////////////////////////

            var arrow = await new KonvaArrow()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaArrowConfigsDTO()
                {
                    X = 200,
                    Y = 200,
                    Points = new int[] { 73, 70, 340, 23, 450, 60, 500, 20 },
                    Stroke = "red",
                    Tension = 1,
                    PointerLength = 10,
                    PointerWidth = 12,
                    Draggable = true,
                    Opacity = 0.75
                })
                .Build();

            await layer.AddNode(arrow);

            //////////////////////////////////////////////////////////

            var ellipse = await new KonvaEllipse()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaEllipseConfigsDTO()
                {
                    X = 250,
                    Y = 250,
                    Radius = new KonvaRadiusDTO()
                    {
                        X = 10,
                        Y = 10
                    },
                    Fill = "red",
                    Draggable = true,
                    Opacity = 0.75
                })
                .Build();

            await layer.AddNode(ellipse);

            //////////////////////////////////////////////////////////

            var regularPolygon = await new KonvaRegularPolygon()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaRegularPolygonConfigsDTO()
                {
                    X = 150,
                    Y = 250,
                    Sides = 6,
                    Radius = 50,
                    Fill = "#00D2FF",
                    Draggable = true,
                    Opacity = 0.5
                })
                .Build();

            await layer.AddNode(regularPolygon);

            //////////////////////////////////////////////////////////

            var ring = await new KonvaRing()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaRingConfigsDTO()
                {
                    X = 350,
                    Y = 250,
                    InnerRadius = 20,
                    OuterRadius = 20,
                    Stroke = "red",
                    StrokeWidth = 5,
                    Draggable = true,
                    Opacity = 0.5
                })
                .Build();

            await layer.AddNode(ring);

            //////////////////////////////////////////////////////////

            var star = await new KonvaStar()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaStarConfigsDTO()
                {
                    X = 450,
                    Y = 250,
                    NumPoints = 7,
                    InnerRadius = 40,
                    OuterRadius = 80,
                    Stroke = "black",
                    StrokeWidth = 4,
                    Draggable = true,
                    Opacity = 0.5
                })
                .Build();

            await layer.AddNode(star);

            //////////////////////////////////////////////////////////

            var wedge = await new KonvaWedge()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaWedgeConfigsDTO()
                {
                    X = 550,
                    Y = 250,
                    Radius = 20,
                    Angle = 43,
                    Rotation = 5,
                    Fill = "red",
                    Stroke = "black",
                    StrokeWidth = 2,
                    Draggable = true,
                    Opacity = 0.5
                })
                .Build();

            await layer.AddNode(wedge);

            //////////////////////////////////////////////////////////

            var label = await new KonvaLabel()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaLabelConfigsDTO()
                {
                    X = 550,
                    Y = 50,
                    Draggable = true
                })
                .Build();

            await layer.AddNode(label);

            //////////////////////////////////////////////////////////

            var text = await new KonvaText()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaTextConfigsDTO()
                {
                    X = 550,
                    Y = 50,
                    Text = "Hello Konva! [by xevilmaxx]",
                    FontSize = 20,
                    FontFamily = "Calibri",
                    Fill = "green",
                    Draggable = true,
                    Opacity = 1
                })
                .Build();

            await layer.AddNode(text);
            //also works
            //await label.AddNode(text);

            //////////////////////////////////////////////////////////

            var textPath = await new KonvaTextPath()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaTextPathConfigsDTO()
                {
                    X = 550,
                    Y = 100,
                    Text = "Everything is draggable! [by xevilmaxx]",
                    FontSize = 20,
                    FontFamily = "Calibri",
                    Fill = "green",
                    Data = "M10,10 C0,0 10,150 100,100 S300,150 400,50",
                    Draggable = true,
                    Opacity = 1
                })
                .Build();

            await layer.AddNode(textPath);

            //if want to test removal
            //await textPath.RemoveNode(layer.Configs.Id);

            //////////////////////////////////////////////////////////

            var image = await new KonvaImage()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaImageConfigsDTO()
                {
                    X = 550,
                    Y = 300,
                    Rotation = 45,
                    ScaleX = 0.5,
                    ScaleY = 0.5,
                    Draggable = true,
                    Opacity = 0.3
                })
                .Build("./wwwroot/images/caleidoscope.jpg");

            //await image.RemoveNode(layer.Configs.Id);

            //will be done automatically in this specific case, due to strange way of image initing
            //this would probably fail or create second registration
            //await layer.AddNode(image);

            //////////////////////////////////////////////////////////

            var path = await new KonvaPath()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetConfigs(new KonvaPathConfigsDTO()
                {
                    X = 240,
                    Y = 40,
                    Data = "M12.582,9.551C3.251,16.237,0.921,29.021,7.08,38.564l-2.36,1.689l4.893,2.262l4.893,2.262l-0.568-5.36l-0.567-5.359l-2.365,1.694c-4.657-7.375-2.83-17.185,4.352-22.33c7.451-5.338,17.817-3.625,23.156,3.824c5.337,7.449,3.625,17.813-3.821,23.152l2.857,3.988c9.617-6.893,11.827-20.277,4.935-29.896C35.591,4.87,22.204,2.658,12.582,9.551z",
                    Fill = "green",
                    ScaleX = 2,
                    ScaleY = 2,
                    Draggable = true,
                    Opacity = 0.3
                })
                .Build();

            await layer.AddNode(path);

            //////////////////////////////////////////////////////////

            var transformer = await new KonvaTransformer()
                .SetLayer(layer)
                .SetJsRuntime(BKW.jsRuntime)
                .SetTransformableNodes(new List<KonvaClasses.Node.KonvaNode>()
                {
                    path
                })
                .SetConfigs(new KonvaTransformerConfigsDTO()
                {
                    RotateAnchorOffset = 60,
                    EnabledAnchors = new string[] { "top-left", "top-right", "bottom-left", "bottom-right" }
                })
                .Build();

            //this is not needed for this calss
            //await layer.AddNode(transformer.Configs.IgnoreStroke);

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
