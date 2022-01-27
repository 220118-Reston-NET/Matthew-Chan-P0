using System.Text.Json;
using ShopModel;

namespace CustomerDL{
    public class Repository : IRepository{
        //Relative filepath is from the PokeUI isnce that is the starting point of our application
        private string _filepath = "../ShopDL/Database/"; // cause our main method is in pokeUI
        private string _jsonString;

        public Customer AddCustomer(Customer c_customer)
        {
            //So we can change which JSOn files we can pick on other methods
            string path = _filepath + "Customer.json";
            
            _jsonString = JsonSerializer.Serialize(c_customer, new Json JsonSerializerOptions {WriteIndented = true});

            File.WriteAllText(path , _jsonString);

            return c_customer;
        }

        
        public List<Customer> GetAllCustomer(){
            _jsonString = File.ReadAllText(_filepath + "Customer.json");

            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }
    }
    n
    }
}