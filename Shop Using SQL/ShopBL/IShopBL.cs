using ShopModel;

namespace ShopBL
{
    
    public interface ICustomerBL {
        Customer AddCustomer (Customer c_cust);
        public List<Customer> SearchCustomerFromCustId(int c_custId);

        List<Customer> SearchCustomer(string c_name);
        List<Customer> SearchCustomerFromNumber(string c_pnum);
        List<Customer> SearchCustomerFromEMail(string c_email);
        
        bool CheckIfEmpty(List<Customer> listOfCust); 
        List<Customer> GetAllCustomers();

    } 

    
    
/*    public interface IProductBL {
        Product AddProduct (Product p_prod);

        List<Product> SearchProduct(string p_name);
        List<Product> GetAllCustomer();
    }
*/
    public interface IStoreFrontBL{
        StoreFront AddStoreFront (StoreFront s_store);
        List<StoreFront> SearchStoreFrontName(string s_store);
        List<StoreFront> GetAllStoreFronts();
        List<StoreFront> SearchStoreFrontProducts(string s_product);

        List<Product> GetAllProducts();
        Inventory GetSpecificInventory(int id);
        //List<Product> GetProductsFromShopId(int id);
        List<StoreFront> checkStoresForAProduct(int prodId);

        void printProductsInInventory(Inventory inv);

        void RestockInventory(int p_prodId, int s_storeId, int amount);

        Inventory AddItemToInventory(int p_prodId, int s_storeId, int amount);

        bool CheckIfEmpty(List<StoreFront> listOfCust);
    }

    /* public interface IInventoryBL{
        List<StoreFront> SearchInventoryFromStoreId(int s_Id);
        List<Inventory> GetAllInventories();
        List<Products> GetProductsFromShopId(int ShopId);

        bool CheckIfEmpty(List<StoreFront> listOfCust);
    } */

    public interface IProductBL{
        Product AddProduct(Product prod);
        List<Product> GetAllProducts();
    }

    public interface IOrderBL{
        Order AddOrder(Order ord, int custID, int storeID);

        Product ProductIdToProduct(int prodId);

        List<Order> GetAllOrder();
        List<Order> GetACustomerOrder( int cId);
        List<Order> GetAShopOrder( int sId);    

    }
    
}
