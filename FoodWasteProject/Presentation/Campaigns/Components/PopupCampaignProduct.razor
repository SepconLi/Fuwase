<!-----------------------------------------------------------------------------
This document is for the US: ALV-DO-4.1 Create a donation campaign
    and was done by Jimena Gdur Vargas.
-------------------------------------------------------------------------------
    Receives input entered by user in the pop-up window and sends product
    data to CampaignRegistration page.
------------------------------------------------------------------------------>

@* Project includes *@
@using Application.Products
@using Domain.Products.DTOs
@using Domain.Products.Entities
@using Domain.Donations.Entities
@using Presentation.Core.Components
@using Presentation.Products.Components
@using Presentation.Products.Models
@using Presentation.Donations.Components

@* System includes *@
@using System.Linq;

@* Injecting project services *@
@inject IDialogService DialogService
@inject IAllergenService AllergenService
@inject IProductTypeService ProductTypeService
@inject IFoodTypeService FoodTypeService

<link href="/css/components/InputStandard.css" rel="stylesheet" />

@if (_IsLoading)
{
    <PopUpSkeleton></PopUpSkeleton>
}
else
{
    <MudDialog>
        <!-- Input forms -->
        <DialogContent>
            <MudContainer Style=" max-height: 500px; overflow-y: scroll">
                <center>
                <!-- Product Name -->
                <MudItem md="30" lg="12">
                    <MudTextField @bind-Value="model.Name" Label="Nombre"
                    Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")
                    Class="InputStandard"
                    Counter="50" MaxLength="50" Immediate="true"
                    Variant="Variant.Outlined" Margin="Margin.Normal"
                    Required="true">
                    </MudTextField>
                </MudItem>

                <MudGrid Spacing="3" Justify="Justify.Center">
                    <!-- Food Type -->
                    <MudItem md="20" lg="6">
                        <MudSelect @bind-Value="model.FoodType" Dense="true"
                        Style=@(
                            $"--mud-palette-primary:{Colors.Blue.Accent3}")
                        T="string" Label="Tipo de alimento" Required="true"
                        Variant="Variant.Outlined" Margin="Margin.Normal" 
                        AnchorOrigin="Origin.BottomCenter">
                            @foreach (var type in _foodTypes!)
                            {
                                <MudSelectItem Value="@(type.Name)" />
                            }
                        </MudSelect>
                    </MudItem>
                    <!-- Product Type -->
                    <MudItem md="20" lg="6">
                        <MudSelect @bind-Value="model.ProdType" Dense="true"
                        Style=@(
                            $"--mud-palette-primary:{Colors.Blue.Accent3}")
                        T="string" Label="Tipo de producto" 
                        Required="true" Variant="Variant.Outlined" 
                        Margin="Margin.Normal" 
                        AnchorOrigin="Origin.BottomCenter">
                            @foreach (var type in productTypes!)
                            {
                                <MudSelectItem Value="@(type.Name)" />
                            }
                        </MudSelect>
                    </MudItem>
                </MudGrid>
                <br>
                <MudGrid Spacing="3" Justify="Justify.Center">
                    <!-- Product Quantity -->
                    <MudItem md="4" lg="4">
                        <MudTextField @bind-Value="model.Goal"
                        Style=@(
                            $"--mud-palette-primary:{Colors.Blue.Accent3}")
                        Class="InputStandard" Label="Meta de recolección"
                        Immediate="true" Required="true"
                        Variant="Variant.Outlined" Margin="Margin.Normal">
                        </MudTextField>
                    </MudItem>
                    <!-- Product Initial Donation -->
                    <MudItem md="4" lg="4">
                        <MudTextField @bind-Value="model.Quantity"
                        Style=@(
                            $"--mud-palette-primary:{Colors.Blue.Accent3}")
                        Class="InputStandard" Label="Donacion Inicial"
                        Immediate="true" Required="true"
                        Variant="Variant.Outlined" Margin="Margin.Normal">
                        </MudTextField>
                    </MudItem>
                    <!-- Product Weight -->
                    <MudItem md="4" lg="4">
                        <MudTextField @bind-Value="model.Weight"
                        Style=@(
                            $"--mud-palette-primary:{Colors.Blue.Accent3}")
                        Class="InputStandard" Label="Peso deseado (g)"
                        Immediate="true" Required="true"
                        Variant="Variant.Outlined" Margin="Margin.Normal">
                        </MudTextField>
                    </MudItem>
                </MudGrid>
                </center>
                <br>
            </MudContainer>
        </DialogContent>
        <!-- Buttons -->
        <DialogActions>
            <MudButton OnClick="Cancel">Cancelar</MudButton>
            <MudButton Variant="Variant.Filled" Color="Color.Success"
                   OnClick="RegisterProduct">Registrar producto</MudButton>
        </DialogActions>
    </MudDialog>
}

