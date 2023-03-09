using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", "alex.aandrei@gmail.com"));
            email.To.Add(new MailboxAddress("Receiver Name", "alex.alandrei@gmail.com"));

            email.Subject = "Testing out email sending";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = "Hello all the way from the land of C#"
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
               // smtp.Authenticate("smtp_username", "smtp_password");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}

