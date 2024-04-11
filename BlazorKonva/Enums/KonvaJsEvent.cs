using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.Enums
{
    public class KonvaJsEvent
    {
        #region Common Events

        /// <summary>
        /// Triggered on a click (mouse down and up on the same shape).
        /// </summary>
        public const string Click = "click";

        /// <summary>
        /// Triggered on a double click.
        /// </summary>
        public const string Dblclick = "dblclick";

        /// <summary>
        /// Triggered on a mouse down event.
        /// </summary>
        public const string Mousedown = "mousedown";

        /// <summary>
        /// Triggered on a mouse up event.
        /// </summary>
        public const string Mouseup = "mouseup";

        /// <summary>
        /// Triggered on a mouse move event over the shape or its parent chain.
        /// </summary>
        public const string Mousemove = "mousemove";

        /// <summary>
        /// Triggered when the mouse enters the node (or its parent chain).
        /// </summary>
        public const string Mouseover = "mouseover";

        /// <summary>
        /// Triggered when the mouse leaves the node (or its parent chain).
        /// </summary>
        public const string Mouseout = "mouseout";

        /// <summary>
        /// Triggered on a touch start event (mobile devices).
        /// </summary>
        public const string Touchstart = "touchstart";

        /// <summary>
        /// Triggered on a touch move event (mobile devices).
        /// </summary>
        public const string Touchmove = "touchmove";

        /// <summary>
        /// Triggered on a touch end event (mobile devices).
        /// </summary>
        public const string Touchend = "touchend";

        /// <summary>
        /// Triggered on a tap (touch down and up on the same shape) on mobile devices.
        /// </summary>
        public const string Tap = "tap";

        /// <summary>
        /// Triggered on a double tap on mobile devices.
        /// </summary>
        public const string Dbltap = "dbltap";

        /// <summary>
        /// Triggered on a mouse wheel event (may require vendor prefixes).
        /// </summary>
        public const string Wheel = "wheel";

        /// <summary>
        /// Triggered on a right-click context menu event.
        /// </summary>
        public const string Contextmenu = "contextmenu";

        #endregion Common Events

        #region Transform Events

        /// <summary>
        /// Triggered when a node starts dragging or scaling.
        /// </summary>
        public const string Transformstart = "transformstart";

        /// <summary>
        /// Triggered continuously as a node is being dragged or scaled.
        /// </summary>
        public const string Transform = "transform";

        /// <summary>
        /// Triggered when dragging or scaling a node ends.
        /// </summary>
        public static readonly string Transformend = "transformend";

        #endregion Transform Events

        #region Drag Events

        /// <summary>
        /// Triggered when a node starts being dragged.
        /// </summary>
        public const string Dragstart = "dragstart";

        /// <summary>
        /// Triggered continuously as a node is being dragged.
        /// </summary>
        public const string Dragmove = "dragmove";

        /// <summary>
        /// Triggered when dragging a node ends.
        /// </summary>
        public static readonly string Dragend = "dragend";

        #endregion Drag Events

        #region Stage-Specific Events

        /// <summary>
        /// Triggered on a click that doesn't directly hit a specific Konva node, but hit the canvas area within the Stage.
        /// </summary>
        public const string ContentClick = "contentClick";

        /// <summary>
        /// Triggered on a double click that doesn't directly hit a specific Konva node.
        /// </summary>
        public const string ContentDblclick = "contentDblclick";

        /// <summary>
        /// Triggered on a mouse down event on the canvas area within the Stage (not directly on a node).
        /// </summary>
        public const string ContentMousedown = "contentMousedown";

        /// <summary>
        /// Triggered on a mouse up event on the canvas area within the Stage (not directly on a node).
        /// </summary>
        public const string ContentMouseup = "contentMouseup";

        /// <summary>
        /// Triggered on a mouse move event on the canvas area within the Stage (not directly on a node).
        /// </summary>
        public const string ContentMousemove = "contentMousemove";

        /// <summary>
        /// Triggered when the mouse enters the Stage canvas area.
        /// </summary>
        public const string ContentMouseover = "contentMouseover";

        /// <summary>
        /// Triggered when the mouse leaves the Stage canvas area.
        /// </summary>
        public const string ContentMouseout = "contentMouseout";

        /// <summary>
        /// Triggered on a touch start event on the Stage canvas area (not directly on a node).
        /// </summary>
        public const string ContentTouchstart = "contentTouchstart";

        /// <summary>
        /// Triggered on a touch move event on the Stage canvas area (not directly on a node).
        /// </summary>
        public const string ContentTouchmove = "contentTouchmove";

        /// <summary>
        /// Triggered on a touch end event on the Stage canvas area (not directly on a node).
        /// </summary>
        public const string ContentTouchend = "contentTouchend";

        /// <summary>
        /// Triggered on a tap (touch down and up) on the Stage canvas area (not directly on a node).
        /// </summary>
        public const string ContentTap = "contentTap";

        /// <summary>
        /// Triggered on a double tap on the Stage canvas area (not directly on a node).
        /// </summary>
        public const string ContentDbltap = "contentDbltap";

        /// <summary>
        /// Triggered on a mouse wheel event on the Stage canvas area (not directly on a node).
        /// </summary>
        public const string ContentWheel = "contentWheel";

        /// <summary>
        /// Triggered on a right-click context menu event on the Stage canvas area.
        /// </summary>
        public const string ContentContextmenu = "contentContextmenu";

        #endregion

        #region SpecialEvents
        // Special Events

        /// <summary>
        /// Triggered when a node's visibility changes.
        /// </summary>
        public const string VisibleChange = "visibleChange";

        /// <summary>
        /// Triggered when a node's listening state changes (whether it receives events or not).
        /// </summary>
        public const string ListeningChange = "listeningChange";

        /// <summary>
        /// Triggered when a node's ID changes.
        /// </summary>
        public const string IdChange = "idChange";

        /// <summary>
        /// Triggered when a node's name changes.
        /// </summary>
        public const string NameChange = "nameChange";

        /// <summary>
        /// Triggered when a node's scale changes.
        /// </summary>
        public const string ScaleChange = "scaleChange";

        /// <summary>
        /// Triggered when a node's position changes (x or y).
        /// </summary>
        public const string PositionChange = "positionChange";

        /// <summary>
        /// Triggered when a node's anchor point changes.
        /// </summary>
        public const string AnchorChange = "anchorChange";

        /// <summary>
        /// Triggered when a node's rotation changes.
        /// </summary>
        public const string RotationChange = "rotationChange";

        #endregion

    }
}
