using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;

namespace TCCV4
{
    class CRMxCRM
    {
        static void Main(string[] args)
        {
            var serviceproxy = new NewCRM().Obter();

            CrmServiceClient TRACRM = new TRACRM().Importar();

            ClientePotencial(serviceproxy);

            Conta(serviceproxy);

            Contato(serviceproxy);

            Pedido(serviceproxy);

            itemPedido(serviceproxy);

            Console.WriteLine("ACABOU POOOOOORRRRAAAA");
            Console.ReadKey();
        }

        //Retrieve multiple importa os dados para o CRM destino através
        #region Coleção Cliente Potencial

        static EntityCollection ClientePotencial(CrmServiceClient serviceProxy)
        {
            QueryExpression queryExpression = new QueryExpression("new_cliente_potencial");
            queryExpression.ColumnSet = new ColumnSet("new_name", "new_sobrenome_cp", "new_cpf", "new_telefone_cp", "new_email_cp", "new_endereco_cp", "new_cep");

            EntityCollection colecaoClientePotencial = serviceProxy.RetrieveMultiple(queryExpression);
            var Conectar = new TRACRM().Importar();

            foreach (var item in colecaoClientePotencial.Entities)
            {
                try
                {
                    var inserir = new Entity("tra_cliente_potencial");
                    Guid CRMcp = new Guid();

                    if (item.Attributes.Contains("new_name"))
                        inserir.Attributes.Add("tra_nomeclientep", item["new_name"]);

                    if (item.Attributes.Contains("new_sobrenome_cp"))
                        inserir.Attributes.Add("tra_sobrenome_cp", item["new_sobrenome_cp"]);

                    if (item.Attributes.Contains("new_email_cp"))
                        inserir.Attributes.Add("tra_email_cp", item["new_email_cp"]);

                    if (item.Attributes.Contains("new_telefone_cp"))
                        inserir.Attributes.Add("tra_telefone_cp", item["new_telefone_cp"]);

                    if (item.Attributes.Contains("new_endereco_cp"))
                        inserir.Attributes.Add("tra_endereco_cp", item["new_endereco_cp"]);

                    if (item.Attributes.Contains("new_cpf"))
                        inserir.Attributes.Add("tra_cpf", item["new_cpf"]);

                    if (item.Attributes.Contains("new_cep"))
                        inserir.Attributes.Add("tra_cep", item["new_cep"]);

                    CRMcp = Conectar.Create(inserir);
                }
                catch (Exception)
                {

                }
            }
            return colecaoClientePotencial;
        }

        #endregion

        #region Coleção Conta
        static EntityCollection Conta(CrmServiceClient serviceProxy)
        {
            QueryExpression queryExpression = new QueryExpression("account");
            queryExpression.ColumnSet = new ColumnSet("name", "new_cnpj", "new_website_conta", "new_email_conta", "new_telefone_conta", "new_endereco_conta", "new_cep");

            EntityCollection colecaoConta = serviceProxy.RetrieveMultiple(queryExpression);
            var Conectarconta = new TRACRM().Importar();

            foreach (var item in colecaoConta.Entities)
            {
                try
                {
                    var inserir = new Entity("account");
                    Guid CRMconta = new Guid();

                    if (item.Attributes.Contains("name"))
                        inserir.Attributes.Add("name", item["name"]);

                    if (item.Attributes.Contains("new_cnpj"))
                        inserir.Attributes.Add("tra_cnpj", item["new_cnpj"]);

                    if (item.Attributes.Contains("new_website_conta"))
                        inserir.Attributes.Add("tra_website_conta", item["new_website_conta"]);

                    if (item.Attributes.Contains("new_email_conta"))
                        inserir.Attributes.Add("tra_email_conta", item["new_email_conta"]);

                    if (item.Attributes.Contains("new_telefone_conta"))
                        inserir.Attributes.Add("tra_telefone_conta", item["new_telefone_conta"]);

                    if (item.Attributes.Contains("new_endereco_conta"))
                        inserir.Attributes.Add("tra_endereco_conta", item["new_endereco_conta"]);

                    if (item.Attributes.Contains("new_cep"))
                        inserir.Attributes.Add("tra_cep", item["new_cep"].ToString());

                    CRMconta = Conectarconta.Create(inserir);
                }
                catch (Exception)
                {

                }
            }
            return colecaoConta;
        }
        #endregion

