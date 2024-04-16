using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Node;
using BlazorKonva.KonvaClasses.Rect;
using BlazorKonva.KonvaClasses.Stage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.BlazorComponents
{
    public partial class Rect : ComponentBase
    {

        [Inject]
        public IJSRuntime JS { get; set; }

        [CascadingParameter]
        public EventCallback OnParentRendered { get; set; }

        [CascadingParameter]
        public KonvaNode ParentNode { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public KonvaRectConfigsDTO Configs { get; set; }

        private KonvaRect CurNode { get; set; } = new KonvaRect();

        public Rect()
        {
            OnParentRendered = new EventCallback(this, HandleOnParentRendered);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender == false)
            {
                return;
            }

        }

        private async void HandleOnParentRendered()
        {
            await CurNode
                .SetJsRuntime(JS)
                .SetConfigs(Configs)
                .SetLayer((KonvaLayer)ParentNode)
                .Build();
        }

    }
}
