using VendingMachine.Data;
using VendingMachine.Models;

namespace VendingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Drink fanta = new Drink("Fanta", 15, "läsk", true);
            Drink apelsinJuice = new("Apelsinjuice", 20, "nyttig", false);
            Drink kaffe = new("Kaffe", 20, "uppiggande", false);
            Product[] drinks = new Product[] { fanta, apelsinJuice, kaffe };

            List<String> drinkListInfo = new List<String>();
            foreach (Product drink in drinks) drinkListInfo.Add(drink.Examine());

            int[] coinUnits = new int[] { 100, 50, 20, 10, 5, 2, 1 };
            VendingMachineService service = new VendingMachineService(coinUnits);
            Dictionary<int, int> change = new Dictionary<int, int>();

            bool keepLive = true;
            do
            {
                try
                {
                    Console.WriteLine("----- Varuautomat -----");
                    Console.WriteLine("1 Dricka ");
                    Console.WriteLine("8 Färdighandlat ");
                    Console.WriteLine("9 Avsluta ");
                    Console.WriteLine("Vad väljer du: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine();
                            for(int i = 0; i < drinks.Length; i++)
                                Console.WriteLine(i + " " + drinks[i].Examine());
                            Console.WriteLine("Vilken dricka vill du ha?");
                            int drinkChoice = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Betala {0} kr", drinks[drinkChoice].Price);

                            //      int[] coinUnits = { 100, 50, 20, 10, 5, 2, 1 };
                            double paydMoney = Convert.ToDouble(Console.ReadLine());
                            service.InsertMoney(paydMoney - drinks[drinkChoice].Price);
                    //        service.InsertMoney(service.MoneyPool - drinks[drinkChoice].Price);
                            Console.WriteLine("Du har {0} kvar. ", service.MoneyPool);
                            drinks[drinkChoice].Use();

                            if(service.MoneyPool == 0)
                            {
                                break;
                            }
                            Console.WriteLine("Vill du handla något mer? J/N ");
                            string? shopMore = Console.ReadLine();
                            if(shopMore == "N" || shopMore == "n" )
                            {
                                Console.WriteLine("Din växel: ");
                                change = service.EndTransaction();
                                foreach (KeyValuePair<int, int> kvp in change)
                                {
                                    Console.WriteLine("{0} sedel/mynt {1} st", kvp.Key, kvp.Value);
                                }
                             /*   foreach (int i in coinUnits)
                                {
                                    if (((int)(moneyPool / i)) != 0)
                                    {
                                        Console.WriteLine(i + " sedel/mynt = " + (int)(moneyPool / i));
                                    }
                                    moneyPool = moneyPool % i;
                                }
                             */

                            }

                            break;

                        case 8:
                           // Dictionary<int, int> change = service.EndTransaction();
                           // Console.WriteLine("Din växel är {0} kr.", change);
                            break;

                        case 9:
                            Console.WriteLine("Välkommen tillbaka!");
                            keepLive = false;
                            break;

                        default:
                            Console.WriteLine("{0} finns inte att välja. Försök igen.", choice);
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Något gick fel.");
                }
            }
            while (keepLive);


        }//End of maine

       

    }//End of class
}//End of namespace