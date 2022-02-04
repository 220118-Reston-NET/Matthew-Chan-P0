
using System.Text.Json;
using System.Text.Json.Serialization;
using ShopModel;

namespace ShopDL{
    public class CustomerRepository : ICustomerRepository{
        //Relative filepath is from the PokeUI isnce that is the starting point of our application
        private string _filepath = "../ShopDL/Database/"; // cause our main method is in pokeUI
        private string _jsonString;

        public Customer AddCustomer(Customer c_cust)
        {
            //So we can change which JSOn files we can pick on other methods
            string path = _filepath + "Customer.json";

            List<Customer> listOfCust = GetAllCustomer();
            
            //going to need to figure out a way to make customer unique id

            listOfCust.Add(c_cust);

            _jsonString = JsonSerializer.Serialize(listOfCust, new JsonSerializerOptions {WriteIndented = true});

            Console.WriteLine(_jsonString);
            Console.ReadLine();
            File.WriteAllText(path , _jsonString);
            
            
            return c_cust;
        }

        
        
        public List<Customer> GetAllCustomer(){
            _jsonString = File.ReadAllText(_filepath + "Customer.json");
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }

        
    }
}
