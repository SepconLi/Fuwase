<!-----------------------------------------------------------------------------
    This document is for the US:  
    -     LI-BE-6.1 List of active campaigns.
    And was done by IB.
-------------------------------------------------------------------------------
    Displays campaign information and progress
------------------------------------------------------------------------------>

@* Project includes *@
@using Application.Campaigns
@using Presentation.Products.Models
@* System includes *@
@using System.Linq;

@* Injecting project services *@
@inject ICampaignService CampaignService

<link href="/css/components/Card.css" rel="stylesheet"/>

@if (_IsLoading)
{
    <MudSkeleton Width="400px" Height="90px"/>
}
else
{
    <div class="card">
        <div class="container" id="card-information">
            <h3 align="left"><b>@Name </b></h3>
            <body1 align="justify"> </body1>

            <MudText Align="Align.Justify">Ubicación: @Province, @County, @District</MudText>

            <MudText Align="Align.Justify">@Description</MudText>

            <div style="margin-top:3%">
            <MudProgressLinear Color="Color.Info" Size="Size.Large" 
                Value="@ProductPercentage"/>
            <p align="left"><b>@Raised de @Goal productos</b></p>
            </div>

        </div>

            <div style="width:25%; text-align:right">
                <MudButton Variant="Variant.Filled" Color="Color.Info" Href="@getLink(id)"
                    Style="margin-top:50%; margin-right: 15px;padding:20px 20px; margin-bottom: 5%; font-size:17px">Ver detalles</MudButton>
            </div>
    </div>

}


@code {
    // Declaring parameters
    [Parameter]
    public int id { get; set; }
    [Parameter]
    public string? Name { get; set; }
    [Parameter]
    public int Raised { get; set; }
    [Parameter]
    public int Goal { get; set; }
    [Parameter]
    public string? Description { get; set; }
    [Parameter]
    public string? Province  { get; set; }
    [Parameter]
    public string? County  { get; set; }
    [Parameter]
    public string? District  { get; set; }

    // Declaring local variables

    private bool _IsLoading = true;

    private int ProductPercentage{ get; set; }

    string imageSrc = string.Empty;

    protected override void OnInitialized()
    {
        ProductPercentage = calculatePercentage(Raised, Goal);
        _IsLoading = false;
    }


    // Calculating the percentage from the given values
    private int calculatePercentage(int currentValue, int totalValue)
    {
        return (int)(currentValue * 100 / totalValue);
    }

    private string getLink(int id)
    {
        return "/campaignDetails/"+ id;
    }
}