
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
        
        public List<StoreFront> SearchStoreFrontName(string s_name){
            List<StoreFront> listOfStoreFronts = _repo.GetAllStoreFront();
            // LINQ library
            return listOfStoreFronts
                        .Where(store => store.Name.Contains(s_name))
                        .ToList();
        }
        /*
        public void SearchStoreFrontProducts(string s_product){
            List<StoreFront> listOfStoreFronts = _repo.GetAllStoreFront();
            // LINQ library
                
            
            return listOfStoreFronts
                        .Where(store => store.Products.Contains(s_product))
                        .ToList()); 
        }*/
        
        public bool CheckIfEmpty(List<StoreFront> listOfStores){
            if(listOfStores.Any() == false){
                return true;
            }
            else{
                return false;
            }
        }

        
    }
}
