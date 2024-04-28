using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SEGES.FrontEnd.Repositories;
using SEGES.FrontEnd.Shared;
using SEGES.Shared.Entities;
using System.Diagnostics.Metrics;

namespace SEGES.FrontEnd.Pages.Countries
{
    public partial class CountryCreate
    {
        private Country country = new();
        private FormWithName<Country>? countryForm;

        [Inject] private IRepository repository { get; set; } = null!;
        [Inject] private SweetAlertService sweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager navigationManager { get; set; } = null!;

        private async Task CreateAsync()
        {
            var responseHttp = await repository.PostAsync("/api/countries", country);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message);
                return;
            }

            Return();

            var toast = sweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado con éxito");
            //await sweetAlertService.FireAsync(new SweetAlertOptions
            //{
            //    Toast = true,
            //    Position = SweetAlertPosition.BottomEnd,
            //    ShowConfirmButton = true,
            //    Timer = 10000,
            //    Icon = SweetAlertIcon.Success,
            //    Title = "Éxito",
            //    Text = "Registro creado con éxito"
            //});

        }

        private void Return()
        {
            countryForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo("/countries");
        }
    }
}
