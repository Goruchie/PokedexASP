using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;
        public EmailService() 
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("marcosgualtero43253@gmail.com", "vcag lfjg mkjz epzu");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }
        public void setEmail(string mail, string subject, string body)
        {
            email = new MailMessage();
            email.From = new MailAddress("marcosgualtero@hotmail.com");
            email.To.Add(mail);
            email.Subject = subject;
            email.IsBodyHtml = true;
            email.Body = body;
        }
        public void sendEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
