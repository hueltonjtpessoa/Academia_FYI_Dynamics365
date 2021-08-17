using Microsoft.Xrm.Tooling.Connector;
using System.Net;

namespace TCCV4
{
    class TRACRM
    {

        private static CrmServiceClient crmServiceOldCRM;

        public CrmServiceClient Importar()
        {
            var connectionStringCRM = @"AuthType=OAuth;
            Username = admin@orangecareer.onmicrosoft.com;
            Password = Gr0up123; SkipDiscovery = True;
            AppId = 51f81489-12ee-4a9e-aaae-a2591f45987d;
            RedirectUri = app://c51eabd4-d8f4-eb11-94ef-0022483660;
            Url = https://org2e50e42d.crm2.dynamics.com/main.aspx";

            if (crmServiceOldCRM == null)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                crmServiceOldCRM = new CrmServiceClient(connectionStringCRM);
            }
            return crmServiceOldCRM;
        }
    }
    class NewCRM
    {
        private static CrmServiceClient crmServiceNewCRM;

        public CrmServiceClient Obter()
        {
            var connectionStringCRM = @"AuthType=OAuth;
            Username = adm@orangecareer365.onmicrosoft.com;
            Password = Gr0up123; SkipDiscovery = True;
            AppId = 51f81489-12ee-4a9e-aaae-a2591f45987d;
            RedirectUri = app://ee5a4250-d5f0-eb11-94ef-00224836762a;
            Url = https://org510aeab8.crm2.dynamics.com/main.aspx";

            if (crmServiceNewCRM == null)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                crmServiceNewCRM = new CrmServiceClient(connectionStringCRM);
            }
            return crmServiceNewCRM;
        }
    }
}