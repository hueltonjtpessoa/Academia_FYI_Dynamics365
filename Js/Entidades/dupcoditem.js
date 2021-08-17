function Validacoditem(executionContext) {


    var formContext = executionContext.getFormContext();
    var codigo = formContext.getAttribute("tra_codigo").getValue().toString();


    Xrm.WebApi.retrieveMultipleRecords("tra_itemdopedido", "?$select=tra_codigo&$filter=tra_codigo eq '" + codigo + "'").then(//colocar no select e no filter o nome do campo CPF
        function success(result) { //caso ele consiga fazer o retrieveMultipleRecords
            if (result.entities.length > 0) { //quantos dados ele retornou
                Xrm.Navigation.openAlertDialog("Codigo Já Cadastrado");
                formContext.getAttribute("tra_codigo").setValue("");//Limpa o campo caso haja a duplicidade
            }
        },
        function (error) {
            Xrm.Navigation.openAlertDialog(error.message);
        });

}