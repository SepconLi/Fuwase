@using Domain.Products.Entities
@using Presentation.Products.Models

<link href="/css/components/Card.css" rel="stylesheet" />

<div class="card" style="margin-bottom: 3%;">
    <div class="container" id="image-container">
        <img src=@imageSrc alt="@Product!.Name" 
        style="max-width:100%;max-height: 100%;">
    </div>
    <div class="container" id="card-information">
        <h3 align="left"><b>@Product!.Name </b></h3>
        <p align="justify" style="font-size:large">
            Fecha de expiración: @Product!.Expiration.Date.ToShortDateString()
            <br>
            Cantidad: @Product!.Quantity
            <br>
            Marca del producto: @Product!.Brand
            <br>
            Tipo de alimento: @Product!.FoodType
            <br>
            Tipo de producto: @Product!.ProdType
            <br>
        </p>
        <!-- Display Restrictions/Allergens -->
        @if(Product!.Restrictions != null){
            <div class="labels-container">
                @foreach (var r in Product!.Restrictions!)
                {
                    <span class="allergen-label">@r.FoodRestriction</span>
                }       
            </div> 
        }
        <MudHidden Invert="@showButton">
            <div style="display:flex; flex-direction:row;">
                <MudNumericField @bind-Value="Product.SelectedQuantity"
                Label="Cantidad deseada" Variant="Variant.Outlined" Min="0"
                Max="@Product!.Quantity" Style=@(
                    $"--mud-palette-primary:{Colors.Blue.Accent3};")
                Class="InputStandard" />
                <MudButton Class="ml-10" Variant="Variant.Filled"
                Color="Color.Info" OnClick="selectAllStock">Cantidad total
                </MudButton>
            </div>
        </MudHidden>
    </div>
</div>


@code {
    [Parameter]
    public ProductModel? Product { get; set; }
    string imageSrc = string.Empty;

    protected override void OnInitialized()
    {
        // Convert Image to Base64 String
        if(Product!.Image != null) {
            imageSrc = 
            $"data:{"png"};base64, {Convert.ToBase64String(Product.Image!)}";
        }
    }

    [Parameter]
    public bool showButton { get; set; } = true;

    public void selectAllStock () {
        Product!.SelectedQuantity = Product!.Quantity;
    }

 }
