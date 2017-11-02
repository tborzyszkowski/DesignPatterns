namespace singleton
{
    public class CashMachine
    {

        private static CashMachine cashMachineInstance;
        private static readonly object Padlock = new object();
        private int account;

        private CashMachine()
        {
        }

        public static CashMachine Instance
        {
            get
            {
                if (cashMachineInstance == null)
                {
                    lock (Padlock)
                    {
                        if (cashMachineInstance == null)
                        {
                            cashMachineInstance = new CashMachine();
                        }
                    }
                }
                return cashMachineInstance;
            }
        }

        public void SetMoney(int quantity)
        {
            lock (Padlock)
            {
                account += quantity;
            }
        }

        public void GetMoney(int quantity)
        {
            lock (Padlock)
            {
                account -= quantity;
            }
        }

        public int GetAccount()
        {
            lock (Padlock)
            {
                return account;
            }
        }

        public void Reset()
        {
            cashMachineInstance = null;
        }

    }
}
