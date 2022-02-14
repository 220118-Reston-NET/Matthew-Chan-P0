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
            Inventory storeInventory = GetSpecificInventory(storeId);
            // then get all existing order
            //now, find the index of the order and find the index of the inventory
            
            // then add up the items to see if order would exceed the inventory
            if(storeInventory.quantity[0] < o_order.LineItems[0].Quantity ){
                throw new Exception("Exceeing capacity exception");
            }
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

        public bool CheckValidProduct(int sId, int pId){
            Inventory inv = GetSpecificInventory(sId);
            for(int i = 0; i < inv.Products.Count; i++ ){
                if(inv.Products[i].prodId == pId ){
                    return true;
                }
            }
            return false;
        }


        public bool checkOrder(int prodId, int quantity, Order Orders, int sId ){
            // add the quantity of the list of orders and quantity
            int totalOrderQuantity = 0;
            for( int i = 0; i < Orders.LineItems.Count; i++){
                if(Orders.LineItems[i].Products.prodId == prodId){
                    totalOrderQuantity += Orders.LineItems[i].Quantity; // accounts for the items in the order
                }
            }
            totalOrderQuantity += quantity; // this is to account for the items customer wants to order
            // get the shop inventory
            Inventory inv = GetSpecificInventory(sId);
            int inventoryQuantity = 0;
            for( int i = 0; i < inv.Products.Count; i++){
                if(inv.Products[i].prodId == prodId){
                    inventoryQuantity = inv.quantity[i];
                    break;
                }
            }
            // compare
            if(totalOrderQuantity <= inventoryQuantity){
                return true;
            }
            else{
                return false;
            }
        }

        /*


        public bool CheckIfEmpty(List<Order> listOfCust){
            if(listOfCust.Any() == false){
                return true;
            }
            else{
                return false;
            }
            
        } */


        ////////////

        public string ConvertSFIdToSFAddress(int sId){
            return _repo.StoreFrontIdToAddress(sId);
        }
        ///////
        public Inventory GetSpecificInventory(int id){
            Inventory specInventory = _repo.GetAnInventory(id);
            return specInventory;
        }

        public void printProductsInInventory(Inventory inv){
            for(int i = 0; i < inv.Products.Count; i++) {
                Console.WriteLine(inv.Products[i].prodId + " " + inv.Products[i].Name + ": " + inv.quantity[i]);
            }
        }
        public void printProductsInInventory(Inventory inv, Order ord){
            List<int> filler = new List<int>{};
            for(int i = 0; i < inv.Products.Count; i++){
                bool created = false;
                for(int j = 0; j < ord.LineItems.Count; j++){
                    
                    if(ord.LineItems[j].Products.prodId == inv.Products[i].prodId){
                        if(created == false){
                            filler.Add(ord.LineItems[j].Quantity);
                            created = true;
                        }
                        else
                        {
                            
                            filler[i] += ord.LineItems[j].Quantity;
                        }
                    }
                }
            }

            for(int i = 0; i < inv.Products.Count; i++) {
                Console.WriteLine(inv.Products[i].prodId + " " + inv.Products[i].Name + ": " + inv.quantity[i] + " - " + filler[i]);
            }
        }
    } 
}