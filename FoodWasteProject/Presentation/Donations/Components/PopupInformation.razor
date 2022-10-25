<!-----------------------------------------------------------------------------
    This document is for the US:
    - ALV-DO-1.9 Show products added to a donation
    And was done by a joint effort by all members of ALV.
-------------------------------------------------------------------------------
    Displays product's information as read-only.
------------------------------------------------------------------------------>

@* Project includes *@
@using Application.Products
@using Domain.Products.Entities
@using Domain.Donations.Entities
@using Presentation.Core.Components
@using Presentation.Products.Components
@using Presentation.Products.Models

@* System includes *@
@using System.Linq;

@* Injecting project services *@
@inject IDialogService DialogService
@inject IProductService ProductService
@inject IAllergenService AllergenService
@inject IProductTypeService ProductTypeService
@inject IFoodTypeService FoodTypeService

@if (_isLoading)
{
    <PopUpSkeleton></PopUpSkeleton>
}
else{
<MudDialog>
    <TitleContent>
        <MudText Typo="Typo.h5" Align="Align.Center">
            Datos del Producto
        </MudText>
    </TitleContent>
    <DialogContent >
        <MudContainer Style=" max-height: 500px; overflow-y: scroll">
            <center>     
                <!-- Product Name -->        
                <MudItem md="30" lg="10">
                    <MudTextField @bind-Value="product!.Name" Label="Nombre"
                        Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")
                        Immediate="true" 
                        Variant="Variant.Outlined" Margin="Margin.Normal"
                        ReadOnly="true">            
                    </MudTextField>
                </MudItem>

                <!-- Product Brand --> 
                <MudItem  md="20" lg="10">
                    <MudTextField @bind-Value="product!.Brand" Label="Marca"
                            Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")
                            Immediate="true"
                        Variant="Variant.Outlined" ReadOnly = "true">
                    </MudTextField>
                </MudItem>

                <MudGrid Spacing="3" Justify="Justify.Center">
                    <!-- Product Weight --> 
                    <MudItem md="4" lg="3">
                        <MudTextField @bind-Value="product!.Weight" 
                            Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")
                            Label="Peso (g)" Immediate="true" ReadOnly="true"
                            Variant="Variant.Outlined" Margin="Margin.Normal">
                        </MudTextField>
                    </MudItem>
                    <!-- Product Quantity --> 
                    <MudItem md="4" lg="2">
                        <MudTextField @bind-Value="product!.Quantity"
                            Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")
                            Label="Cantidad" Immediate="true" ReadOnly="true"
                            Variant="Variant.Outlined" Margin="Margin.Normal">
                        </MudTextField>
                    </MudItem>
                    <!-- Product Expiration Date --> 
                    <MudItem  md="4" lg="5" >
                        <MudDatePicker @bind-Date="Expiration" 
                        Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")
                        Variant="Variant.Outlined" Margin="Margin.Normal" 
                        Label="Fecha de vencimiento" ReadOnly="true"/>
                    </MudItem>
                </MudGrid>

                <MudGrid Spacing="3" Justify="Justify.Center">
                    <!-- Food Type --> 
                    <MudItem md="20" lg="5">
                        <MudTextField @bind-Value="product!.FoodType"
                        Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")
                        Dense="true" Label="Tipo de alimento" ReadOnly="true"
                        Variant="Variant.Outlined" Margin="Margin.Normal">
                        </MudTextField>
                    </MudItem>
                    <!-- Product Type --> 
                    <MudItem md="20" lg="5">
                        <MudTextField @bind-Value="product!.ProductType"
                        Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")
                        Label="Tipo de producto" Variant="Variant.Outlined"
                        ReadOnly="true" Margin="Margin.Normal" Dense="true">
                        </MudTextField>
                    </MudItem>
                </MudGrid>

            <!-- Product Restrictions --> 
            <div class="container" id="restriction-card-out" align="left">
            <MudItem md="30" lg="10">
                <MudText Typo="Typo.h6">
                    Restricciones
                </MudText>
                <!-- For every category in the list -->
                @foreach (var category in _categories!) {
                    <div class="checkbox">
                        <!-- Get the Name and the Icon -->
                        <MudText Typo="Typo.h6">@category.Name
                            <img src="@category.Icon" 
                            Alt="@category.Name" Width="40" 
                            Height="40" Fluid="true"/>
                            <br>
                            <!-- For every allergen in each category list -->
                            @foreach (var allergen in 
                            _allergens[category.Name]) {
                                <!-- Build the corresponding checkbox, with 
                                its description and name -->
                                <MudCheckBox Disabled=true
                                    Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")
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
            </center>
            <br>
        </MudContainer>
    </DialogContent>
    <DialogActions>
        <MudButton OnClick="Cancel" Variant="Variant.Filled" 
            Color="Color.Success"> Ok </MudButton>
    </DialogActions>
</MudDialog>
}

@code {
    // Parameters
    private bool _isLoading = true;
    [Parameter] public Product? product { get; set; }
    DateTime? Expiration = DateTime.Today;
    [CascadingParameter] MudDialogInstance? MudDialog { get; set; }

    void Cancel() => MudDialog!.Cancel();
    private IEnumerable<AllergenCategory>? _categories;
    // Dictionary to save the allergens according to their category
    private Dictionary<string, List<Allergen>> _allergens =
        new Dictionary<string, List<Allergen>>();
    // Dictionary to store the booleans corresponding to each allergen checkbox
    private Dictionary<string,  bool> boolList =
        new Dictionary<string, bool>();

    // get the allergen categories by calling the method in the application layer
    private async Task getCategories()
    {
        _categories = await AllergenService.GetCategoriesAsync();
    }
    // Fills the allergens dictionary by calling the method 
    // that gets the allergens by category
    private async Task fillAllergenDictionary () {
        foreach (var category in _categories!) {
            IEnumerable<Allergen> _allergenList = await 
                AllergenService.GetAllergenByCategoryAsync(category.Name);
            List<Allergen> _allergenElements = _allergenList.ToList();
            _allergens.Add(category.Name, _allergenElements);   

        }
    }

    // Fills the bool dictionary. It starts with false. 
    // It will become true according to the
    // restrictions that the user marks.
    private void fillBooleanDictionary () {
        foreach (var category in _categories!) {
            foreach (var allergen in _allergens[category.Name]) {
                boolList.Add(allergen.Name, false);
            }
        }
    }
    /*************************** Getting allergens ***************************/

    protected async Task readAllergensFromDatabase() {
        await getCategories();
        await fillAllergenDictionary();
        fillBooleanDictionary();
        foreach (var restriction in product!.Restrictions)  {
            boolList[restriction.FoodRestriction] = true;
        }
    }

    protected override async Task OnInitializedAsync() {
        Expiration = product!.ExpirationDate;
        await getCategories();
        await readAllergensFromDatabase();
        _isLoading = false;
        //foreach (var restriction in product.Restrictions)
        //{
        //    boolList[restriction.FoodRestriction] = true;
        //}
    }

}