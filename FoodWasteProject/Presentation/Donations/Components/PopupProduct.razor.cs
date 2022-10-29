<!-----------------------------------------------------------------------------
    This document is for the US:
    - ALV-DO-1.2 Register product name, brand, due date, amount and weight
    - ALV-DO-1.3 Mark food restrictions
    - ALV-DO-1.6 Add more than one product to donation
    - ALV-DO-1.4 Select Food Type
    - ALV-DO-1.5 Select Product Type
    And was done by a joint effort by all members of ALV.
-------------------------------------------------------------------------------
    Receives input entered by user in the pop-up window and sends product
    data to DonationRegistration page.
------------------------------------------------------------------------------>
@* Project includes *@
@using Application.Products
@using Domain.Products.DTOs
@using Domain.Products.Entities
@using Domain.Donations.Entities
@using Presentation.Core.Components
@using Presentation.Products.Components
@using Presentation.Products.Models
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
        <DialogContent>
            <MudContainer Style=" max-height: 500px; overflow-y: scroll">
                <center>
                <!-- Product Name -->
                <MudItem md="30" lg="10">
                    <MudTextField @bind-Value="model.Name" Label="Nombre"
                    Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")
                    Class="InputStandard"
                    Counter="50" MaxLength="50" Immediate="true"
                    Variant="Variant.Outlined" Margin="Margin.Normal"
                    Required="true">
                    </MudTextField>
                </MudItem>
                <!-- Product Brand -->
                <MudItem md="20" lg="10">
                    <MudTextField @bind-Value="model.Brand" Label="Marca"
                    Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")
                    Class="InputStandard"
                    Counter="30" MaxLength="30" Immediate="true"
                    Variant="Variant.Outlined">
                    </MudTextField>
                </MudItem>
                <MudGrid Spacing="3" Justify="Justify.Center">
                    <!-- Product Weight -->
                    <MudItem md="4" lg="3">
                        <MudTextField @bind-Value="model.Weight" 
                        Label="Peso (g)" Required="true" Style=@(
                            $"--mud-palette-primary:{Colors.Blue.Accent3}")
                        Class="InputStandard" Immediate="true"
                        Variant="Variant.Outlined" Margin="Margin.Normal">
                        </MudTextField>
                    </MudItem>
                    <!-- Product Quantity -->
                    <MudItem md="4" lg="2">
                        <MudTextField @bind-Value="model.Quantity"
                        Style=@(
                            $"--mud-palette-primary:{Colors.Blue.Accent3}")
                        Class="InputStandard" Label="Cantidad" 
                        Immediate="true" Required="true"
                        Variant="Variant.Outlined" Margin="Margin.Normal">
                        </MudTextField>
                    </MudItem>
                    <!-- Product Expiration Date -->
                    <MudItem md="4" lg="5">
                        <MudDatePicker @bind-Date="Expiration"
                        Style=@(
                            $"--mud-palette-primary:{Colors.Blue.Accent3}")
                        Class="InputStandard" Color="Color.Info"
                        Variant="Variant.Outlined" Margin="Margin.Normal"
                        Label="Fecha de vencimiento" Required="true" />
                    </MudItem>
                </MudGrid>

                <MudGrid Spacing="3" Justify="Justify.Center">
                    <!-- Food Type -->
                    <MudItem md="20" lg="5">
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
                    <MudItem md="20" lg="5">
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

                <!-- Product Restrictions -->
                <div class="container" id="restriction-card-out" 
                align="left">
                <MudItem md="30" lg="10">
                    <div id="restriction_title">
                     <MudText Typo="Typo.h6">
                        Marcar restricciones alimentarias
                    </MudText>
                    </div>
                   
                    <!-- For every category in the list -->
                    @foreach (var category in _categories!)
                    {
                        <div class="checkbox">
                        <!-- Get the Name and the Icon -->
                        <MudText Typo="Typo.h6">
                            @category.Name
                            <img id="category_icon" src="@category.Icon"
                                Alt="@category.Name" Width="40"
                                Height="40" Fluid="true" />
                            <br>
                            <!-- For every allergen in each category -->
                            @foreach (var allergen in
                                _allergens[category.Name])
                            {
                                <!-- Build the corresponding checkbox, with
                                its description and name -->
                                <MudCheckBox Style=@(
                                $"--mud-palette-primary:{Colors.Blue.Accent3}")
                                @bind-Checked="@boolList[allergen.Name]"
                                Size="Size.Medium" Color="Color.Info">
                                </MudCheckBox>
                                <!--This is to show the description of
                                the allergen when the cursor is over it-->
                                <MudTooltip Text="@allergen.Description"
                                Arrow="true" Placement="Placement.Top">
                                    <MudText> @allergen.Name </MudText>
                                </MudTooltip>
                            }
                        </MudText>
                        </div>
                    }
                </MudItem>
                <br>
                </div>
                <br>
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
    public ProductModel model { get; set; } =
        new ProductModel("", "", "", 0, 0.0, "", DateTime.Today);

    // Declaring boolean values
    private bool _IsLoading = true;
    private bool correctExpiration = false;
    private bool validNumber = false;
    // private bool requiredFields = false;

    DateTime? Expiration = DateTime.Today.Date;

    // Declaring read only structures with defined values from database
    private IEnumerable<FoodTypeDTO>? _foodTypes;
    private IEnumerable<ProductType>? productTypes;
    private IEnumerable<AllergenCategory>? _categories;
    private Dictionary<string, List<Allergen>> _allergens =
        new Dictionary<string, List<Allergen>>();

    // Dictionary to store the booleans corresponding to each allergen checkbox
    private Dictionary<string, bool> boolList =
        new Dictionary<string, bool>();

    [CascadingParameter] MudDialogInstance? MudDialog { get; set; }
    void Cancel() => MudDialog!.Cancel();

    /*************************** On initialized ******************************/

    // Initializing all the lists and dictionaries
    protected override async Task OnInitializedAsync()
    {
        Expiration = model.Expiration;
        await readAllergensFromDatabase();
        await readProductTypesFromDatabase();
        await getFoodTypes();
        _IsLoading = false;
    }

    /************************* Reading from database *************************/

    // Gets allergens from database
    protected async Task readAllergensFromDatabase()
    {
        _categories = await AllergenService.GetCategoriesAsync();
        await fillAllergenDictionary();
        fillBooleanDictionary();
        foreach (var restriction in model.Restrictions)
        {
            boolList[restriction.FoodRestriction] = true;
        }
    }
    // Fills allergen dictionary with information from database
    private async Task fillAllergenDictionary()
    {
        foreach (var category in _categories!)
        {
            IEnumerable<Allergen> _allergenList = await
                AllergenService.GetAllergenByCategoryAsync(category.Name);
            List<Allergen> _allergenElements = _allergenList.ToList();
            _allergens.Add(category.Name, _allergenElements);

        }
    }

    // Fills the bool dictionary. It starts with false. 
    // It will become true according to the restrictions that the user marks.
    private void fillBooleanDictionary ()
    {
        foreach (var category in _categories!)
        {
            foreach (var allergen in _allergens[category.Name])
            {
                boolList.Add(allergen.Name, false);
            }
        }
    }

    // Gets product types from database
    private async Task readProductTypesFromDatabase() {
        productTypes = await ProductTypeService.GetProductTypesAsync();
    }

    // Gets food types from database
    private async Task getFoodTypes() {
        _foodTypes = await FoodTypeService.GetAllFoodTypesAsync();
    }

    /*************************** Register product ****************************/

    //Registers product into donation once it validates its values
    private async Task RegisterProduct()
    {
        model.Expiration = (DateTime)Expiration!;
        if(hasRequiredFields() == true)
        {
            if (hasValidNumbers() == true)
            {
                if (model.Expiration > DateTime.Today)
                {
                    correctExpiration = true;
                    //requiredFields = true;
                    validNumber = true;
                    saveSelectedRestrictions();
                    OpenRequiredDialog(true);
                    // Returns model to DonationRegistration
                    MudDialog!.Close(model);
                }
                else
                {
                    OpenExpiredDialog(correctExpiration);
                }
            }
        } else {
            OpenRequiredDialog(false);
        }
    }

    private bool hasRequiredFields()
    {
        if(model.Name != "" && model.FoodType != "" && model.ProdType != "") {
            return true;
        } else {
            return false;
        }
    }

    private bool hasValidNumbers()
    {
        if (model.Quantity == 0) {
            OpenCeroNumberDialog(
                "No se permite que la cantidad ingresada sea cero!");
            return false;
        }
        else if (model.Quantity < 0) {
            OpenNegativeNumberDialog(
                "No se permite que la cantidad ingresada sea negativa!");
            return false;
        } else if (model.Weight == 0.0) {
            OpenCeroNumberDialog(
                "No se permite que el peso ingresado sea cero!");
            return false;
        }
        else if (model.Weight < 0) {
            OpenNegativeNumberDialog(
                "No se permite que el peso ingresado sea negativo!");
            return false;
        }
        return true;
    }

    // Stores the restrictions that were marked in the database
    private void saveSelectedRestrictions()
    {
        model.Restrictions.Clear();
        foreach (var restriction in boolList.Keys)
        {
            Restriction _restriction = new Restriction(restriction);
            if (boolList[restriction] == true)
            {
                if (!model.Restrictions.Exists(
                p => p.FoodRestriction == restriction))
                {
                    model.Restrictions.Add(_restriction);
                }
            }
        }
    }

    // Opens approval or disapproval dialog when requirements are met or not
    private void OpenRequiredDialog(bool requiredFields)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        if (!requiredFields)
        {
            DialogService.Show<RequiredFieldsError>(
                "Debe llenar los espacios obligatorios", options);
        }
    }

    // Shows if expired date is valid or not
    private void OpenExpiredDialog(bool correctExpiration)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        if (!correctExpiration)
        {
            DialogService.Show<WrongDateError>(
                "La fecha de caducidad ya pasó", options);
        }
    }

    // Shows if numeric values are negative or not
    private void OpenNegativeNumberDialog(string message) {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        if(!validNumber) {
            DialogService.Show<NegativeNumberError>(message, options);
        }
    }

    // Shows if numeric values are cero or not
    private void OpenCeroNumberDialog(string message) {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        if(!validNumber) {
            DialogService.Show<CeroNumberError>(message, options);
        }
    }
}