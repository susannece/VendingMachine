using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VendingMachine.Models
{
    public abstract class Product
    {
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public Product(string productName, double price)
        {
            ProductName = productName;
            Price = price;
        }

        public virtual string Examine()
        {
            return $" {ProductName} {Price} kr ";
        }
        public abstract void Use();

    }
}
