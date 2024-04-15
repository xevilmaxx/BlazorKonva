window.CustomKonvaWrapper = {

    //this is simply genius way to handle arbitrary complex data structure
    //as soon as everythin in konva seems to be basically a node
    //we will simply memorize them in plain array of nodes, so we can access to the items later
    //when needed
    //in such way we will have gerarchical structure in C# and in Konva
    //menawhile here we will solve the complexity of finding element once defined by leveraging
    //fact that we will assign a unique id to each node
    nodes: [],

    //transformer has no id propery and is not derived from node
    //we have 3 ways
    //simple: assume there can be only 1 transormer active at a time
    //2: wrap here transformer make this an array as nodes and for each record add ID
    //3: alter source code of javascript library in order to add id field (yet idk if it can be memorized in nodes array)
    transformer: null,

    GetNodeById: function (NodeId) {
        return this.nodes.find(node => node.attrs.id === NodeId);
    },

    //////////////////////////
    //EACH CLASS CREATOR IN SAME ORDER AS ON SITE
    //////////////////////////

    CreateAnimationFromJson: function (Configs) {

        var animation = new Konva.Animation(JSON.parse(Configs));

        this.nodes.push(animation);

        return animation.id();

    },

    CreateArcFromJson: function (Configs) {

        var node = new Konva.Arc(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateArrowFromJson: function (Configs) {

        var node = new Konva.Arrow(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateCanvasFromJson: function (Configs) {

        var node = new Konva.Canvas(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateCircleFromJson: function (Configs) {

        var node = new Konva.Circle(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateContainerFromJson: function (Configs) {

        var node = new Konva.Container(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateContextFromJson: function (Configs) {

        var node = new Konva.Context(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateEllipseFromJson: function (Configs) {

        var node = new Konva.Ellipse(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateFastLayerFromJson: function (Configs) {

        var node = new Konva.FastLayer(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateGroupFromJson: function (Configs) {

        var node = new Konva.Group(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateImageFromJson: function (ParentId, ImgBase64, ImgFormat, Configs) {

        //Konva.Image.fromURL(ImagePath, function (darthNode) {
        //    darthNode.setAttrs(JSON.parse(Configs));
        //    CustomKonvaWrapper.nodes.push(darthNode);
        //});


        var imageObj = new Image();

        imageObj.onload = function () {

            var parsedConfigs = JSON.parse(Configs);

            parsedConfigs['image'] = imageObj;

            var node = new Konva.Image(parsedConfigs);

            CustomKonvaWrapper.nodes.push(node);

            CustomKonvaWrapper.AddSubNode(ParentId, node.attrs.id);

        };

        //imageObj.src = ImagePath;
        imageObj.src = 'data:image/' + ImgFormat + ';base64,' + ImgBase64;

        return true;

    },

    CreateLabelFromJson: function (Configs) {

        var node = new Konva.Label(JSON.parse(Configs));

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

        var node = new Konva.Line(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateNodeFromJson: function (Configs) {

        var node = new Konva.Node(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreatePathFromJson: function (Configs) {

        var node = new Konva.Path(JSON.parse(Configs));

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

        var node = new Konva.RegularPolygon(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateRingFromJson: function (Configs) {

        var node = new Konva.Ring(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateShapeFromJson: function (Configs) {

        var node = new Konva.Shape(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateSpriteFromJson: function (Configs) {

        var node = new Konva.Sprite(JSON.parse(Configs));

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

        var node = new Konva.Star(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateTagFromJson: function (Configs) {

        var node = new Konva.Tag(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateTextFromJson: function (Configs) {

        var node = new Konva.Text(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateTextPathFromJson: function (Configs) {

        var node = new Konva.TextPath(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateTransformFromJson: function (Configs) {

        var node = new Konva.Transform(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateTransformerFromJson: function (ParentNodeId, TransformableNodes, Configs) {

        var parsedConfigs = JSON.parse(Configs);

        if (!parsedConfigs.nodes) {
            parsedConfigs.nodes = [];
        }

        for (let i = 0; i < TransformableNodes.length; i++) {
            parsedConfigs.nodes.push(this.GetNodeById(TransformableNodes[i]));
        }

        var transformer = new Konva.Transformer(parsedConfigs);

        //this.nodes.push(node);
        this.transformer = transformer;

        var parent = this.GetNodeById(ParentNodeId);

        parent.add(this.transformer);

        return true;

    },

    CreateTweenFromJson: function (Configs) {

        var node = new Konva.Tween(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    CreateWedgeFromJson: function (Configs) {

        var node = new Konva.Wedge(JSON.parse(Configs));

        this.nodes.push(node);

        return node.id();

    },

    //////////////////////////
    //CUSTOM MADE FUNCTIONS
    //////////////////////////

    SetTransformerNodes: function (TransformableNodes) {

        var nodes = null;
        for (let i = 0; i < TransformableNodes.length; i++) {
            nodes.push(this.GetNodeById(TransformableNodes[i]));
        }

        this.transformer.nodes(nodes);

        return true;

    },

    RemoveTransformer: function (ParentNodeId) {

        var parent = this.GetNodeById(ParentNodeId);

        parent.remove(this.transformer);

        this.transformer = null;

        return true;

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

    },

    SubscribeEventJs: function (NodeId, JavascriptEvent, JsFunction) {

        var node = this.GetNodeById(NodeId);

        node.on(JavascriptEvent, JsFunction);

        return true;

    },

    UnsubscribeEvent: function (NodeId, JavascriptEvent) {

        var node = this.GetNodeById(NodeId);

        //both ways are valid, but we will prefer shorter one
        //this will unsubscribe from javascript event
        //node.removeEventListener(JavascriptEvent, null);
        node.off(JavascriptEvent);

        return true;

    },

    RemoveNode: function (ParentLayerNodeId, DestNodeId) {

        //if (ParentNodeId !== null)
        //{
        //    var mainNode = this.GetNodeById(ParentNodeId);
        //    var subNode = this.GetNodeById(DestNodeId);

        //    subNode.destroy();
        //    //mainNode.remove(subNode);

        //    //this remove subNode from list
        //    this.nodes = this.nodes.filter(element => element !== subNode);

        //}
        //else
        //{

        var mainNode = this.GetNodeById(ParentLayerNodeId);
        var subNode = this.GetNodeById(DestNodeId);

        subNode.destroy();

        //this remove subNode from list
        this.nodes = this.nodes.filter(element => element !== subNode);

        //}

        //redraw
        mainNode.draw();

        return true;

    }

}