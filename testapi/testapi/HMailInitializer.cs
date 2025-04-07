using hMailServer;
namespace API
{
    public class HMailInitializer
    {

        public static void Initialize()
        {
                try
                {
                    var app = new hMailServer.Application();
                    app.Authenticate("Administrator", "12345");

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
                    admin.Save();

                    var user = domain.Accounts.Add();
                    user.Address = "user@localhost.com";
                    user.Password = "12345";
                    user.Active = true;
                    user.Save();

                    SetPort(app, eSessionType.eSTSMTP, 9000);
                    SetPort(app, eSessionType.eSTIMAP, 10000);

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
    }


}
