using ShopBL;
using ShopModel;

namespace ShopUI
{
    public class AddOrderMenu : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddOrder
        private static Order _newOrder = new Order();
        private ICustomerBL _custBL;
        //Dependency Injection
        //==========================
        private IOrderBL _OrderBL;
        public AddOrderMenu(IOrderBL o_orderBL, ICustomerBL c_custBL)
        {
            _OrderBL = o_orderBL;
            _custBL = c_custBL;
        }
        //==========================
        
        

        public void Display()
        {
            Console.WriteLine("Please enter your customer id and name");
            int custId = Convert.ToInt32(Console.ReadLine());
            string custName = Console.ReadLine();


            Console.WriteLine("Enter Customer information");
            
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
        }

        public string UserChoice()
        {
            /* string userInput = Console.ReadLine();

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
                    return "AddOrder" 
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddCustomer";
                    
                
            }*/
            return "SearchInventory";
        }
    }
}