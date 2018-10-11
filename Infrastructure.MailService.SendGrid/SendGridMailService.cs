using System;
using Domain.Shared;

namespace Infrastructure.MailService.SendGrid
{
    public class SendGridMailService : IMailService
    {
        public void SendBalanceNotification(int atmId, double balance)
        {
            // call SendGrid API
        }
    }
}
