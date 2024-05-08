using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using SEGES.FrontEnd.Repositories;
using SEGES.FrontEnd.Shared;
using SEGES.Shared.Entities;
using System.Diagnostics.Metrics;
using System.Net;

namespace SEGES.FrontEnd.Pages.Countries
{
    [Authorize(Roles = "Admin")]
    public partial class CountryEdit
    {

        private Country? country;
        private FormWithName<Country>? countryForm;

        [Inject] private IRepository repository { get; set; } = null!;
        [Inject] private SweetAlertService sweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager navigationManager { get; set; } = null!;

        [EditorRequired, Parameter] public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var responseHttp = await repository.GetAsync<Country>($"/api/countries/{Id}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo("/countries");
                }
                else
                {
                    var messsage = await responseHttp.GetErrorMessageAsync();
                    await sweetAlertService.FireAsync("Error", messsage, SweetAlertIcon.Error);
                }
            }
            else
            {
                country = responseHttp.Response;
            }
        }

        private async Task EditAsync()
        {
            var responseHttp = await repository.PutAsync("/api/countries", country);
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
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Cambios guardados con éxito.");
        }

        private void Return()
        {
            countryForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo("/countries");
        }

    }
}
