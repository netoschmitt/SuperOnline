﻿using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace SuperOnline.Services
{
    public class SendGridSender : IEmailSender
    {        
        public async Task SendEmailAsync(string email, string assunto, string mensagemTexto, string mensagemHtml)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("netoschmitt@outlook.com", "Schmitt Online");
            var subject = assunto;
            var to = new EmailAddress(email);
            var plainTextContent = mensagemTexto;
            var htmlContent = mensagemHtml;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }        
    }
}
