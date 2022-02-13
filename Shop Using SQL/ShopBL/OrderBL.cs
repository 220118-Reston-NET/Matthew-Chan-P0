using ShopDL;
using ShopModel;


namespace ShopBL{
    public class OrderBL: IOrderBL {
        // Dependency Injection Pattern
        // ==================================
        private IOrderRepository _repo;

        public OrderBL(IOrderRepository o_repo){
            _repo = o_repo;
        }
        // ==================================

        
        
        public Order AddOrder(Order o_order, int custId, int storeId){
            // i need to make sure the order doesn't exceed inventory
            //so i need to get the inventory first
            // then get all existing order
            // then add up the items to see if order would exceed the inventory
            // if there's an issue, return an error message
            // if there's no error, just do the code below
            return _repo.AddOrder(o_order, custId, storeId);
        } 

        public Product ProductIdToProduct(int prodId){
            return _repo.ProductIdToProduct(prodId);
        }
        
        /*
        public Order GetOrderByCustId(int o_ordId){
            return _repo.GetOrderByCustId(o_ordId);
        }
        */
        public List<Order> GetAllOrder(){
            return _repo.GetAllOrder();
        }
        public List<Order> GetACustomerOrder( int cId){
            return _repo.GetACustomerOrder(cId);
        }

        public List<Order> GetAShopOrder( int sId) {
            return _repo.GetAShopOrder(sId);
        }


/*
        public List<Order> SearchOrderFromCustId(int o_Id){
            List<Order> listOfOrders = _repo.GetAllOrder();
            // LINQ library
            return listOfOrders
                        .Where(ord => ord.ordId == o_Id)
                        .ToList();
        }
        public List<Order> SearchOrder(string o_name){
            List<Order> listOfOrders = _repo.GetAllOrder();
            // LINQ library
            return listOfOrders
                        .Where(ord => ord.Name.Contains(o_name))
                        .ToList();
        }
        
        public List<Order> SearchOrderFromNumber(string o_pnum){
            List<Order> listOfOrders = _repo.GetAllOrder();
            // LINQ library
            return listOfOrders
                        .Where(ord => ord.PhoneNumber.Contains(o_pnum))
                        .ToList();
        }
        public List<Order> SearchOrderFromEMail(string o_email){
        List<Order> listOfOrders = _repo.GetAllOrder();
        // LINQ library
        return listOfOrders
                    .Where(ord => ord.Email.Contains(o_email))
                    .ToList();
        }


        public bool CheckIfEmpty(List<Order> listOfCust){
            if(listOfCust.Any() == false){
                return true;
            }
            else{
                return false;
            }
            
        } */
    } 
}