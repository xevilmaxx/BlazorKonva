using BlazorKonva;
using Microsoft.AspNetCore.Components;

namespace BlazorKonvaTest.Components.Pages
{
    public partial class Home : ComponentBase
    {

        [Inject]
        private BlazorKonvaWrapper ExampleJsInterop { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //await ExampleJsInterop.Prompt("Test1");
            }
        }

    }
}
