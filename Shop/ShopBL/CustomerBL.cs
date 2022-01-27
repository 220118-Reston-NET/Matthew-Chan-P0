using ShopDL;
using ShopModel;

namespace CustomerBL{
    public class CustomerBL: ICustomerBL{
        // Dependency Injection Pattern
        // ==================================
        private IRepsitory _repo;

        public CustomerBL(IRepository c_rep){
            _repo = c_repo;
        }
        // ==================================

        public Customer AddCustomers(Customer c_customer){
            Random rand = new Random();

            //c_customer.uniqueID == rand.Next(0,9999999); will determine a way to actually make it unique later, or should just do some kind of incrmeent with a static variable would work too

            return _repo.AddCustomer(c_customer);
        }

        /*
        public List<CustomerModel SearchCustomer(string c_name){
            List<Customer> listOfCustomers - _repo.GetAllCustomer();
        }
        */
    }
}