<!--
    This document is for the US: ALV-DO-1.1 Add location to donation
    and was done bt a joint effort by all members of ALV.
-->
<MudDialog>
    <DialogContent>
        Su producto ha sido registrado exitosamente
    </DialogContent>
    <DialogActions>
        <MudButton Color="Color.Info" OnClick="Submit">Ok</MudButton>
    </DialogActions>
</MudDialog>


@code {
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }

    void Submit() => MudDialog.Close(DialogResult.Ok(true));
}