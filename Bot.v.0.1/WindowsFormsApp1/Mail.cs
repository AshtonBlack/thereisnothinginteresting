using System;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp1
{
    class Mail
    {
        public static void MailMessage(string message)
        {
            string botName = "Bot";
            string botLogin = "hiddenshadow@mail.ru";
            string pass = "iiajibi413";
            int port = 2525;
            string host = "smtp.mail.ru";
            string masterMail = "stormywarrior67@gmail.com";
            string subject = "At your service, Master";

            MailAddress from = new MailAddress(botLogin, botName);
            MailAddress to = new MailAddress(masterMail);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Body = message;
            SmtpClient smtp = new SmtpClient(host, port);
            smtp.Credentials = new NetworkCredential(botLogin, pass);
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(m);
            }
            catch(Exception ex)
            {
                NotePad.DoErrorLog("Can't send message");
            }            
            Console.Read();
        }
    }
}
