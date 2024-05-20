using BlazorKonva.Helpers;
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

        [CascadingParameter(Name = "OnParentRendered")]
        public EventCallback OnParentRendered { get; set; }

        [CascadingParameter(Name = "OnSetParent")]
        public EventCallback<KonvaNode> OnSetParent { get; set; }

        [CascadingParameter(Name = "OnParentRendered2")]
        public EventHandler OnParentRendered2 { get; set; }

        [CascadingParameter(Name = "ParentNode")]
        public KonvaNode ParentNode { get; set; }

        [CascadingParameter(Name = "TestCascade")]
        //[CascadingParameter]
        public string TestCascade { get; set; }

        [Parameter]
        public KonvaLayerConfigsDTO Configs { get; set; }

        private KonvaLayer CurLayer { get; set; } = new KonvaLayer();

        protected override void OnInitialized()
        {
            //OnSetParent = new EventCallback(this, HandleOnParentRendered);
            //OnSetParent = new EventCallback(this, () =>
            //{
            //    ParentNode = g;
            //});

            //OnParentRendered = new EventCallback(this, HandleOnParentRendered);
            //OnParentRendered2 += (_, _) =>
            //{

            //};

            //SequencerSingleton.Instance.Value.OnStageLoaded += (_, _) => 
            //{ 
            //    HandleOnParentRendered(); 
            //};

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender == false)
            {
                return;
            }



            //ParentNode = CurLayer;

            //if (OnParentRendered != null)
            //{
            //    OnParentRendered.Invoke(this, null);
            //}

            await CurLayer
                .SetJsRuntime(JS)
                .SetConfigs(Configs)
                //.SetStage((KonvaStage)ParentNode)
                .Build();

            await ParentNode.AddNode(CurLayer);

        }

        private async void HandleOnParentRendered()
        {
            await CurLayer
                .SetJsRuntime(JS)
                .SetConfigs(Configs)
                .SetStage((KonvaStage)ParentNode)
                .Build();
            SequencerSingleton.Instance.Value.OnLayerLoaded.Invoke(this, null);
        }

    }
}
