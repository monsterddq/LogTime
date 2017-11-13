using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LogTime.Utility
{
    public static class Utility
    {
        public static string Sha512Hash(string message)
        {
            System.Text.StringBuilder Sb = new System.Text.StringBuilder();
            var b1 = System.Text.Encoding.UTF8.GetBytes(message);
            var bs = System.Security.Cryptography.SHA512.Create().ComputeHash(b1);
            foreach (byte b in bs)
                Sb.Append(b.ToString("x2"));
            return Sb.ToString();
        }
        public static async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Art Graphic Stock", "noreply.1@artgraphicstock.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                var credentials = new NetworkCredential
                {
                    UserName = "noreply.1@artgraphicstock.com", // replace with valid value
                    Password = "trannamtrang2017" // replace with valid value
                };

                client.LocalDomain = "domain.com";
                // check your smtp server setting and amend accordingly:
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.Auto).ConfigureAwait(false);
                await client.AuthenticateAsync(credentials);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
        //public static string GenerateCode<T>()
        //{
        //    if(typeof(T) )
        //}
    }
}
