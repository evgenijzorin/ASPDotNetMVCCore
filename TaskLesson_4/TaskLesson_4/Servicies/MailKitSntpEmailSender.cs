using MailKit.Net.Smtp;
using MimeKit;
using TaskLesson_4.Servicies.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit.Text;



namespace TaskLesson_4.Servicies
{
    public class MailKitSntpEmailSender : IEmailSender
    {
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
                await _smtpClient.ConnectAsync("smtp.beget.com", 25, false); // Настройки используемого сервера
                await _smtpClient.AuthenticateAsync(emailSendler, password);
                await _smtpClient.SendAsync(emailMessage);
                await _smtpClient.DisconnectAsync(true);
            }
        }
    }
}
