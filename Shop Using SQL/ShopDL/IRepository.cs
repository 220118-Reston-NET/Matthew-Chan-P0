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



        //Inventory AddInventory(Inventory i_inven);
        List<Inventory> GetAllInventory();
        Inventory GetAnInventory(int id);
        Inventory RestockInventory(int p_prodId, int s_storeId, int amount);


        
    }
    public interface IOrderRepository{
        Order AddOrder(Order o_order);
        List<Order> GetAllOrder();
    }


}