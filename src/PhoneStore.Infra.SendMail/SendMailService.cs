using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PhoneStore.Infra.SendMail
{
    public class SendMailService : ISendMailService
    {
        private readonly string _host;
        private readonly string _userName;
        private readonly string _password;
        private readonly int _port;

        public SendMailService(
            string host,
            int port,
            string userName,
            string password)
        {
            _host = host;
            _userName = userName;
            _password = password;
            _port = port;
        }
        public async Task Send(
            string subject,
            List<string> to,
            string body,
            string from = null,
            List<string> cc = null,
            MailPriority priority = MailPriority.Normal,
            bool IsBodyHtml = true)
        {
            SmtpClient client = new SmtpClient(_host);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_userName, _password);
            client.Port = _port;
            client.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();

            if (from is null)
                mailMessage.From = new MailAddress(_userName);
            else
                mailMessage.From = new MailAddress(from);

            foreach (var item in to)
                mailMessage.To.Add(item);

            if (!(cc is null))
                foreach (var item in cc)
                    mailMessage.CC.Add(item);

            mailMessage.Subject = subject;
            mailMessage.Body = body;

            mailMessage.Priority = priority;
            mailMessage.IsBodyHtml = IsBodyHtml;
            mailMessage.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            client.Send(mailMessage);
        }
    }
}
