using System;

namespace Domain
{
    public static class Events
    {
        public delegate void EventHandler(object sender, EventArgs eventArgs);

        public static event EventHandler CashBalanceChanged;

        public static void OnCashBalanceChanged(Atm atm)
        {
            var handler = CashBalanceChanged;
            //if (handler != null)
            //{
            //    var list = handler.GetInvocationList();
            //    foreach (EventHandler d in list)
            //    {
            //        d(atm, EventArgs.Empty);
            //    }
            //}

            handler?.Invoke(atm, new EventArgs());
        }
    }
}
