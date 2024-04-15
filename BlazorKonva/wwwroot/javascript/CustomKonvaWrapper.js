window.ExampleJsInterop = {

    stage: null,
    layer: null,
    box: null,

    showPrompt: function (message) {
        return prompt(message, 'Type anything here');
    },

    CreateStage0: function () {
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

window.CustomKonvaWrapperExtensions = {

    //////////////////////////
    //CUSTOM MADE EXTENDED FUNCTIONALITIES (BEYOND CORE)
    //////////////////////////

    //////////////////////////
    //STAGE RESIZE
    //////////////////////////
    //https://konvajs.org/docs/sandbox/Zooming_Relative_To_Pointer.html

    AttachZoomOnStage: function (StageNodeId, ScaleFactor) {

        var stage = CustomKonvaWrapper.GetNodeById(StageNodeId);

        if (ScaleFactor == null || ScaleFactor <= 0) {
            ScaleFactor = 1.01;
        }

        var scaleBy = ScaleFactor;

        stage.on('wheel', (e) => {
            // stop default scrolling
            e.evt.preventDefault();

            var oldScale = stage.scaleX();
            var pointer = stage.getPointerPosition();

            var mousePointTo = {
                x: (pointer.x - stage.x()) / oldScale,
                y: (pointer.y - stage.y()) / oldScale,
            };

            // how to scale? Zoom in? Or zoom out?
            let direction = e.evt.deltaY > 0 ? 1 : -1;

            // when we zoom on trackpad, e.evt.ctrlKey is true
            // in that case lets revert direction
            if (e.evt.ctrlKey) {
                direction = -direction;
            }

            var newScale = direction > 0 ? oldScale * scaleBy : oldScale / scaleBy;

            stage.scale({ x: newScale, y: newScale });

            var newPos = {
                x: pointer.x - mousePointTo.x * newScale,
                y: pointer.y - mousePointTo.y * newScale,
            };
            stage.position(newPos);
        });

        return true;

    },

    DetachZoomOnStage: function (StageNodeId) {

        CustomKonvaWrapper.UnsubscribeEvent(StageNodeId, 'wheel');

        return true;

    },

    //////////////////////////
    //SNAP GUIDES
    //////////////////////////
    //https://konvajs.org/docs/sandbox/Objects_Snapping.html

    GetLineGuideStops: function (stage, skipShape) {
        // we can snap to stage borders and the center of the stage
        var vertical = [0, stage.width() / 2, stage.width()];
        var horizontal = [0, stage.height() / 2, stage.height()];

        // and we snap over edges and center of each object on the canvas
        stage.find('.object').forEach((guideItem) => {
            if (guideItem === skipShape) {
                return;
            }
            var box = guideItem.getClientRect();
            // and we can snap to all edges of shapes
            vertical.push([box.x, box.x + box.width, box.x + box.width / 2]);
            horizontal.push([box.y, box.y + box.height, box.y + box.height / 2]);
        });
        return {
            vertical: vertical.flat(),
            horizontal: horizontal.flat(),
        };
    },

    // what points of the object will trigger to snapping?
    // it can be just center of the object
    // but we will enable all edges and center
    GetObjectSnappingEdges: function (node) {
        var box = node.getClientRect();
        var absPos = node.absolutePosition();

        return {
            vertical: [
                {
                    guide: Math.round(box.x),
                    offset: Math.round(absPos.x - box.x),
                    snap: 'start',
                },
                {
                    guide: Math.round(box.x + box.width / 2),
                    offset: Math.round(absPos.x - box.x - box.width / 2),
                    snap: 'center',
                },
                {
                    guide: Math.round(box.x + box.width),
                    offset: Math.round(absPos.x - box.x - box.width),
                    snap: 'end',
                },
            ],
            horizontal: [
                {
                    guide: Math.round(box.y),
                    offset: Math.round(absPos.y - box.y),
                    snap: 'start',
                },
                {
                    guide: Math.round(box.y + box.height / 2),
                    offset: Math.round(absPos.y - box.y - box.height / 2),
                    snap: 'center',
                },
                {
                    guide: Math.round(box.y + box.height),
                    offset: Math.round(absPos.y - box.y - box.height),
                    snap: 'end',
                },
            ],
        };
    },

    // find all snapping possibilities
    GetGuides: function (lineGuideStops, itemBounds) {
        var GUIDELINE_OFFSET = 5;
        var resultV = [];
        var resultH = [];

        lineGuideStops.vertical.forEach((lineGuide) => {
            itemBounds.vertical.forEach((itemBound) => {
                var diff = Math.abs(lineGuide - itemBound.guide);
                // if the distance between guild line and object snap point is close we can consider this for snapping
                if (diff < GUIDELINE_OFFSET) {
                    resultV.push({
                        lineGuide: lineGuide,
                        diff: diff,
                        snap: itemBound.snap,
                        offset: itemBound.offset,
                    });
                }
            });
        });

        lineGuideStops.horizontal.forEach((lineGuide) => {
            itemBounds.horizontal.forEach((itemBound) => {
                var diff = Math.abs(lineGuide - itemBound.guide);
                if (diff < GUIDELINE_OFFSET) {
                    resultH.push({
                        lineGuide: lineGuide,
                        diff: diff,
                        snap: itemBound.snap,
                        offset: itemBound.offset,
                    });
                }
            });
        });

        var guides = [];

        // find closest snap
        var minV = resultV.sort((a, b) => a.diff - b.diff)[0];
        var minH = resultH.sort((a, b) => a.diff - b.diff)[0];
        if (minV) {
            guides.push({
                lineGuide: minV.lineGuide,
                offset: minV.offset,
                orientation: 'V',
                snap: minV.snap,
            });
        }
        if (minH) {
            guides.push({
                lineGuide: minH.lineGuide,
                offset: minH.offset,
                orientation: 'H',
                snap: minH.snap,
            });
        }
        return guides;
    },

    DrawGuides: function (layer, guides) {
        guides.forEach((lg) => {
            if (lg.orientation === 'H') {
                var line = new Konva.Line({
                    points: [-6000, 0, 6000, 0],
                    stroke: 'rgb(0, 161, 255)',
                    strokeWidth: 1,
                    name: 'guid-line',
                    dash: [4, 6],
                });
                layer.add(line);
                line.absolutePosition({
                    x: 0,
                    y: lg.lineGuide,
                });
            } else if (lg.orientation === 'V') {
                var line = new Konva.Line({
                    points: [0, -6000, 0, 6000],
                    stroke: 'rgb(0, 161, 255)',
                    strokeWidth: 1,
                    name: 'guid-line',
                    dash: [4, 6],
                });
                layer.add(line);
                line.absolutePosition({
                    x: lg.lineGuide,
                    y: 0,
                });
            }
        });
    },

    AttachObjectSnapper: function (ParentStageNodeId, LayerNodeId) {

        var parentStage = CustomKonvaWrapper.GetNodeById(ParentStageNodeId);
        var layer = CustomKonvaWrapper.GetNodeById(LayerNodeId);

        layer.on('dragmove', function (e) {
            // clear all previous lines on the screen
            layer.find('.guid-line').forEach((l) => l.destroy());

            // find possible snapping lines
            var lineGuideStops = CustomKonvaWrapperExtensions.GetLineGuideStops(parentStage, e.target);
            // find snapping points of current object
            var itemBounds = CustomKonvaWrapperExtensions.GetObjectSnappingEdges(e.target);

            // now find where can we snap current object
            var guides = CustomKonvaWrapperExtensions.GetGuides(lineGuideStops, itemBounds);

            // do nothing of no snapping
            if (!guides.length) {
                return;
            }

            CustomKonvaWrapperExtensions.DrawGuides(layer, guides);

            var absPos = e.target.absolutePosition();
            // now force object position
            guides.forEach((lg) => {
                switch (lg.snap) {
                    case 'start': {
                        switch (lg.orientation) {
                            case 'V': {
                                absPos.x = lg.lineGuide + lg.offset;
                                break;
                            }
                            case 'H': {
                                absPos.y = lg.lineGuide + lg.offset;
                                break;
                            }
                        }
                        break;
                    }
                    case 'center': {
                        switch (lg.orientation) {
                            case 'V': {
                                absPos.x = lg.lineGuide + lg.offset;
                                break;
                            }
                            case 'H': {
                                absPos.y = lg.lineGuide + lg.offset;
                                break;
                            }
                        }
                        break;
                    }
                    case 'end': {
                        switch (lg.orientation) {
                            case 'V': {
                                absPos.x = lg.lineGuide + lg.offset;
                                break;
                            }
                            case 'H': {
                                absPos.y = lg.lineGuide + lg.offset;
                                break;
                            }
                        }
                        break;
                    }
                }
            });
            e.target.absolutePosition(absPos);
        });

        layer.on('dragend', function (e) {
            // clear all previous lines on the screen
            layer.find('.guid-line').forEach((l) => l.destroy());
        });
    },

    DetachObjectSnapper: function (LayerNodeId) {

        CustomKonvaWrapper.UnsubscribeEvent(LayerNodeId, 'dragmove');
        CustomKonvaWrapper.UnsubscribeEvent(LayerNodeId, 'dragend');

        return true;

    }

}