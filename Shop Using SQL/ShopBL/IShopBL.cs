using ShopModel;

namespace ShopBL
{
    
    public interface ICustomerBL {
        Customer AddCustomer (Customer c_cust);
        //public List<Customer> GetCustomerByCustId(int c_custId);

        List<Customer> SearchCustomer(string c_name);
        List<Customer> SearchCustomerFromNumber(string c_pnum);
        List<Customer> SearchCustomerFromEMail(string c_email);
        
        bool CheckIfEmpty(List<Customer> listOfCust); 
        List<Customer> GetAllCustomers();

    } 

    
    
    public interface IProductBL {
        Product AddProduct (Product p_prod);

        List<Product> SearchProduct(string p_name);
        List<Product> GetAllCustomer();
    }

    public interface IStoreFrontBL{
        StoreFront AddStoreFront (StoreFront s_store);
        List<StoreFront> SearchStoreFrontName(string s_store);
        List<StoreFront> GetAllStoreFronts();
        //void SearchStoreFrontProducts(string s_product);

        bool CheckIfEmpty(List<StoreFront> listOfCust);
    }

    
}
