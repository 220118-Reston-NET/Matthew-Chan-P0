using ShopDL;
using ShopModel;


namespace ShopBL{
    public class CustomerBL: ICustomerBL {
        // Dependency Injection Pattern
        // ==================================
        private ICustomerRepository _repo;

        public CustomerBL(ICustomerRepository c_repo){
            _repo = c_repo;
        }
        // ==================================

        public Customer AddCustomer(Customer c_customer){
            Random rand = new Random();

            //c_customer.uniqueID == rand.Next(0,9999999); will determine a way to actually make it unique later, or should just do some kind of incrmeent with a static variable would work too

            return _repo.AddCustomer(c_customer);
        }

        public List<Customer> GetAllCustomers(){
            return _repo.GetAllCustomer();
        }
        
        public List<Customer> SearchCustomer(string c_name){
            List<Customer> listOfCustomers = _repo.GetAllCustomer();
            // LINQ library
            return listOfCustomers
                        .Where(cust => cust.Name.Contains(c_name))
                        .ToList();
        }
        
        public List<Customer> SearchCustomerFromNumber(string c_pnum){
            List<Customer> listOfCustomers = _repo.GetAllCustomer();
            // LINQ library
            return listOfCustomers
                        .Where(cust => cust.PhoneNumber.Contains(c_pnum))
                        .ToList();
        }
        public List<Customer> SearchCustomerFromEMail(string c_email){
        List<Customer> listOfCustomers = _repo.GetAllCustomer();
        // LINQ library
        return listOfCustomers
                    .Where(cust => cust.Email.Contains(c_email))
                    .ToList();
        }


        public bool CheckIfEmpty(List<Customer> listOfCust){
            if(listOfCust.Any() == false){
                return true;
            }
            else{
                return false;
            }
        }
    }
}