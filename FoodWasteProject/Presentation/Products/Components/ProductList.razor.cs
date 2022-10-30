using Domain.Donations.DTOs;
using Application.Donations;
using System.Globalization;
using System;
using Presentation.Products.Models;

using Domain.Products.Entities;
using Domain.Users.Entities;
using Application.Products;
using Application.Authentication;

namespace Presentation.Products.Components{


    public partial class Product{
    IDonationService? DonationService;
    IAuthenticationService? AuthenticationService;
    IAllergenService? AllergenService;
    public string? UserEmail { get; set; }
    // All the necessary variables for the ProductList Page to work
    private bool _isLoading = true;
    private string value { get; set; } = "Nothing selected";
    private IEnumerable<string> options { get; set; } = new HashSet<string>() {  };
    private IEnumerable<DonationDTO>? _donations;
    private List<IReadOnlyCollection<Product>>? _products;
    private DateTime today = DateTime.Today;
    // Variables for the allergens dropdown
    private IEnumerable<AllergenCategory>? _categories;
    private Dictionary<string,  List<Allergen>> _allergens = new Dictionary<string,  List<Allergen>>();
    private Dictionary<string,  bool> boolList = new Dictionary<string, bool>();
    // All the products filters go in this variable
    // The filters must be checked before showing the products
    FiltersModel productFilter = new FiltersModel();

    // Shows the products List
    protected override async Task OnInitializedAsync()
    {
        // Load preferences
        await initializePreferences();
        // Get Products
        await loadProducts();
        _isLoading = false;
    }

    private async Task initializePreferences() {
        // Get the user for reading the preferences
        await AuthenticationService.GetValueAsync();
        UserEmail = await AuthenticationService.GetLoggedUserEmail();
        // Initialize allergens dropdown
        await getCategories();
        await fillAllergenDictionary();
        fillBooleanDictionary();
        foreach (var restriction in productFilter.Restrictions)
        {
            boolList[restriction] = true;
        }
        await loadUserPreferences();
    }

    private async Task loadProducts() {
        _products = new List<IReadOnlyCollection<Product>>();
        _donations = await DonationService.GetAllDonationsWithProductsAsync();
        foreach(DonationDTO donation in _donations)
        {
            _products.Add(donation.Products);
        }
    }

    private async Task fillAllergenDictionary ()
    {
        foreach (var category in _categories!) {
            IEnumerable<Allergen> _allergenList =
                 await AllergenService.GetAllergenByCategoryAsync(category.Name);
            List<Allergen> _allergenElements = _allergenList.ToList();
            _allergens.Add(category.Name, _allergenElements);   

        }
    }

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

    private async Task getCategories() {
        _categories = await AllergenService.GetCategoriesAsync();
    }

    /* Loads the user preferences before the page displays anything */
    private async Task loadUserPreferences()
    {
        // First receives the user preferences
        await loadUserAllergensPreferences();
        // Add here other types of preferences/filters
    }

    private async Task loadUserAllergensPreferences()
    {
        if (UserEmail != null)
        {
            IEnumerable<UserFoodPreferences?> preferences = await UserFoodPreferencesService.GetAllRestrictionsAsync(UserEmail);
            if (preferences.Count() != 0)
            {
                foreach (var allergen in preferences)
                {
                    productFilter.Restrictions.Add(allergen!.FoodRestriction);
                }
            }
            foreach (var restriction in productFilter.Restrictions)
            {
                boolList[restriction] = true;
            }
        }
    }

    /** This function test every posible filter in the product
     * returns false if the product fails passing any filter
     */
    private bool applyFilters(Product product)
    {
        // product != null && (today < product.ExpirationDate) == true
        // Is a valid model (Not null)
        if (product == null)
            return false;
        // Is not expired
        if (today > product.ExpirationDate)
            return false;
        // Doesn't contain the filtered allergens
        if (applyAllergensFilter(product) != true)
            return false;
        // Todo: Is from the right location? or add others filters here

        // Happy ending: The product passed the filters
        return true;
    }

    private bool applyAllergensFilter(Product product)
    {
        // If the productFilter is null, then no allergen has been applied
        if (productFilter == null)
            return true;
        foreach (var allergen in product.Restrictions)
        {
            foreach (var filtered in productFilter.Restrictions)
            {
                // if the product contains an allergen that is filtered
                // the product is discarted
                if (allergen.FoodRestriction == filtered)
                    return false;
            }
        }
        // Happy ending: No allergens in this product that are in the filter
        return true;
    }

    // Cleans all checkboxes and stored filters
    private void cleanRestrictions()
    {
        productFilter = new FiltersModel();
        foreach (var category in _categories!)
        {
            foreach (var allergen in _allergens[category.Name])
            {
                boolList[allergen.Name] = false;
            }
        }
        Snackbar.Add("Filtros removidos", Severity.Normal);
    }

    // Stores the restrictions that were marked in the database
    private void saveSelectedRestrictions()
    {
        productFilter = new FiltersModel();
        foreach (var restriction in boolList.Keys)
        {
            Restriction _restriction = new Restriction(restriction);
            if (boolList[restriction] == true)
            {
                productFilter.Restrictions.Add(restriction);
            }
        }
        Snackbar.Add("Filtros aplicados", Severity.Success);
    }
    }
}