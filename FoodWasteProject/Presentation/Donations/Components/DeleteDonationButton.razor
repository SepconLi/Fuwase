
@* Injecting project services *@
@inject IDonationService DonationService
@inject IDialogService DialogService
@inject NavigationManager NavManager

<MudIconButton 
    Icon="@Icons.Material.Filled.Delete" 
    @onclick="askConfirmation"
    Variant="Variant.Filled" 
    Color="Color.Error" 
    Size="Size.Medium" >
</MudIconButton>

@code {
    [Parameter]
    public int _donationId { get; set; }
    [Parameter]
    public string _description { get; set; } = ""; 

    private async void askConfirmation()
    {
        string state = "";
        bool? result = await DialogService.ShowMessageBox(
            "Eliminar", 
           "¿Está seguro que desea eliminar la donación "+_description+
            "? Esta acción no puede ser revertida.",
            yesText:"Eliminar", cancelText:"Cancelar");
        state= result==null ? "Cancelled" : "Deleted";
        StateHasChanged();

        if (state == "Deleted")
        {
            await DonationService.HandleDonationDelete(_donationId);
            GoBack();
        }
    }
    private void GoBack()
    {
        NavManager.NavigateTo("/refresh/history");
    }
}
