<!-----------------------------------------------------------------------------
    This document is for the US:
    - ALV-DO-4.3 See progress of a campaign
    And was done by a joint effort of members of ALV and IB.
-------------------------------------------------------------------------------
    Displays product information and progress
------------------------------------------------------------------------------>

@* Project includes *@
@using Application.Campaigns
@using Domain.Campaigns.DTOs;
@using Domain.Campaigns.Entities
@* System includes *@
@using System.Linq;

<link href="/css/components/Card.css" rel="stylesheet"/>

@if (_IsLoading)
{
    <MudSkeleton Width="400px" Height="90px"/>
}
else
{
    <div class="card">
        <div class="container" id="card-information">
            <h3 align="left"><b>@CampaignProduct!.Name </b></h3>
            <MudProgressLinear Color="Color.Info" Size="Size.Large" 
                Value="@ProductPercentage"/>
            <p align="left"><b>@ProductCurrent productos de @ProductTotal</b></p>
        </div>
    </div>
}


@code {
    // Declaring parameters
    [Parameter]
    public CampaignProductDTO? CampaignProduct { get; set; }

    [Parameter]
    public bool showButton { get; set; } = true;

    // Declaring local variables
    private bool _IsLoading = true;
    private int? ProductCurrent = 0;
    private int? ProductTotal = 0;
    private int ProductPercentage = 0;

    // Wait until percentage is calculated to display
    protected override async Task OnInitializedAsync()
    {
        ProductCurrent = CampaignProduct!.Raised;
        ProductTotal = CampaignProduct.Goal;

        ProductPercentage =
            calculatePercentage(ProductCurrent, ProductTotal);

        _IsLoading = false;
    }

    // Calculating the percentage from the given values
    private int calculatePercentage(int? currentValue, int? totalValue)
    {
        return (int)(currentValue * 100 / totalValue)!;
    }
}