using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SEGES.FrontEnd.Repositories;
using SEGES.Shared.Entities;

namespace SEGES.FrontEnd.Pages.HUPublicationStatuses
{
    public partial class HUPublicationStatusCreate
    {
        private HUPublicationStatus hUPublicationStatus = new();
        private FormWithName<HUPublicationStatus>? publicationStatusForm;

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        private async Task CreateAsync()
        {
            var responseHttp = await Repository.PostAsync("/api/hupublicationstatus", hUPublicationStatus);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message);
                return;
            }

            Return();

            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado con éxito");

        }

        private void Return()
        {
            publicationStatusForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("/hupublicationstatus");
        }
    }
}
