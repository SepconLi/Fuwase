@*-----------------------------------------------------------------------------
    This document is for the US:
    - ALV-DO-1.1 Add location and description to donation
    And was done by a joint effort by all members of ALV.
-------------------------------------------------------------------------------
    A location component that contains a dropdown for a province, a county,
    and a district. This component uses mudblazor's "MudSelect" for the
    dropdown element and an EventCallback to return a DonationModel.
-----------------------------------------------------------------------------*@

@* Project includes *@
@using Application.Locations
@using Application
@using Domain.Locations.Entities
@using Presentation.Core.Models

@inject ILocationService LocationService

@if (_IsLoading) {
    <br />
    <MudSkeleton SkeletonType="SkeletonType.Rectangle"
        Animation="Animation.Wave" Width="700px" Height="60px" />
} else {
    <MudStack Row="true">
        <!-- Dropdown Province -->
        <MudSelect @bind-Value="Location.Province" T="string"
            Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}; width:150px;")
            SelectedValuesChanged="changeProvince" 
            id="Province"
            Variant="Variant.Outlined" Disabled="false"
            Label="Provincia" Required="true" 
            AnchorOrigin="Origin.BottomCenter">
                @foreach (var state in _provinces!) {
                    <MudSelectItem T="string" Value="@state.Name" Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")>
                        @state.Name
                    </MudSelectItem>
                }
        </MudSelect>
        <br/>
        <!-- Activating county dropdown -->
        @if(Location.Province != "" && selectedProvince == false){
            getDistricts(Location.Province!);
            activateCounty = false;
            activateDistrict = true;
            Location.County = "";
            Location.District = "";
            selectedProvince = true;
        }

        <!-- Dropdown County -->
        <MudSelect @bind-Value="Location.County" T="string"
            Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}; width:150px;")
            SelectedValuesChanged="changeDistrict" 
            Variant="Variant.Outlined"
            id="County" 
            Disabled=activateCounty 
            Label="Canton" 
            Required="true"
            AnchorOrigin="Origin.BottomCenter">
                @foreach (var state in _districts!) {
                    <MudSelectItem T="string" Value="@state.Name" Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")>
                        @state.Name
                    </MudSelectItem>
                }
        </MudSelect>
        <!-- Activating district dropdown -->
        @if(Location.County != "" && selectedDistrict == false) {
            getTowns(Location.Province!,Location.County!);
            activateDistrict = false;
            Location.District = "";
            selectedDistrict = true;
        }
        <br/>

        <!-- Dropdown District -->
        <MudSelect @bind-Value="Location.District" T="string" 
            Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}; width:150px;")
            TextChanged="OnDistrictSelect"  
            Variant="Variant.Outlined" 
            id="District" 
            Disabled=activateDistrict 
            Label="Distrito" 
            Required="true" 
            AnchorOrigin="Origin.BottomCenter">

                @foreach (var state in _towns!) {
                    <MudSelectItem T="string" Value="@state.Name" Style=@($"--mud-palette-primary:{Colors.Blue.Accent3}")>
                        @state.Name
                    </MudSelectItem>
                }
        </MudSelect>
        <br/>
    </MudStack>
}
@code {
    [Parameter]
    public EventCallback<LocationModel> LocationChange { get; set; }

    LocationModel Location = new LocationModel("", "", "");

    /* Declare boolean values */
    private bool activateCounty { get; set;} = true;
    private bool activateDistrict { get; set; } = true;
    private bool activateButton { get; set; } = false;
    private bool selectedProvince = true;
    private bool selectedDistrict = true;
    private bool _IsLoading = true;

    /* Creating the list were the database data it's going to be stored */
    private IEnumerable<Province>? _provinces;
    private IEnumerable<District>? _districts;
    private IEnumerable<Town>? _towns;

    /* Initialize values */
    protected override async Task OnInitializedAsync() {
        await getProvinces();
        _districts = new List<District>();
        _towns = new List<Town>();
        _IsLoading = false;
    }

    /* When district is selected, send data is called */
    private async Task OnDistrictSelect(string selected) {
        Location.District = selected;
        if (!string.IsNullOrEmpty(Location.Province) && 
            !string.IsNullOrEmpty(Location.County) && 
            !string.IsNullOrEmpty(Location.Province) ) {
            await sendData();
        }
    }
    /* Clears the Location box fields */
    public void Clear()
    {
        Location.Province = "";
        Location.County = "";
        Location.District = "";
        activateCounty=true;
        activateDistrict = true;
    }
    /* Handles the province change */
    private Task changeProvince() {
        selectedProvince = false;
        return Task.CompletedTask;
    }
    /* Handles the District change */
    private Task changeDistrict() {
        selectedDistrict = false;
        return Task.CompletedTask;
    }   
    /* Loads provinces from the database */
    private async Task getProvinces() {
        _provinces = await LocationService.GetProvincesAsync();
    }
    /* Loads districts from the database given a province */
    private async Task getDistricts(string Province) {
        _districts = await LocationService.GetDistrictsAsync(Province);
    }
    /* Loads towns from the database given a province and district */
    private async Task getTowns(string Province, string District) {
        _towns = await LocationService.GetTownsAsync(Province, District);
    }

    /* Returns location model */
    private async Task sendData() {
        await LocationChange.InvokeAsync(Location);
    }
}