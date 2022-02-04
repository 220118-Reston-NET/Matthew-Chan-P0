using ShopModel;

namespace ShopDL{
    public interface ICustomerRepository
    {
        Customer AddCustomer(Customer c_cust);

        List<Customer> GetAllCustomer();
        //List<Customer> GetCustomerByCustId(int c_custId);
    }
    
    public interface IStoreFrontRepository
    {
        StoreFront AddStoreFront(StoreFront s_store);
        List<StoreFront> GetAllStoreFront();
    }
}