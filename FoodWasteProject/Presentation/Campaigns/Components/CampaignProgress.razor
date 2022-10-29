<!-----------------------------------------------------------------------------
    This document is for the US:
    - ALV-DO-4.3 See progress of a campaign
    And was done by a joint effort of members of ALV and IB.
-------------------------------------------------------------------------------
    Displays a campain's progress given the amount of donations
    made to each product.
------------------------------------------------------------------------------>

@* Project includes *@
@using Domain.Campaigns.Entities
@using Application.Donations
@* System includes *@
@using System.Linq;

@* Injecting project services *@
@inject IDonationService DonationService

@if (_IsLoading)
{
    <MudSkeleton Animation="Animation.Wave"/>
}
else
{
    <MudText>@CampaignCurrent productos de @CampaignTotal</MudText>
    <MudProgressLinear Color="Color.Info" Size="Size.Large" 
        Value="@CampaignPercentage"/>
    <MudText>@DonationsMade donaciones hechas</MudText>
    <br/>
}

@code {
    // Declaring parameters
    [Parameter]
    public Campaign? campaign { get; set; }

    // Declaring local variables
    private bool _IsLoading = true;
    private int CampaignCurrent = 0;
    private int CampaignTotal = 0;
    private int DonationsMade = 0;
    private int CampaignPercentage = 0;

    // Wait until percentage is calculated to display
    protected override async Task OnInitializedAsync()
    {
        CampaignCurrent = campaign!.Raised;
        CampaignTotal = campaign.Goal;

        //DonationsMade = await
        //    DonationService.GetAmountDonationsAsync(CampaignId);

        CampaignPercentage =
            calculatePercentage(CampaignCurrent, CampaignTotal);

        _IsLoading = false;
    }

    // Calculating the percentage from the given values
    private int calculatePercentage(int currentValue, int totalValue)
    {
        if (currentValue != 0 && totalValue != 0)
        {
            return (int)(currentValue * 100 / totalValue);
        }
        else
        {
            return 0;
        }
    }
}