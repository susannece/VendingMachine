using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Drink : Product
    {
        private string type;
        private bool withIce;

        public Drink(string productName, double price, string type, bool withIce)
            : base(productName, price)
        {
            this.type = type;
            this.withIce = withIce;
        }  

        public string Type 
        { 
            get { return this.type; }
            set { this.type = value; }
        }

        public bool WithIce
        {
            get { return this.withIce; }
            set { this.withIce = value; }
        }

        public override string Examine()
        {
            if(withIce)
                return base.Examine() + $" {type} med is ";
            else
                return base.Examine() + $" {type} ";
        }

        public override void Use()
        {
            Console.WriteLine("Drick din dricka.");
            //throw new NotImplementedException();
        }
    }
}
