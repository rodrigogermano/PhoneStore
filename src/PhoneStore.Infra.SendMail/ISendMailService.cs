using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PhoneStore.Infra.SendMail
{
    public interface ISendMailService
    {
        Task Send(string subject, List<string> to, string body, string from = null, List<string> cc = null, MailPriority priority = MailPriority.Normal, bool IsBodyHtml = true);
    }
}
