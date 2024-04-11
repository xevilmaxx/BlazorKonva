using Microsoft.JSInterop;

namespace BlazorKonva.Helpers
{
    //ForNow and probably in future wont be used
    //[EventHandler("oncustomevent", typeof(bool),
    //enableStopPropagation: true, enablePreventDefault: true)]
    /// <summary>
    /// Javascript could invoke this by: 
    /// <para/>
    /// DotNet.invokeMethodAsync('BlazorKonva', 'OnMouseOver');
    /// </summary>
    public static class GlobalJsEvtsHandler
    {

        [JSInvokable]
        public static void OnMouseOver()
        {

        }


        [JSInvokable]
        public static void OnMouseOut()
        {

        }

    }

}