        #region Coleção Contato
        static EntityCollection Contato(CrmServiceClient serviceProxy)
        {
            QueryExpression queryExpression = new QueryExpression("contact");
            queryExpression.ColumnSet = new ColumnSet("firstname", "lastname", "new_cpf", "new_telefone_contato", "new_email_contatol", "new_endereco_contato", "new_cep");

            EntityCollection colecaoContato = serviceProxy.RetrieveMultiple(queryExpression);
            var Conectar = new TRACRM().Importar();

            foreach (var item in colecaoContato.Entities)
            {
                try
                {
                    var inserir = new Entity("contact");
                    Guid CRM = new Guid();

                    if (item.Attributes.Contains("firstname"))
                        inserir.Attributes.Add("firstname", item["firstname"]);

                    if (item.Attributes.Contains("lastname"))
                        inserir.Attributes.Add("lastname", item["lastname"]);

                    if (item.Attributes.Contains("new_cpf"))
                        inserir.Attributes.Add("tra_cpf", item["new_cpf"]);

                    if (item.Attributes.Contains("new_telefone_contato"))
                        inserir.Attributes.Add("tra_telefone_contato", item["new_telefone_contato"]);

                    if (item.Attributes.Contains("new_email_contatol"))
                        inserir.Attributes.Add("tra_email_contato", item["new_email_contatol"]);

                    if (item.Attributes.Contains("new_endereco_contato"))
                        inserir.Attributes.Add("tra_endereco_contato", item["new_endereco_contato"]);

                    if (item.Attributes.Contains("new_cep"))
                        inserir.Attributes.Add("tra_cep", item["new_cep"]);

                    CRM = Conectar.Create(inserir);
                }
                catch (Exception)
                {

                }
            }
            return colecaoContato;
        }
        #endregion

        #region Coleção Pedido
        static EntityCollection Pedido(CrmServiceClient serviceProxy)
        {
            QueryExpression queryExpression = new QueryExpression("new_pedidos");
            queryExpression.ColumnSet = new ColumnSet("new_idpedido", "new_empresa_pedido", "new_cp_pedido", "new_formpag_pedido", "new_envio_pedido");

            EntityCollection colecaoPedido = serviceProxy.RetrieveMultiple(queryExpression);
            var Conectar = new TRACRM().Importar();

            foreach (var item in colecaoPedido.Entities)
            {
                try
                {
                    var inserir = new Entity("tra_pedido");
                    Guid CRM = new Guid();

                    if (item.Attributes.Contains("new_idpedido"))
                        inserir.Attributes.Add("tra_idpedido", item["new_idpedido"]);

                    if (item.Attributes.Contains("new_empresa_pedido"))
                        inserir.Attributes.Add("tra_empresa_pedido", item["new_empresa_pedido"]);

                    if (item.Attributes.Contains("new_cp_pedido"))
                        inserir.Attributes.Add("tra_cliente", item["new_cp_pedido"]);

                    if (item.Attributes.Contains("new_formpag_pedido"))
                        inserir.Attributes.Add("tra_formpag_pedido", item["new_formpag_pedido"]);

                    if (item.Attributes.Contains("new_envio_pedido"))
                        inserir.Attributes.Add("tra_envio_pedido", item["new_envio_pedido"]);

                    CRM = Conectar.Create(inserir);
                }
                catch (Exception)
                {

                }
            }
            return colecaoPedido;
        }
        #endregion

        #region Coleção Itens do Pedido
        static EntityCollection itemPedido(CrmServiceClient serviceProxy)
        {
            QueryExpression queryExpression = new QueryExpression("new_itemdopedido");
            queryExpression.ColumnSet = new ColumnSet("new_codigo", "new_nomeproduto", "new_valor_", "new_descricao", "new_cor_item");

            EntityCollection colecaoitemPedido = serviceProxy.RetrieveMultiple(queryExpression);
            var Conectar = new TRACRM().Importar();

            foreach (var item in colecaoitemPedido.Entities)
            {
                try
                {
                    var inserir = new Entity("tra_itemdopedido");
                    Guid CRM = new Guid();

                    if (item.Attributes.Contains("new_codigo"))
                        inserir.Attributes.Add("tra_codigo", item["new_codigo"]);

                    if (item.Attributes.Contains("new_nomeproduto"))
                        inserir.Attributes.Add("tra_nomeproduto", item["new_nomeproduto"]);

                    if (item.Attributes.Contains("new_valor_"))
                        inserir.Attributes.Add("tra_valor_", item["new_valor_"]);

                    if (item.Attributes.Contains("new_descricao"))
                        inserir.Attributes.Add("tra_descricao", item["new_descricao"]);

                    if (item.Attributes.Contains("new_cor_item"))
                        inserir.Attributes.Add("tra_cor_item", item["new_cor_item"]);

                    CRM = Conectar.Create(inserir);
                }
                catch (Exception)
                {

                }
            }
            return colecaoitemPedido;
        }
        #endregion
    }
}