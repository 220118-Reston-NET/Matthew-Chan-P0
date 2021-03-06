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
        Inventory AddItemToInventory(int p_prodId, int s_storeId, int amount);
        

        List<Product> GetAllProducts();

            


        
    }
    public interface IOrderRepository{
        Order AddOrder(Order o_order, int custId, int storeId);
        List<Order> GetAllOrder();
        Product ProductIdToProduct(int prodId);
        List<Order> GetACustomerOrder( int cId);    
        List<Order> GetAShopOrder( int sId);

        string StoreFrontIdToAddress(int prodId);

        

        Inventory GetAnInventory(int s_storeId);

        List<Customer> GetAllCustomer();
        List<Product> GetAllProducts();
    }

    public interface IProductRepository{
        Product AddProduct(Product prod);
        List<Product> GetAllProducts();
        //List<string> GetStoreFrontsThatContainProduct(int prodId);
        Product ProductIdToProduct(int prodId);
    } 

}