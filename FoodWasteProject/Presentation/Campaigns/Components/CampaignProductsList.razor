<!-----------------------------------------------------------------------------
    This document is for the US:
    - ALV-DO-4.1 Create a donation campaign
    And was done by a joint effort of members of ALV.
-------------------------------------------------------------------------------
    Shows the product name and gives 3 options to the user
    1-View information
    2-Modify product
    3-Delete product
-----------------------------------------------------------------------------!>

@* Project includes *@
@using Domain.Campaigns.Entities
@using Presentation.Campaigns.Components
@using Presentation.Products.Models

@inject IDialogService DialogService

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
{   <!-- In case there are no products -->
    <h2 align="center">No hay productos actualmente</h2>
}

<br />

@code {
    /* Parameters to get the product context */
    [Parameter]
    public Campaign campaign { get; set; } = null;
    [Parameter]
    public List<CampaignProduct> products { get; set; } = null;

    /* Shows the product's information */
    private void ShowInformation(CampaignProduct product)
    {
        var parameters = new DialogParameters();
        parameters.Add("product", product);
        var dialog = DialogService.Show<PopupCampaignInformation>
            ("Datos del Producto", parameters);
    }

    /* Handles the donation's product delete */
    private async Task HandleProductDelete(CampaignProduct product)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        var dialog = DialogService.Show<DeleteConfirmationDialog>(
            "Desea borrar este producto? ", options);
        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            products.Clear();
            campaign.RemoveProductFromCampaign(product);
            products = new List<CampaignProduct>(campaign.Products);
        }
    }

    /* Show product's last added information, and allow edit */
    async Task modifyForm(CampaignProduct product)
    {
        if (product != null)
        {
            ProductModel newModel = new ProductModel(product.Name,
                product.FoodType, product.ProductType, (int)product.Quantity,
                (int)product.Goal, (double)product.Weight);
            var parameters = new DialogParameters();
            parameters.Add("model", newModel);
            var dialog = DialogService.Show<PopupCampaignProduct>(
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
    private void HandleProductModify(ProductModel model, CampaignProduct oldProduct)
    {
        CampaignProduct product = new CampaignProduct(model.Name, model.FoodType,
            model.ProdType, model.Goal, model.Weight, model.Quantity);

        campaign.ModifyProduct(product, oldProduct);
        products = new List<CampaignProduct>(campaign.Products);
    }
}
