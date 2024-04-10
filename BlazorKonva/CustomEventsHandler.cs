using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva
{
    //[EventHandler("oncustomevent", typeof(bool),
    //enableStopPropagation: true, enablePreventDefault: true)]
    public static class EventHandlers
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