<!-----------------------------------------------------------------------------
    This document is for the US:
    - ALV-DO-1.9 Show products added to a donation
    And was done by a joint effort by all members of ALV.
-------------------------------------------------------------------------------
    Shows the product name and gives 3 options to the user
    1-View information
    2-Modify product
    3-Delete product
-----------------------------------------------------------------------------!>

@* Project includes *@
@using Application.Locations
@using Application
@using Domain.Products.Entities
@using Domain.Donations.Entities
@using Domain.Campaigns.Entities
@using Presentation.Donations.Components
@using Presentation.Products.Models

@inject IDialogService DialogService
@inject IJSRuntime JsRuntime

@if (products != null)
{
        <MudTable Items="@products" Bordered=true Striped=true>
            <HeaderContent>
                <!-- Here goes the upper side descriptions -->
                <MudTh>Producto</MudTh>
                <MudTh>Informacion</MudTh>
                <MudTh>Modificar</MudTh>
                <MudTh>Eliminar</MudTh>
            </HeaderContent>
            <ColGroup>
                <col style="width:70%;" />
                <col />
                <col />
                <col />
            </ColGroup>
            <RowTemplate>
                <!-- Init every product line -->
                <MudTd DataLabel="Producto">@context.Name</MudTd>
                <MudTd DataLabel="Informacion">
                    <center>
                        <!-- Information Button -->
                        <MudIconButton Variant="Variant.Filled"
                               Icon="@Icons.Material.Outlined.Info"
                               Color="Color.Warning"
                               OnClick="_=>ShowInformation(context)" />
                    </center>
                </MudTd>
                <MudTd DataLabel="Modificar">
                    <center>
                        <!-- Modify Button -->
                        <MudIconButton Variant="Variant.Filled"
                               Icon="@Icons.Filled.Create"
                               Color="Color.Default"
                               OnClick="_=>modifyForm(context)" />
                    </center>
                </MudTd>
                <MudTd DataLabel="Eliminar">
                    <center>
                        <!-- Delete Button -->
                        <MudIconButton Variant="Variant.Filled"
                               Icon="@Icons.Material.Filled.Delete"
                               Color="Color.Error"
                               OnClick="_=>HandleProductDelete(context)" />
                    </center>
                </MudTd>
            </RowTemplate>
        </MudTable>
}
else
{       <!-- In case there are no products -->
         <h2 align="center">No hay productos actualmente</h2>
}
<br />



@code {
    /* Parameters to get the product context */
    [Parameter]
    public Donation donation { get; set; } = null;
    [Parameter]
    public List<Product> products { get; set; } = null;

    /* Shows the product's information */
    private void ShowInformation(Product product)
    {
        var parameters = new DialogParameters();
        parameters.Add("product", product);
        var dialog = DialogService.Show<PopupInformation>
            ("datos del producto", parameters);
    }

    /* Handles the donation's product delete */
    private void HandleProductDelete(Product product)
    {
        products.Clear();
        donation.RemoveProductFromDonation(product);
        products = new List<Product>(donation.Products);
    }

    /* Show product's last added information, and allow edit */
    async Task modifyForm(Product product)
    {
        if (product != null)
        {
            ProductModel newModel = new ProductModel(product.Name,
                product.FoodType, product.ProductType, product.Quantity,
                product.Weight, product.Brand, product.ExpirationDate,
                product.Restrictions.ToList());
            var parameters = new DialogParameters();
            parameters.Add("model", newModel);
            var dialog = DialogService.Show<PopupProduct>(
                "Ingrese los datos del producto", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                ProductModel model = (ProductModel)result.Data;
                HandleProductModify(model, product);
            }
        }
    }

    /* Handles the product modification on the database*/
    private void HandleProductModify(ProductModel model, Product oldProduct)
    {
        Product product = new Product(model.Name, model.FoodType,
            model.ProdType, model.Quantity, model.Weight, model.Brand);
        product.ExpirationDate = (DateTime)model.Expiration;

        foreach (var restriction in model.Restrictions)
        {
            product.AddRestrictionToProduct(restriction);
        }

        donation.ModifyProduct(product, oldProduct);
        products = new List<Product>(donation.Products);
    }
}
