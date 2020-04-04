using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Model.Mail
{
    public class Mail
    {
        private string filepath;
        private string from;
        private string password;
        private string to;
        private string subject;
        private string body;

        private SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        private MailMessage mail = new MailMessage();

        public Mail(string filepath, string from, string password, string to, string subject, string body)
        {
            this.filepath = filepath;
            this.from = from;
            this.password = password;
            this.to = to;
            this.subject = subject;
            this.body = body;
        }
        public int Sent_mail()
        {
            
            try
            {
                mail.From = new MailAddress(this.from);
                mail.To.Add(this.to);
                mail.Subject = this.subject;
                mail.Body = this.body;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new NetworkCredential(this.from, this.password);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception)
            {
                Console.WriteLine("not working****************************");

                return 0;
            }
            Console.WriteLine("works****************************");

            return 1;
        }
        public int Sent_mail_withfile()
        {
            try
            {
                mail.From = new MailAddress(this.from);
                mail.To.Add(this.to);
                mail.Subject = this.subject;
                mail.Body = this.body;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential(this.from, this.password);
                SmtpServer.EnableSsl = true;
                mail.Attachments.Add(new Attachment(this.filepath));
                SmtpServer.Send(mail);
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }
    }
}
