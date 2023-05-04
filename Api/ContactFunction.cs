using System;
using System.Net;
using BlazorApp.Shared;
using System.Net.Mail;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Api
{
    public class ContactFunction
    {
        [Function("ContactFunction")]
        public void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
            HttpRequestData req)
        {
            SendMail(JsonSerializer.Deserialize<ContactMessage>(req.Body));
        }
        public void SendMail(ContactMessage contactMessage)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("ianosborne.dev@gmail.com", Environment.GetEnvironmentVariable("MailPassword")),
            };
            MailMessage message = new();
            message.From = new MailAddress("ianosborne.dev@gmail.com");
            message.To.Add("electstevebratcher@gmail.com");
            message.Body = $"You have received a new message through your website from {contactMessage.Name}. \nYou can respond to the sender at {contactMessage.Email}. \nThe user has left the following message:\n {contactMessage.Message}";
            message.Subject = contactMessage.Subject;
            smtpClient.Send(message);
        }
    }
}
