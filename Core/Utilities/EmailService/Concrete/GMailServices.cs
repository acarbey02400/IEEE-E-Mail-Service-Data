using Core.Utilities.EmailService.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Net.Mail;
using MimeKit;

namespace Core.Utilities.EmailService.Concrete
{
    public class GMailServices : IEmailService
    {
        GmailService _service;
        static string[] Scopes = { GmailService.Scope.GmailSend };
        static string ApplicationName = "IEEE Email Service";
        public GMailServices()
        {
            UserCredential credential;

            using (var stream =
                new FileStream(@".\client_secret.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");
            _service = service;
        }
        
        public IResult sendMail(MimeMessage message)
        {
            var gmailMessage = new Google.Apis.Gmail.v1.Data.Message
            {
                Raw = Encode(message)
            };

            var result = _service.Users.Messages.Send(gmailMessage,"me").Execute();

            
            
            return new SuccessResult("");

        }


        public static string Encode(MimeMessage mimeMessage)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                mimeMessage.WriteTo(ms);
                return Convert.ToBase64String(ms.GetBuffer())
                    .TrimEnd('=')
                    .Replace('+', '-')
                    .Replace('/', '_');
            }
        }
    }
}
