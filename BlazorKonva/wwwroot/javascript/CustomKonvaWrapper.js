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
        //return this.stage;
    },

    CreateLayerFromJson: function (StageId, Configs) {
        //console.log(Configs);

        //var stage = this.GetNodeById(StageId);

        var layer = new Konva.Layer(JSON.parse(Configs));

        this.nodes.push(layer);

        //stage.add(layer);

        //need also add layer to stage

        return layer.id();
        //return this.stage;
    },

    CreateRectFromJson: function (LayerId, DotNetObject, Configs) {

        //var layer = this.GetNodeById(LayerId);

        //console.log(Configs);
        var box = new Konva.Rect(JSON.parse(Configs));

        this.nodes.push(box);

        //layer.add(box);

        //box.on('mouseover', function () {
        //    //mouseover(true);
        //    //
        //    //DotNet.invokeMethodAsync('BlazorKonva', 'OnMouseOver');
        //    DotNetObject.invokeMethodAsync('JsOnMouseOver');
        //});
        //box.on('mouseout', function () {
        //    //mouseout(true);
        //    //DotNet.invokeMethodAsync('BlazorKonva', 'OnMouseOut');
        //    DotNetObject.invokeMethodAsync('JsOnMouseOut');
        //});

        return box.id();
        //return this.stage;
    },

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