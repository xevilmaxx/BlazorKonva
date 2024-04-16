using BlazorKonva.KonvaClasses.Layer;
using BlazorKonva.KonvaClasses.Node;
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
    public partial class Layer : ComponentBase
    {

        //[CascadingParameter]
        //public EventCallback OnParentRendered { get; set; } = new EventCallback(null, HandleOnParentRendered);

        [Inject]
        public IJSRuntime JS { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        public EventCallback OnParentRendered { get; set; }

        [CascadingParameter]
        public KonvaNode ParentNode { get; set; }

        [Parameter]
        public KonvaLayerConfigsDTO Configs { get; set; }

        private KonvaLayer CurLayer { get; set; } = new KonvaLayer();

        public Layer()
        {
            OnParentRendered = new EventCallback(this, HandleOnParentRendered);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender == false)
            {
                return;
            }

            ParentNode = CurLayer;

            //if (OnParentRendered != null)
            //{
            //    OnParentRendered.Invoke(this, null);
            //}
        }

        private async void HandleOnParentRendered()
        {
            await CurLayer
                .SetJsRuntime(JS)
                .SetConfigs(Configs)
                .SetStage((KonvaStage)ParentNode)
                .Build();
        }

    }
}
