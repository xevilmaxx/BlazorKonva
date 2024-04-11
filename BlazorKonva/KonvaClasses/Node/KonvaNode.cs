using BlazorKonva.KonvaClasses.Rect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.KonvaClasses.Node
{
    public abstract class KonvaNode
    {
        public abstract KonvaNodeConfigsDTO CommonConfigs { get; set; }
    }
}
