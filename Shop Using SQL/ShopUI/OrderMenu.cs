
using ShopBL;
using ShopModel;

namespace ShopUI
{
    public class OrderMenu : IMenu
    {
        public static int custId;
        public static int storeId;
        public static Order Orders = new Order(-1, new List<LineItem>{}, new List<string>{},0);

        public int numOfOrders = 0;

        //Dependency Injection
        //==========================
        private IOrderBL _orderBL;
        public OrderMenu(IOrderBL o_orderBL)
        {
            _orderBL = o_orderBL;
        }
        //==========================

        public void Display()
        { 
            Console.WriteLine("Would you like to get or make an order?");
            Console.WriteLine("[4] Select a Customer ID to order: " + custId);
            Console.WriteLine("[3] Select a Store ID to order from: " + storeId);
            Console.WriteLine("[2] Order a Product.");
            Console.WriteLine("[5] Display Orders");
            Console.WriteLine("[6] Get Orders from the customer");
            Console.WriteLine("[7] Get Orders from the Store");
            Console.WriteLine("[1] Finalize Orders: ");
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
                    try
                    {
                        //how to get store ID????
                        //for(int i = 0; i < Orders.LineItems.Count; i++)
                        //{
                        _orderBL.AddOrder(Orders, custId, storeId);
                        //}
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";                
                case "2":
                    Console.WriteLine("Number of items you would like to order!");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    for(int i = 0; i < amount; i++){
                        // need to have something that is able to retrieve a product from name/id
                        Console.WriteLine("What product would you like to order?");
                        int prodId = Convert.ToInt32(Console.ReadLine());
                        Product prod = _orderBL.ProductIdToProduct(prodId);
                        Console.WriteLine("How many of the products would you like?");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please choose a product you would like to buy: ");
                        //need a way to convert id to product


                        Orders.AddItemToOrder(new LineItem(prod, quantity),"Narnia");
                        // need to have a check to make sure customer is not able to go over
                        numOfOrders++;
                    }
                    return "PlaceOrder";
                case "3":   
                    Console.WriteLine("Please enter the Store ID!");
                    storeId = Convert.ToInt32(Console.ReadLine());
                    return "PlaceOrder";
                    
                case "4":
                    Console.WriteLine("Please enter the Customer ID!");
                    custId = Convert.ToInt32(Console.ReadLine());
                    return "PlaceOrder";

                case "5":
                    Console.WriteLine("Here are the orders: ");
                    Console.WriteLine(Orders);
                    Console.WriteLine("END\n Press enter to Continue");
                    Console.ReadLine();
                    return "PlaceOrder";
                case "6":
                    Console.WriteLine("These are the orders from the customer");
                    List<Order> custOrder = _orderBL.GetACustomerOrder( custId);
                    foreach(Order o in custOrder){
                        Console.WriteLine("=============================");
                        Console.WriteLine(o);
                    }
                    Console.WriteLine("END\n Press enter to Continue");
                    Console.ReadLine();
                    return "PlaceOrder";
                case "7":
                    Console.WriteLine("These are the orders from the customer");
                    List<Order> shopOrder = _orderBL.GetAShopOrder( custId);
                    foreach(Order o in shopOrder){
                        Console.WriteLine("=============================");
                        Console.WriteLine(o);
                    }
                    Console.WriteLine("END\n Press enter to Continue");
                    Console.ReadLine();
                    return "PlaceOrder";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Restock";
            }
        }
    }
}
