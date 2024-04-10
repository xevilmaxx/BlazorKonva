using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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