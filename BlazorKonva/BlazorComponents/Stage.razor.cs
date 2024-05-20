using BlazorKonva.Helpers;
using BlazorKonva.KonvaClasses.Node;
using BlazorKonva.KonvaClasses.Stage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.BlazorComponents
{
    public partial class Stage : ComponentBase
    {

        [Inject]
        public BlazorKonvaWrapper BKW { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string ContainerId { get; set; } = Guid.NewGuid().ToString();

        [Parameter]
        public KonvaStageConfigsDTO Configs { get; set; }

        public EventCallback OnParentRendered { get; set; }
        public EventHandler OnParentRendered2 { get; set; }

        //[CascadingParameter]
        //public KonvaNode ParentNode { get; set; }

        //[CascadingParameter(Name = "TestCascade")]
        //public string TestCascade { get; set; }

        public KonvaStage CurStage { get; private set; } = new KonvaStage();

        //public Stage()
        //{
        //    //TestCascade = "TestCascade";
        //}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //TestCascade = "TestCascade";
            if (firstRender == false)
            {
                return;
            }

            await BKW.Init();

            Configs.ContainerId = ContainerId;

            //ParentNode = CurStage;

            await CurStage
                .SetJsRuntime(JS)
                .SetConfigs(Configs)
                .Build();

            //await OnParentRendered.InvokeAsync();

            //SequencerSingleton.Instance.Value.OnStageLoaded.Invoke(this, null);

            //OnParentRendered2.Invoke(this, null);
        }

    }
}
