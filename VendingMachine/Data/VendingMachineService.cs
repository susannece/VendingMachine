using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Data
{
    public class VendingMachineService //: IVending
    {
        //   private readonly int[]? coinUnits = new int[] { 100, 50, 20, 10, 5, 2, 1 };
        private readonly int[]? coinUnits;
//        private double moneyPool;
//        private Dictionary<int, int>? change ;

        public VendingMachineService(int[]? coinUnits)
        {
            this.coinUnits = coinUnits;
            MoneyPool = 0;
//            change = new Dictionary<int, int>();
 //           change.Add(0, 0);
        }
        public double MoneyPool
        {
            get { return this.MoneyPool; }
            set { this.MoneyPool = value; }
        }

        public int[] CoinUnits
        {
            get { return this.CoinUnits; }
            set { this.CoinUnits = value; }
        }

        //    public Product Purchase() { }
        //    public List<string> ShowAll() { }
        //    public string Details() { }
        public void InsertMoney(double money) 
        { 
            this.MoneyPool = money;
        }
        public Dictionary<int, int> EndTransaction() 
        {
            Dictionary<int, int>? change = new Dictionary<int, int>();
            for (int i = 0; i < CoinUnits.Length; i++)
            {
                if (((int)(MoneyPool / i)) != 0)
                {
                    change.Add(CoinUnits[i], (int)(MoneyPool / i));
                    Console.WriteLine(i + " sedel/mynt = " + (int)(MoneyPool / i));
                }
                MoneyPool = MoneyPool % i;
            }
            return change;
        }


    }//End of class
}//End of namspace
