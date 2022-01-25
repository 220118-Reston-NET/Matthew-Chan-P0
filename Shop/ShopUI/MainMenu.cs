namespace ShopUI
{

    public class MainMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to Our Shop!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Add a new Customer");
            Console.WriteLine("[2] Find a Customer");
            Console.WriteLine("[3] Search Inventory");
            Console.WriteLine("[4] View Inventory");
            COnsole.WriteLine("[5] Place Order");
            Console.WriteLine("[6] Replenish Inventory");
            Console.WriteLine("[0] Exit");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            //Switch cases are just useful if you are doing a bunch of comparison
            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "???????????";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}