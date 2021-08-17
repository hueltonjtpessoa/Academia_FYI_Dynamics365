function ValidaCNPJ(executionContext) {


    var formContext = executionContext.getFormContext();
    var CNPJ = formContext.getAttribute("tra_cnpj").getValue().toString();


    Xrm.WebApi.retrieveMultipleRecords("account", "?$select=tra_cnpj&$filter=tra_cnpj eq '" + CNPJ + "'").then(//colocar no select e no filter o  no me do campo CNPJ
        function success(result) { //caso ele consiga fazer o retrieveMultipleRecords
            if (result.entities.length > 0) { //quantos dados ele retornou
                Xrm.Navigation.openAlertDialog("CNPJ Já Cadastrado");
                formContext.getAttribute("tra_cnpj").setValue("");
            }
        },
        function (error) {
            Xrm.Navigation.openAlertDialog(error.message);
        });

}