using BlazorKonva;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorKonvaTest.Components.Pages
{
    public partial class Weather : ComponentBase
    {
        [Inject]
        public BlazorKonvaWrapper BKW { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender == false)
            {
                return;
            }

            //await BKW.Init();

            await BuildWay0();

        }
        private async Task BuildWay0()
        {

            await BKW.jsRuntime.InvokeAsync<dynamic>("CustomKonvaWrapperExtensions.DrawRect_ListenEvents");

        }
    }
}
