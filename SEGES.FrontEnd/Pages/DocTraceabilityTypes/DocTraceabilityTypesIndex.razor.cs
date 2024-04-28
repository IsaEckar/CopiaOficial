using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SEGES.FrontEnd.Repositories;
using SEGES.Shared.Entities;
using System.Net;

namespace SEGES.FrontEnd.Pages.DocTraceabilityTypes
{
    public partial class DocTraceabilityTypesIndex
    {

        private int currentPage = 1;
        private int totalPages;

        [Inject] private IRepository Repository { get; set; } = null!;

        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Parameter, SupplyParameterFromQuery] public string Page { get; set; } = string.Empty;

        public List<DocTraceabilityType>? DocTraceabilityTypes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task SelectedPageAsync(int page)
        {
            currentPage = page;
            await LoadAsync(page);
        }

        private async Task LoadAsync(int page = 1)
        {
            if (!string.IsNullOrWhiteSpace(Page))
            {
                page = Convert.ToInt32(Page);
            }

            var ok = await LoadListAsync(page);
            if (ok)
            {
                await LoadPagesAsync();
            }
        }

        private async Task<bool> LoadListAsync(int page)
        {
            var url = $"api/doctraceabilitytype?page={page}";


            var responseHttp = await Repository.GetAsync<List<DocTraceabilityType>>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return false;
            }
            DocTraceabilityTypes = responseHttp.Response;
            return true;
        }

        private async Task LoadPagesAsync()
        {
            var url = "api/doctraceabilitytype/totalPages";


            var responseHttp = await Repository.GetAsync<int>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            totalPages = responseHttp.Response;
        }
        public async Task DeleteAsync(DocTraceabilityType type)
        {
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = $"¿Estas seguro de querer borrar el país: {type.Name}?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
            });
            var confirm = string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }

            var responseHttp = await Repository.DeleteAsync<DocTraceabilityType>($"api/doctraceabilitytype/{type.DocTraceabilityTypeId}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/doctraceabilitytype");
                }
                else
                {
                    var mensajeError = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
                }
                return;
            }

            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro borrado con éxito.");
        }

    }
}
