using System;

namespace Domain
{
    public partial class Atm
    {
        private void OnCashBalanceChanged(Atm atm)
        {
            var handler = CashBalanceChanged;
            handler?.Invoke(this, new AtmEventArgs(atm));
        }

        public delegate void CustomEventHandler(object sender, AtmEventArgs a);
        public event CustomEventHandler CashBalanceChanged;

        public class AtmEventArgs : EventArgs
        {
            public Atm Atm { get; }

            public AtmEventArgs(Atm atm)
            {
                Atm = atm;
            }
        }
    }
}
