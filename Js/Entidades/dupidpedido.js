function ValidaID_Pedido(executionContext) {


    var formContext = executionContext.getFormContext();
    var ID = formContext.getAttribute("tra_idpedido").getValue().toString();


    Xrm.WebApi.retrieveMultipleRecords("tra_pedido", "?$select=tra_idpedido&$filter=tra_idpedido eq '" + ID + "'").then(//colocar no select e no filter o nome do campo CPF
        function success(result) { //caso ele consiga fazer o retrieveMultipleRecords
            if (result.entities.length > 0) { //quantos dados ele retornou
                Xrm.Navigation.openAlertDialog("ID Já Cadastrado");
                formContext.getAttribute("tra_idpedido").setValue("");//Limpa o campo caso haja a duplicidade
            }
        },
        function (error) {
            Xrm.Navigation.openAlertDialog(error.message);
        });

}