@code {
    [Parameter]
    public ProductModel model { get; set; } = new ProductModel();

    // Declaring boolean values
    private bool _IsLoading = true;
    // private bool validNumber = false;

    // Declaring read only structures with defined values from database
    private IEnumerable<FoodTypeDTO>? _foodTypes;
    private IEnumerable<ProductType>? productTypes;

    // Declaring components for dialog
    [CascadingParameter] MudDialogInstance? MudDialog { get; set; }
    void Cancel() => MudDialog!.Cancel();

    /*************************** On initialized ******************************/

    // Initializing all the lists and dictionaries
    protected override async Task OnInitializedAsync()
    {
        await readProductTypesFromDatabase();
        await getFoodTypes();
        _IsLoading = false;
    }

    /************************* Reading from database *************************/

    // Gets product types from database
    private async Task readProductTypesFromDatabase()
    {
        productTypes = await ProductTypeService.GetProductTypesAsync();
    }

    // Gets food types from database
    private async Task getFoodTypes()
    {
        _foodTypes = await FoodTypeService.GetAllFoodTypesAsync();
    }

    /*************************** Register product ****************************/

    // Registers product into donation once it validates its values
    private async Task RegisterProduct()
    {
        if(hasRequiredFields() == true)
        {
            if (hasValidNumbers() == true)
            {
                // validNumber = true;
                // Returns model to CampaignRegistration
                MudDialog!.Close(model);
            }
            else
            {
                // validNumber = false;
            }
        }
        else
        {
            // validNumber = false;
            OpenRequiredDialog();
        }
    }

    private bool hasRequiredFields()
    {
        if(model.Name != "" && model.FoodType != "" && 
            model.ProdType != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /***************************** Error messages ****************************/

    private bool hasValidNumbers()
    {
        if (model.Goal == 0)
        {
            OpenCeroNumberDialog(
                "No se permite que la meta ingresada sea cero");
            return false;
        }
        else if (model.Goal < 0)
        {
            OpenNegativeNumberDialog(
                "No se permite que la meta ingresada sea negativa!");
            return false;
        } else if (model.Weight == 0.0) {
            OpenCeroNumberDialog(
                "No se permite que el peso ingresado sea cero");
            return false;
        }
        else if (model.Weight < 0) {
            OpenNegativeNumberDialog(
                "No se permite que el peso ingresado sea negativo");
            return false;
        }
        else if (model.Quantity < 0)
        {
            OpenNegativeNumberDialog(
                "No se permite que el la donación inicial sea negativo");
            return false;
        }
        else if (model.Quantity >= model.Goal)
        {
            OpenExceedingLimitDialog("Ese valor excede el límite");
            return false;
        }
        return true;
    }

    // Opens approval or disapproval dialog when requirements are met or not
    private void OpenRequiredDialog()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        DialogService.Show<RequiredFieldsError>(
            "Debe llenar los espacios obligatorios", options);
    }

    // Shows if numeric values are negative or not
    private void OpenNegativeNumberDialog(string message)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        DialogService.Show<NegativeNumberError>(message, options);
    }

    // Shows if numeric values are cero or not
    private void OpenCeroNumberDialog(string message)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        DialogService.Show<CeroNumberError>(message, options);
    }

    // Shows if value exceeds limit
    private void OpenExceedingLimitDialog(string message)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        DialogService.Show<ExceedingValueError>(message, options);
    }
}