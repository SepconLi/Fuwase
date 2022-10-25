<!-----------------------------------------------------------------------------
    This document is for the US:
    - IM-6.3 Campaign product order
    Imborrables
    Andres
-------------------------------------------------------------------------------
    Displays product information and quantity selector
------------------------------------------------------------------------------>

@* Project includes *@
@using Presentation.Products.Models
@using Presentation.Campaigns.Models
@* System includes *@
@using System.Linq;


<link href="/css/components/Card.css" rel="stylesheet"/>

@if (_IsLoading)
{
    <MudSkeleton Width="400px" Height="90px"/>
}
else
{
    <div class="card" style="margin-bottom: 3%;">
        <div class="container" id="card-information">
            <h3 align="left"><b>@productModel!.Name </b></h3>
            <p align="justify" style="font-size:large">
                Cantidad: @productModel!.Quantity
                <br>
                Tipo de alimento: @productModel!.FoodType
                <br>
                Tipo de producto: @productModel!.ProductType
                <br>
            </p>
            <!-- Display Restrictions/Allergens -->
            @*
            @if(Product!.Restrictions != null){
                <div class="labels-container">
                    @foreach (var r in Product!.Restrictions!)
                    {
                        <span class="allergen-label">@r.FoodRestriction</span>
                    }       
                </div> 
            }
            *@
            <MudHidden Invert="@showButton">
                <div style="display:flex; flex-direction:row;">
                    <MudNumericField @bind-Value="productModel.SelectedQuantity"
                    Label="Cantidad deseada" Variant="Variant.Outlined" Min="1"
                    Max="@productModel!.Quantity" Style=@(
                        $"--mud-palette-primary:{Colors.Blue.Accent3};")
                    Class="InputStandard" />
                    <MudButton Class="ml-10" Variant="Variant.Filled"
                    Color="Color.Info" OnClick="selectAllStock">Cantidad total
                    </MudButton>
                </div>
            </MudHidden>
        </div>
    </div>
}


@code {
    // Declaring parameters

    [Parameter]
    public bool showButton { get; set; } = true;

    [Parameter]
    public CampaignProductModel? productModel { get; set; }
    string imageSrc = string.Empty;


    // Declaring local variables
    private bool _IsLoading = true;

    protected override void OnInitialized()
    {
        // Convert Image to Base64 String
        if(productModel!.Image != null) {
            imageSrc = 
            $"data:{"png"};base64, {Convert.ToBase64String(productModel.Image!)}";
        }
        _IsLoading = false;
    }

    // Calculating the percentage from the given values
    private int calculatePercentage(int currentValue, int totalValue)
    {
        return (int)(currentValue * 100 / totalValue);
    }

    public void selectAllStock () {
        productModel!.SelectedQuantity = productModel!.Quantity;
    }
}