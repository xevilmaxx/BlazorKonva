window.ExampleJsInterop = {

    stage: null,
    layer: null,
    box: null,

    showPrompt: function (message) {
        return prompt(message, 'Type anything here');
    },

    CreateStage0: function ()
    {
        prompt('dasadasdasdasdasdasdasdasdasdasdasdadasdas', 'Type anything here');
    },

    CreateStage1: function () {
        prompt('dasadasdasdasdasdasdasdasdasdasdasdadasdas', 'Type anything here');
    },

    CreateStage: function (ContainerId, Width, Height) {
        this.stage = new Konva.Stage({
            container: ContainerId,
            width: window.innerWidth,
            height: window.innerHeight,
        });
        console.log("Stage Inited");
        return this.stage.id();
    },

    CreateStageFromJson: function (Configs) {
        //console.log(Configs);
        var parsedConfigs = JSON.parse(Configs)

        if (!parsedConfigs.width || parsedConfigs.width <= 0) {
            parsedConfigs.width = window.innerWidth;
        }
        if (!parsedConfigs.height || parsedConfigs.height <= 0) {
            parsedConfigs.height = window.innerHeight;
        }

        this.stage = new Konva.Stage(parsedConfigs);
        return this.stage.id();
        //return this.stage;
    },

    AddLayer: function () {
        this.layer = new Konva.Layer();
        this.stage.add(this.layer);
        return this.layer.id();
    },

    CreateLayerFromJson: function (Configs) {
        //console.log(Configs);
        this.layer = new Konva.Layer(JSON.parse(Configs));

        this.stage.add(this.layer);

        return this.layer.id();
        //return this.stage;
    },

    CreateRectFromJson: function (dotNetObject, Configs) {
        //console.log(Configs);
        this.box = new Konva.Rect(JSON.parse(Configs));

        this.layer.add(this.box);

        this.box.on('mouseover', function () {
            //mouseover(true);
            //
            //DotNet.invokeMethodAsync('BlazorKonva', 'OnMouseOver');
            dotNetObject.invokeMethodAsync('OnMouseOver');
        });
        this.box.on('mouseout', function () {
            //mouseout(true);
            //DotNet.invokeMethodAsync('BlazorKonva', 'OnMouseOut');
            dotNetObject.invokeMethodAsync('OnMouseOut');
        });

        return this.box.id();
        //return this.stage;
    },

    AddBox: function () {
        this.box = new Konva.Rect({
            x: 50,
            y: 50,
            width: 100,
            height: 50,
            fill: '#00D2FF',
            stroke: 'black',
            strokeWidth: 4,
            draggable: true,
        });
        this.layer.add(this.box);
    },

    HandleBox: function (dotNetObject) {
        this.box.on('mouseover', function () {
            //mouseover(true);
            //
            //DotNet.invokeMethodAsync('BlazorKonva', 'OnMouseOver');
            dotNetObject.invokeMethodAsync('OnMouseOver');
        });
        this.box.on('mouseout', function () {
            //mouseout(true);
            //DotNet.invokeMethodAsync('BlazorKonva', 'OnMouseOut');
            dotNetObject.invokeMethodAsync('OnMouseOut');
        });
    }

}

