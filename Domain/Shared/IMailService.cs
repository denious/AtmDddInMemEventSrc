using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Shared
{
    public interface IMailService
    {
        void SendBalanceNotification(int atmId, double balance);
    }
}
