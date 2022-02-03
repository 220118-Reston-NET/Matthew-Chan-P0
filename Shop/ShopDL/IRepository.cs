using ShopModel;

namespace ShopDL{
    public interface ICustomerRepository
    {
        Customer AddCustomer(Customer c_cust);
        public List<Customer> GetAllCustomer();
    }
    
    public interface IStoreFrontRepository
    {
        StoreFront AddStoreFront(StoreFront s_store);
        public List<StoreFront> GetAllStoreFront();
    }
}