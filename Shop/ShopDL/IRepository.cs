using ShopModel;

namespace ShopDL{
    public interface ICustomerRepository
    {
        Customer AddCustomer(Customer c_cust);

        List<Customer> GetAllCustomer();
    }
    
    public interface ISQLCustomerRepository
    {
        Customer GetCustomerByCustId(Customer c_cust);
        List<Customer> GetAllCustomer();
    }
    public interface IStoreFrontRepository
    {
        StoreFront AddStoreFront(StoreFront s_store);
        List<StoreFront> GetAllStoreFront();
    }
}