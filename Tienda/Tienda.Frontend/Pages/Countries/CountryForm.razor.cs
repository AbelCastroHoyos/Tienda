using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Tienda.Shared.Entities;

namespace Tienda.Frontend.Pages.Countries
{
    public partial class CountryForm
    {
        private EditContext editContext = null!;
        [Inject]
        public SweetAlertService SweetAlertService { get; set; } = null!;

        [EditorRequired, Parameter]
        public Country Country { get; set; } = null!;

        [EditorRequired, Parameter]
        public EventCallback OnValidSubmit { get; set; }

        [EditorRequired, Parameter]
        public EventCallback ReturnAction { get; set; }

        public bool FormPostedSuccessfull { get; set; }

        protected override void OnInitialized()
        {
            editContext = new(Country);
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasEdited = editContext.IsModified();
            if (!formWasEdited || FormPostedSuccessfull)
            {
                return;
            }
            else
            {
                var result = await SweetAlertService.FireAsync(new SweetAlertOptions
                {
                    Title = "Confirmación",
                    Text = "Hay cambios sin guardar. Realmente desea salir?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true
                });
                var confirm = string.IsNullOrEmpty(result.Value);
                if (!confirm)
                {
                    return;
                }
            }
            context.PreventNavigation();
        }
    }
}
