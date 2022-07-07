using MailKit.Net.Smtp;
using MimeKit;
using Mvc_Tasks.Servicies.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using Mvc_Tasks.Options;

namespace Mvc_Tasks.Servicies
{
    public class MailKitSntpEmailSender : IEmailSender
    {
        // Внедерение заваисимости на конфигурацию в отправщик письма
        public readonly SmtpConfig _smtpConfig;
        public MailKitSntpEmailSender(IOptions<SmtpConfig> options)
        {
            // Хоть это и конструктор класса, но при создании объекта не нужно указывать параметр options 
            _smtpConfig = options.Value;
        }

        /// <summary>
        /// Отправить письмо
        /// </summary>
        /// <param name="emailRecipient">Адрес получателя</param>
        /// <param name="emailSendler">Адрес отправителя</param>
        /// <param name="password">Пароль отправителя</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="message">непосредственно письмо</param>
        /// <returns></returns>
        public async Task SendEmailAsync(string emailRecipient,
                                         string emailSendler,
                                         string password,
                                         string subject,
                                         string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", emailSendler));
            emailMessage.To.Add(new MailboxAddress("", emailRecipient));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var _smtpClient = new SmtpClient())
            {
                await _smtpClient.ConnectAsync(_smtpConfig.Host, _smtpConfig.Port, false); // Настройки используемого сервера
                await _smtpClient.AuthenticateAsync(emailSendler, _smtpConfig.Password);
                await _smtpClient.SendAsync(emailMessage);
                await _smtpClient.DisconnectAsync(true);
            }
        }
    }
}
