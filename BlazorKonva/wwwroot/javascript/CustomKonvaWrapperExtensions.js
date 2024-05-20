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

    },

    //////////////////////////
    //DRAW RECT
    //////////////////////////
    //https://stackoverflow.com/questions/49758261/draw-rectangle-with-mouse-and-fill-with-color-on-mouseup

    //unable to mod vars by ref in this way
    //DrawRect_StartDrag: function (posIn, DrawRect_PosStart, DrawRect_PosNow){
    //    DrawRect_PosStart = { x: posIn.x, y: posIn.y };
    //    DrawRect_PosNow = { x: posIn.x, y: posIn.y };
    //},

    DrawRect_UpdateDrag: function (posIn, DrawRect_r2, stage, DrawRect_PosStart, DrawRect_PosNow) {

        // update rubber rect position
        DrawRect_PosNow = { x: posIn.x, y: posIn.y };

        var posRect = CustomKonvaWrapperExtensions.DrawRect_Reverse(DrawRect_PosStart, DrawRect_PosNow);

        DrawRect_r2.x(posRect.x1);
        DrawRect_r2.y(posRect.y1);
        DrawRect_r2.width(posRect.x2 - posRect.x1);
        DrawRect_r2.height(posRect.y2 - posRect.y1);
        DrawRect_r2.visible(true);

        stage.draw(); // redraw any changes.

    },

    // reverse co-ords if user drags left / up
    DrawRect_Reverse: function (r1, r2) {
        var r1x = r1.x, r1y = r1.y, r2x = r2.x, r2y = r2.y, d;
        if (r1x > r2x) {
            d = Math.abs(r1x - r2x);
            r1x = r2x; r2x = r1x + d;
        }
        if (r1y > r2y) {
            d = Math.abs(r1y - r2y);
            r1y = r2y; r2y = r1y + d;
        }
        return ({ x1: r1x, y1: r1y, x2: r2x, y2: r2y }); // return the corrected rect.     
    },

    DrawRect_ListenEvents: function () {

        var DrawRect_PosStart = { x: 0, y: 0 };
        var DrawRect_PosNow = { x: 0, y: 0 };
        var DrawRect_Mode = '';

        // Set up the canvas and shapes
        var s1 = new Konva.Stage({ container: 'container1', width: 300, height: 200 });
        var layer1 = new Konva.Layer({ draggable: false });
        s1.add(layer1);

        // draw a background rect to catch events.
        var r1 = new Konva.Rect({ x: 0, y: 0, width: 300, height: 200, fill: 'gold' });
        layer1.add(r1);

        // draw a rectangle to be used as the rubber area
        var DrawRect_r2 = new Konva.Rect({ x: 0, y: 0, width: 0, height: 0, stroke: 'red', dash: [2, 2] });

        DrawRect_r2.listening(false); // stop r2 catching our mouse events.
        layer1.add(DrawRect_r2);

        s1.draw(); // First draw of canvas.

        // start the rubber drawing on mouse down.
        r1.on('mousedown', function (e) {
            DrawRect_Mode = 'drawing';
            //CustomKonvaWrapperExtensions.DrawRect_StartDrag({ x: e.evt.layerX, y: e.evt.layerY }, DrawRect_PosStart, DrawRect_PosNow);
            DrawRect_PosStart = { x: e.evt.layerX, y: e.evt.layerY };
            DrawRect_PosNow = { x: e.evt.layerX, y: e.evt.layerY };
        });

        // update the rubber rect on mouse move - note use of 'mode' var to avoid drawing after mouse released.
        r1.on('mousemove', function (e) {
            if (DrawRect_Mode === 'drawing') {
                CustomKonvaWrapperExtensions.DrawRect_UpdateDrag({ x: e.evt.layerX, y: e.evt.layerY }, DrawRect_r2, s1, DrawRect_PosStart, DrawRect_PosNow);
            }
        });

        // here we create the new rect using the location and dimensions of the drawing rect.
        r1.on('mouseup', function (e) {
            DrawRect_Mode = '';
            DrawRect_r2.visible(false);
            var newRect = new Konva.Rect({
                x: DrawRect_r2.x(),
                y: DrawRect_r2.y(),
                width: DrawRect_r2.width(),
                height: DrawRect_r2.height(),
                fill: 'red',
                listening: false
            });
            layer1.add(newRect);
            s1.draw();
        }); 
    }

}