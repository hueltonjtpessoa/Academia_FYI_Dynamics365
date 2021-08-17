function ValidaCPF_CP(executionContext) {


    var formContext = executionContext.getFormContext();
    var CPF = formContext.getAttribute("tra_cpf").getValue().toString();


    Xrm.WebApi.retrieveMultipleRecords("tra_cliente_potencial", "?$select=tra_cpf&$filter=tra_cpf eq '" + CPF + "'").then(//colocar no select e no filter o nome do campo CPF
        function success(result) { //caso ele consiga fazer o retrieveMultipleRecords
            if (result.entities.length > 0) { //quantos dados ele retornou
                Xrm.Navigation.openAlertDialog("CPF Já Cadastrado");
                formContext.getAttribute("tra_cpf").setValue("");//Limpa o campo caso haja a duplicidade
            }
        },
        function (error) {
            Xrm.Navigation.openAlertDialog(error.message);
        });

}