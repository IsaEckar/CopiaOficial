using Microsoft.AspNetCore.Components;
using SEGES.Shared.Entities;

namespace SEGES.FrontEnd.Pages.DocTraceabilityTypes
{
    public partial class DocTraceabilityTypeCreate
    {
        private DocTraceabilityType traceabilityType = new();
        private FormWithName<DocTraceabilityType>? docTraceabilityTypeForm;

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        private async Task CreateAsync()
        {
            var responseHttp = await Repository.PostAsync("/api/DocTraceabilityType", traceabilityType);
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
            docTraceabilityTypeForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("/DocTraceabilityType");
        }
    }
}
