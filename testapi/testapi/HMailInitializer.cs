using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using hMailServer;

namespace API
{
    public static class HMailInitializer
    {
        private static string _adminUsername;
        private static string _adminPassword;

        // Metodo per configurare le credenziali
        public static void ConfigureCredentials(IConfiguration configuration)
        {
            _adminUsername = configuration["HMailServer:DbName"];
            _adminPassword = configuration["HMailServer:DbPassword"];
        }

        public static void Initialize()
        {
            try
            {
                var app = new Application();
                app.Authenticate("Administrator", "");

                for (int i = 0; i < app.Domains.Count; i++)
                {
                    var domain1 = app.Domains[i];
                    if (domain1.Name.Equals("localhost.com", StringComparison.OrdinalIgnoreCase))
                    {//if domain already exists
                        return;
                    }
                }
                var domain = app.Domains.Add();
                domain.Name = "localhost.com";
                domain.Active = true;
                domain.Save();

                var admin = domain.Accounts.Add();
                admin.Address = "admin@localhost.com";
                admin.Password = "12345";
                admin.Active = true;
                admin.AdminLevel = eAdminLevel.hAdminLevelDomainAdmin;
                admin.Save();

                var server = domain.Accounts.Add();
                server.Address = "server@localhost.com";
                server.Password = "12345";
                server.Active = true;
                server.AdminLevel = eAdminLevel.hAdminLevelServerAdmin;
                server.Save();

                var user = domain.Accounts.Add();
                user.Address = "user@localhost.com";
                user.Password = "12345";
                user.Active = true;
                user.AdminLevel = eAdminLevel.hAdminLevelNormal;
                user.Save();

                SetPort(app, eSessionType.eSTSMTP, 9000);
                SetPort(app, eSessionType.eSTIMAP, 10000);

                //app.Settings.AutoBanMinutes = 0;

                app.Reinitialize();

            }
            catch (Exception ex)
            {
                throw new Exception("hMailServer init failed: " + ex.Message);
            }
        }



        private static void SetPort(Application app, eSessionType protocol, int newPort)
        {
            var tcpPorts = app.Settings.TCPIPPorts;
            for (int i = 0; i < tcpPorts.Count; i++)
            {
                var port = tcpPorts[i];
                if (port.Protocol == protocol)
                {
                    if (port.Protocol == eSessionType.eSTSMTP && i != 587)
                    {
                        continue;
                    }
                    port.PortNumber = newPort;
                    port.ConnectionSecurity = eConnectionSecurity.eCSNone;
                    port.Save();
                    return;
                }
            }

            var newTcpPort = tcpPorts.Add();
            newTcpPort.PortNumber = newPort;
            newTcpPort.Protocol = protocol;
            newTcpPort.ConnectionSecurity = eConnectionSecurity.eCSNone;
            newTcpPort.Save();
        }
        private static Domain GetDomain()
        {
            var app = new hMailServer.Application();
            app.Authenticate("Administrator", "");
            for (int i = 0; i < app.Domains.Count; i++)
            {
                var domain1 = app.Domains[i];
                if (domain1.Name.Equals("localhost.com", StringComparison.OrdinalIgnoreCase))
                {
                    return domain1;
                }
            }
            throw new Exception("hMailServer init failed: Domain not found");
        }
        public static void AddCustomersEmail(List<CustomerUserDTOCreate> customers)
        {
            try
            {
                Domain domain = GetDomain();
                foreach (var customer in customers)
                {
                    var user = domain.Accounts.Add();
                    user.Address = customer.Email;
                    user.Password = customer.Password;
                    user.Active = true;
                    user.AdminLevel = eAdminLevel.hAdminLevelNormal;
                    user.Save();
                }
            }
            catch (Exception ex) { throw new Exception("hMailServer init failed: " + ex.Message); }
        }
        public static void RemoveCustomersEmail(CustomerUser customers)
        {
            try
            {
                Domain domain = GetDomain();
                for (int i = 0; i < domain.Accounts.Count; i++)
                {
                    var acc = domain.Accounts[i];
                    if (acc.Address.Equals(customers.Email, StringComparison.OrdinalIgnoreCase))
                    {
                        acc.Delete();
                    }
                }
                throw new Exception("Account not found");
            }
            catch (Exception ex) { throw new Exception("hMailServer init failed: " + ex.Message); }
        }
    }


}