window.CustomKonvaWrapper = {

    //this is simply genius way to handle arbitrary complex data structure
    //as soon as everythin in konva seems to be basically a node
    //we will simply memorize them in plain array of nodes, so we can access to the items later
    //when needed
    //in such way we will have gerarchical structure in C# and in Konva
    //menawhile here we will solve the complexity of finding element once defined by leveraging
    //fact that we will assign a unique id to each node
    nodes: [],

    GetNodeById: function (NodeId) {
        return this.nodes.find(node => node.attrs.id === NodeId);
    },

    //////////////////////////
    //EACH CLASS CREATOR IN SAME ORDER AS ON SITE
    //////////////////////////

    CreateAnimationFromJson: function (Configs) {
        
        var animation = new Konva.Animation(Configs);

        this.nodes.push(animation);

        return animation.id();

    },

    CreateArcFromJson: function (Configs) {

        var node = new Konva.Arc(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateArrowFromJson: function (Configs) {

        var node = new Konva.Arrow(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateCanvasFromJson: function (Configs) {

        var node = new Konva.Canvas(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateCircleFromJson: function (Configs) {

        var node = new Konva.Circle(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateContainerFromJson: function (Configs) {

        var node = new Konva.Container(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateContextFromJson: function (Configs) {

        var node = new Konva.Context(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateEllipseFromJson: function (Configs) {

        var node = new Konva.Ellipse(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateFastLayerFromJson: function (Configs) {

        var node = new Konva.FastLayer(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateGroupFromJson: function (Configs) {

        var node = new Konva.Group(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateImageFromJson: function (Configs) {

        var node = new Konva.Image(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateLabelFromJson: function (Configs) {

        var node = new Konva.Label(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateLayerFromJson: function (Configs) {

        var layer = new Konva.Layer(JSON.parse(Configs));

        this.nodes.push(layer);

        //will link to parent through AddSubNode() later from C#

        return layer.id();

    },

    CreateLineFromJson: function (Configs) {

        var node = new Konva.Line(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateNodeFromJson: function (Configs) {

        var node = new Konva.Node(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreatePathFromJson: function (Configs) {

        var node = new Konva.Path(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateRectFromJson: function (Configs) {

        var box = new Konva.Rect(JSON.parse(Configs));

        this.nodes.push(box);

        //will link to parent through AddSubNode() later from C#

        return box.id();

    },

    CreateRegularPolygonFromJson: function (Configs) {

        var node = new Konva.RegularPolygon(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateRingFromJson: function (Configs) {

        var node = new Konva.Ring(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateShapeFromJson: function (Configs) {

        var node = new Konva.Shape(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateSpriteFromJson: function (Configs) {

        var node = new Konva.Sprite(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateStageFromJson: function (Configs) {
        //console.log(Configs);

        var parsedConfigs = JSON.parse(Configs)

        if (!parsedConfigs.width || parsedConfigs.width <= 0) {
            parsedConfigs.width = window.innerWidth;
        }
        if (!parsedConfigs.height || parsedConfigs.height <= 0) {
            parsedConfigs.height = window.innerHeight;
        }

        var stage = new Konva.Stage(parsedConfigs);

        this.nodes.push(stage);

        return stage.id();

    },

    CreateStarFromJson: function (Configs) {

        var node = new Konva.Star(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateTagFromJson: function (Configs) {

        var node = new Konva.Tag(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateTextFromJson: function (Configs) {

        var node = new Konva.Text(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateTextPathFromJson: function (Configs) {

        var node = new Konva.TextPath(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateTransformFromJson: function (Configs) {

        var node = new Konva.Transform(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateTransformerFromJson: function (Configs) {

        var node = new Konva.Transformer(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateTweenFromJson: function (Configs) {

        var node = new Konva.Tween(Configs);

        this.nodes.push(node);

        return node.id();

    },

    CreateWedgeFromJson: function (Configs) {

        var node = new Konva.Wedge(Configs);

        this.nodes.push(node);

        return node.id();

    },

    //////////////////////////
    //CUSTOM MADE FUNCTIONS
    //////////////////////////

    AddSubNode: function (SourceNodeId, DestNodeId) {

        var mainNode = this.GetNodeById(SourceNodeId);
        var subNode = this.GetNodeById(DestNodeId);

        mainNode.add(subNode);

        return true;

    },

    SubscribeEvent: function (NodeId, JavascriptEvent, DotNetObject, DotNetMethodName) {

        var node = this.GetNodeById(NodeId);

        node.on(JavascriptEvent, function () {
            DotNetObject.invokeMethodAsync(DotNetMethodName);
        });

        return true;

    }

}