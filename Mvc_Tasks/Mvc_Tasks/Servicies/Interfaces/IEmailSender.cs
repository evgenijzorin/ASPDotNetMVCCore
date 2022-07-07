namespace Mvc_Tasks.Servicies.Interfaces
{
    public interface IEmailSender
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
        public async Task SendEmailAsync(string emailRecipient, // Адрес получателя
                                         string emailSendler,
                                         string password,
                                         string subject, // Тема письма
                                         string message) { }
    }
}
