using ShopBL;
using ShopModel;

namespace ShopUI
{
    public class AddCustomerMenu : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
        private static Customer _newCust = new Customer();

        //Dependency Injection
        //==========================
        private ICustomerBL _custBL;
        public AddCustomerMenu(ICustomerBL s_custBL)
        {
            _custBL = s_custBL;
        }
        //==========================

        public void Display()
        {
            Console.WriteLine("Enter Customer information");
            Console.WriteLine("[6] Name - " + _newCust.Name );
            Console.WriteLine("[5] Age - " + _newCust.Age);
            Console.WriteLine("[4] Address - " + _newCust.Address );
            Console.WriteLine("[3] Email - " + _newCust.Email );
            Console.WriteLine("[2] Phone number - " + _newCust.PhoneNumber);
            Console.WriteLine("[1] Save");
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
                        _custBL.AddCustomer(_newCust);
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter a phone number!");
                    _newCust.PhoneNumber = Console.ReadLine();
                    return "AddCustomer";
                case "3":
                    Console.WriteLine("Please enter an email!");
                    _newCust.Email = Console.ReadLine();
                    return "AddCustomer";
                case "4":
                    Console.WriteLine("Please enter an address!");
                    _newCust.Address = Console.ReadLine();
                    return "AddCustomer";
                case "5":
                    Console.WriteLine("Please enter a Age!");
                    _newCust.Age = Convert.ToInt32(Console.ReadLine());
                    return "AddCustomer";
                case "6":
                    Console.WriteLine("Please enter a name!");
                    _newCust.Name = Console.ReadLine();
                    return "AddCustomer";
                /*case "4":
                    Console.WriteLine("Please enter the amount of items you would like to order: ");
                    int numOfItems = Convert.ToInt32(Console.ReadLine());
                    for(int i = 0; i < numOfItems; i++){
                        Console.WriteLine("Item " + i + ": ");
                        List<CustomerModel>.Add(new CustomerModel )
                    }
                    return "AddOrder" */
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddCustomer";
            }
        }
    }
}