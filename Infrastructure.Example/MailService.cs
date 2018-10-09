using System;
using System.Collections.Generic;
using System.Text;
using Domain.Shared;

namespace Infrastructure.Example
{
    class MailService : IMailService
    {
        public void SendBalanceNotification(double balance)
        {
            // external 3rd party call goes here
        }
    }
}
