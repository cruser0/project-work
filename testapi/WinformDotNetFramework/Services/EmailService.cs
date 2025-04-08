using Entity_Validator.Entity.DTO;
using System.Threading.Tasks;

namespace WinformDotNetFramework.Services
{
    internal class EmailService : BaseCallService
    {
        public async Task<EmailDTO> Create(EmailDTO entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnRestult = await PostItem(client, "Mail", entity, "Mail");
            return returnRestult;
        }
    }
}
