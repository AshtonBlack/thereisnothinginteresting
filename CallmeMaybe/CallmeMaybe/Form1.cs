using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace CallmeMaybe
{
    public partial class CallmeMaybe : Form
    {
        public CallmeMaybe()
        {
            InitializeComponent();
            Opacity = 0;
        }

        string botName = "Bot";
        string botLogin = "hiddenshadow@mail.ru";
        string pass = "a77777777c";
        int port = 2525;
        string host = "smtp.mail.ru";
        string masterMail = "stormywarrior67@gmail.com";
        string subject = "At your service, Master";
        string message = "Something goes wrong, Sir!..";
        string messageOK = "Everything is ok, Sir!..";
        int interval = 600000;
        int OKinterval = 3600000;

        string path = @"C:\Bot\Log.txt";

        string DefaultString = "default";
        string NewString;

        private void Form1_Load(object sender, EventArgs e)
        {
            ProblemDetectionAsync();
            NoProblemAsync();            
        }        

        private bool IsChanged()
        {
            bool x = false;
            if(NewString != DefaultString)
            {
                x = true;
                DefaultString = NewString;
            }
            return x;
        }

        private void LastString()
        {
            string lastline = "default";
            using(StreamReader sr = new StreamReader(path))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    lastline = line;
                }
                sr.Close();
            }
            NewString = lastline;
        }

        public void Mail()
        {
            MailAddress from = new MailAddress(botLogin, botName);
            MailAddress to = new MailAddress(masterMail);
            MailMessage m = new MailMessage(from, to);            
            m.Subject = subject;
            m.Body = message + " last message: " + NewString;
            SmtpClient smtp = new SmtpClient(host, port);
            smtp.Credentials = new NetworkCredential(botLogin, pass);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        public async void NoProblemAsync()
        {
            await Task.Run(() => OkMessage());
        }

        public async void ProblemDetectionAsync()
        {
            await Task.Run(() => ReportProblem());
        }

        public void ReportProblem()
        {
            bool x = true;
            while (x)
            {
                Thread.Sleep(interval);
                LastString();
                if (!IsChanged())
                {
                    Mail();
                    x = false;
                }
            }
        }

        public void OkMessage()
        {
            while (true)
            {
                Thread.Sleep(OKinterval);
                MailAddress from = new MailAddress(botLogin, botName);
                MailAddress to = new MailAddress(masterMail);
                MailMessage m = new MailMessage(from, to);
                m.Subject = subject;
                m.Body = messageOK;
                SmtpClient smtp = new SmtpClient(host, port);
                smtp.Credentials = new NetworkCredential(botLogin, pass);
                smtp.EnableSsl = true;
                smtp.Send(m);
            }            
        }
    }
}