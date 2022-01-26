using ShopBL;
using ShopModel;

namespace ShopUI
{
    public class AddCustomerMenu : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
        private static Customer _newCustomer = new Customer();

        //Dependency Injection
        //==========================
        private ICustomerBL _pokeBL;
        public AddCustomerMenu(ICustomerBL s_customerBL)
        {
            _customerBL = s_customerBL;
        }
        //==========================

        public void Display()
        {
            Console.WriteLine("Enter Customer information");
            Console.WriteLine("[3] Name - " + _newCustomer.Name);
            Console.WriteLine("[2] Age - " + _newCustomer.Age);
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
                        _customerBL.AddCustomers(_newCustomer);
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter a Age!");
                    _newCustomer.Age = Convert.ToInt32(Console.ReadLine());
                    return "AddCustomer";
                case "3":
                    Console.WriteLine("Please enter a name!");
                    _newCustomer.Name = Console.ReadLine();
                    return "AddCustomer";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddCustomer";
            }
        }
    }
}