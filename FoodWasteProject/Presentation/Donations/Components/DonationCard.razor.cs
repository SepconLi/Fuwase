@using Domain.Products.Entities

@using Domain.Donations.DTOs
@using Domain.Donations.Entities
@using Application.Donations
@using Application.Products
@using Presentation.Donations.Components
@using Presentation.Donations.Pages
@using Application.Authentication

<link href="/css/components/Card.css" rel="stylesheet" />

<div class="card" style="margin-top: 10px; width:70%; align-items:center; text-align:start;">
    <div style="border-style:solid; padding-left: 25px; width:90%; display:block; margin-bottom: 20px">
        <br />
        <div style="align-items:center; margin-bottom: 7px;">
            <div Class="d-inline-flex" style="width: fit-content;">
                <h4>@Description</h4>
            </div>
            <div Class="d-inline-flex" style="width: fit-content;">
                <DonationStatusTag
                    _status="@Status"
                ></DonationStatusTag>  
            </div>
        </div> 
        <MudText>Fecha de creación: @CreationDate.ToString("dd/MM/yyyy")</MudText>
        <MudText>Cantidad de productos: @ProductsCount</MudText>
    </div>
    <div style="display: inline-block; width: 100%; text-align:right; margin: 6% 10px 6% 0;">
        @if (Status == "A")
        {
            <div style="display: inline-block; width:fit-content; margin-right:10px;">
                <DeleteDonationButton
                    _donationId="@Id"
                    _description="@Description"
                ></DeleteDonationButton>
            </div>
        }
        <!-- Information Button -->
        <div style="display: inline-block; width:fit-content; margin-right:10px;">
            <MudIconButton Variant="Variant.Filled"
                Icon="@Icons.Material.Outlined.Info"
                Color="Color.Warning"
                Size="Size.Medium"
                Href="@getLink(Id)"
            ></MudIconButton>
        </div>
    </div>  
</div>

@code {
    // Declaring parameters
    [Parameter]
    public int Id { get; set; }
    [Parameter]
    public string Description { get; set; } = "Donacion";
    [Parameter]
    public DateTime CreationDate { get; set; }
    [Parameter]
    public int ProductsCount { get; set; }
    [Parameter]
    public bool Activate { get; set; } = true;
    [Parameter]
    public string Status { get; set; } = "";

    // Declaring local variables
    private Product? Product { get; set; }

    private string getLink(int id)
    {
        return "/history/donation/" + id;
    }
}
