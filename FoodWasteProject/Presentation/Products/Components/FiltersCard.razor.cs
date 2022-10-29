@using Domain.Products.Entities
@using Presentation.Products.Models

@inject ISnackbar Snackbar
@inject IDialogService DialogService


<link href="/css/components/Card.css" rel="stylesheet" />

<div class="card">
        <center>
            <div class="card">
               <div class="container" id="registration-card">
                   <MudButton Variant="Variant.Filled" Color="Color.Info" OnClick="@((e) => openForm(maxWidth))">
                        Filtrar Alergenos
                   </MudButton>

                    @if( productFilter!=null &&productFilter.Restrictions.Count != 0 ){
                        <MudCardContent>
                        <div class="labels-container">
                        <MudText Typo="Typo.h6">Alergenos Filtrados:  </MudText>
                        @foreach (var allergen in productFilter.Restrictions!)
                        {
                            <span class="allergen-label">@allergen</span>
                         }       
                        </div> 
                        </MudCardContent>
                    }
               </div>
            </div>
         </center>
</div>
        


@code {
    [Parameter]
    public FiltersModel? productFilter { get; set; }

    [Parameter]
    public DialogOptions maxWidth { get; set; }

    /* Opens Allergens Form options */
    async Task openForm(DialogOptions options) {
        var dialog = DialogService.Show<PopupAllergensFilter> ("Seleccione los alérgenos que desea filtrar", options);
        var result = await dialog.Result;
        if (!result.Cancelled) {
            productFilter = (FiltersModel) result.Data;
            Snackbar.Add("Sus filtros fueron aplicados", Severity.Success);
        }
    }

 }
