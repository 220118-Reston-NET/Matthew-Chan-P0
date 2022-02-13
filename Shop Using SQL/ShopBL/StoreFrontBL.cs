
using ShopDL;
using ShopModel;


namespace ShopBL{
    public class StoreFrontBL: IStoreFrontBL {
        // Dependency Injection Pattern
        // ==================================
        private IStoreFrontRepository _repo;
        
        public StoreFrontBL(IStoreFrontRepository s_repo){
            _repo = s_repo;
        }

        
        // ==================================

        public StoreFront AddStoreFront(StoreFront c_StoreFront){
            Random rand = new Random();

            //c_StoreFront.uniqueID == rand.Next(0,9999999); will determine a way to actually make it unique later, or should just do some kind of incrmeent with a static variable would work too

            return _repo.AddStoreFront(c_StoreFront);
        }

        public List<StoreFront> GetAllStoreFronts(){
            return _repo.GetAllStoreFront();
        }

        public List<Product> GetAllProducts(){
            return _repo.GetAllProducts();
        }


        
        public List<StoreFront> SearchStoreFrontName(string s_name){
            List<StoreFront> listOfStoreFronts = _repo.GetAllStoreFront();
            // LINQ library
            return listOfStoreFronts
                        .Where(store => store.Name.Contains(s_name))
                        .ToList();
        }
        
        public List<StoreFront> SearchStoreFrontProducts(string s_product){
            List<StoreFront> listOfStoreFronts = _repo.GetAllStoreFront();
            // LINQ library

            
            return listOfStoreFronts;
                        //.Where(store => store.Inv.Products.Contains(s_product))
                        //.ToList()); 
        }
        
        public List<StoreFront> checkStoresForAProduct(int pId){
            List<StoreFront> listOfStoreFronts = _repo.GetAllStoreFront();
            List<StoreFront> listOfStoreFrontsWithProduct = new List<StoreFront>{};

            for(int i = 0; i < listOfStoreFronts.Count; i++){
                for(int j = 0; j < listOfStoreFronts[i].Inv.Products.Count; j++){
                    if(listOfStoreFronts[i].Inv.Products[j].prodId == pId){
                        listOfStoreFrontsWithProduct.Add(listOfStoreFronts[i]);
                    }
                }
            }
            return listOfStoreFrontsWithProduct;
        }

        public bool CheckIfEmpty(List<StoreFront> listOfStores){
            if(listOfStores.Any() == false){
                return true;
            }
            else{
                return false;
            }
        }

        public Inventory GetSpecificInventory(int id){
            Inventory specInventory = _repo.GetAnInventory(id);
            return specInventory;
        }

        public void printProductsInInventory(Inventory inv){
            for(int i = 0; i < inv.Products.Count; i++) {
                Console.WriteLine(inv.Products[i].Name + ": " + inv.quantity[i]);
            }
        }
    
        public void RestockInventory(int p_prodId, int s_storeId, int amount){
            // need to check if prod and store and amount are valid
            
            //now update inventory
            _repo.RestockInventory(p_prodId, s_storeId, amount);
        }

        public Inventory AddItemToInventory(int p_prodId, int s_storeId, int amount){
            return _repo.AddItemToInventory(p_prodId, s_storeId, amount);
        }
        /*public List<Product> GetProductsFromShopId (int sId) {
            List<Products> = _
        }*/
        
    }
}
