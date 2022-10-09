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
        private readonly int[]? Denominations = new int[] { 100, 50, 20, 10, 5, 2, 1 };

        public double MoneyPool { get; set; }

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
            double money = MoneyPool;

            for (int i = 0; i < Denominations.Length; i++)
            {
               if (((int)(money / Denominations[i])) != 0)
               {
                    change.Add(Denominations[i], (int)(money / Denominations[i] ));
               }
                money = money % Denominations[i];
            }
            return change;
        }


    }//End of class
}//End of namspace
