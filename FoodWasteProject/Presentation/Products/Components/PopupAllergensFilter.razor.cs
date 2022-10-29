@* Project includes *@
@using Presentation.Core.Components
@using Presentation.Products.Components
@using Presentation.Products.Models
@using Application.Products
@using Domain.Products.Entities
@using Domain.Donations.Entities

@* Injecting project services *@
@inject IDialogService DialogService
@inject IAllergenService AllergenService

@if (_IsLoading) {
    <h3>Loading...</h3>
}
else {
<MudDialog>
    <DialogContent >
        <MudContainer Style=" max-height: 500px; overflow-y: scroll">
            <center>
                <!-- Product Restrictions -->
                <div class="container" id="restriction-card-out"  align="left">
                     <MudItem md="30" lg="10">
                        <MudText Typo="Typo.h6">Marcar restricciones alimentarias</MudText>
                        <!--For every category in the list-->
                        @foreach (var category in _categories) {
                            <div class="checkbox">
                                <!--get the Name and the Icon-->
                                <MudText Typo="Typo.h6">@category.Name
                                    <img src="@category.Icon" Alt="@category.Name" Width="40" Height="40" Fluid="true" />
                                    <br>
                                    <!--For every allergen in each category list-->
                                    @foreach (var allergen in _allergens[category.Name]) {
                                        <!--Build the corresponding checkbox, with its description and name-->
                                        <MudCheckBox @bind-Checked="@boolList[allergen.Name]" Size="Size.Medium" Color="Color.Info" ></MudCheckBox>
                                        <!--This is to show the description of the allergen when the cursor is over it-->
                                        <MudTooltip Text="@allergen.Description" Arrow="true" Placement="Placement.Top">
                                                <MudText>@allergen.Name</MudText>
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
    <DialogActions>
        <MudButton OnClick="Cancel">Cancelar</MudButton>
        <MudButton Variant="Variant.Filled" Color="Color.Success" OnClick="ReturnFilters">Aplicar Filtros</MudButton>
    </DialogActions>
</MudDialog>
}

@code {
    private bool _IsLoading = true;
    // Here the filters to compare are going to be stored
    [Parameter] public FiltersModel productFilter { get; set; } = new FiltersModel();
    // Note: Making a boolean list for the active filters might be a good idea for aplying multiple filters at once

    //List of the allergen categories
    private IEnumerable<AllergenCategory>? _categories;
    //Dictionary to save the allergens according to their category
    private Dictionary<string,  List<Allergen>> _allergens = new Dictionary<string,  List<Allergen>>();
    //Dictionary to store the booleans corresponding to each allergen checkbox
    private Dictionary<string,  bool> boolList = new Dictionary<string, bool>();

    // initialize all the lists and dictionaries
    protected override async Task OnInitializedAsync() {
        await getCategories();
        await fillAllergenDictionary();
        fillBooleanDictionary();
        foreach (var restriction in productFilter.Restrictions)
        {
            boolList[restriction] = true;
        }
    }

    // Fills the allergens dictionary by calling the method 
    // that gets the allergens by category
    private async Task fillAllergenDictionary ()
    {
        foreach (var category in _categories) {
            IEnumerable<Allergen> _allergenList =
                 await AllergenService.GetAllergenByCategoryAsync(category.Name);
            List<Allergen> _allergenElements = _allergenList.ToList();
            _allergens.Add(category.Name, _allergenElements);   

        }
        _IsLoading = false;
    }

    // Fills the bool dictionary. It starts with false. 
    // It will become true according to the
    // restrictions that the user marks.
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

    // get the allergen categories by calling the method in the application layer
    private async Task getCategories() {
        _categories = await AllergenService.GetCategoriesAsync();
    }

    // Declaration for the Cancel button
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }
    void Cancel() => MudDialog.Cancel();
    // Registers the allergens (or all the filters selected)
    private async Task ReturnFilters() {
        saveSelectedRestrictions();
        MudDialog.Close(productFilter);
    }

    //Stores the restrictions that were marked in the database
    private void saveSelectedRestrictions()
    {
        foreach (var restriction in boolList.Keys)
        {
            Restriction _restriction = new Restriction(restriction);

            if (boolList[restriction] == true)
            {
                productFilter.Restrictions.Add(restriction);
            }
        }
    }
}
