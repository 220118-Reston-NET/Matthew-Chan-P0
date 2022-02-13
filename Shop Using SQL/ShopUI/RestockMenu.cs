
using ShopBL;
using ShopModel;

namespace ShopUI
{
    public class RestockMenu : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
        private static int storeId;
        private static int productId;
        private static int amount;

        //Dependency Injection
        //==========================
        private IStoreFrontBL _storeBL;
        public RestockMenu(IStoreFrontBL s_storeBL)
        {
            _storeBL = s_storeBL;
        }
        //==========================

        public void Display()
        {
            Console.WriteLine("Enter StoreFront information");
            Console.WriteLine("[4] Store ID - " + storeId );
            Console.WriteLine("[3] Product ID - " + productId );
            Console.WriteLine("[2] Amount:" + amount);
            Console.WriteLine("[1] Update");
            Console.WriteLine("[5] Add");
            Console.WriteLine("[0] Go Back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    //Exception handling to have a better user experience
                    try
                    {
                        _storeBL.RestockInventory(productId, storeId, amount);
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter the amount of products to be replenished!");
                    amount = Convert.ToInt32(Console.ReadLine());
                    return "Restock";
                case "3":
                    Console.WriteLine("Please enter the Product ID!");
                    productId = Convert.ToInt32(Console.ReadLine());
                    return "Restock";
                case "4":
                    Console.WriteLine("Please enter the Store ID!");
                    storeId = Convert.ToInt32(Console.ReadLine());
                    return "Restock";
                case "5":
                    try
                    {
                        _storeBL.AddItemToInventory(productId, storeId, amount);
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Restock";
            }
        }
    }
}
