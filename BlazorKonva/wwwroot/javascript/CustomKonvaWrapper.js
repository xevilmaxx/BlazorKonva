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
