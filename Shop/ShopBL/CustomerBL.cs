using ShopModel;

namespece ShopBL{
    public class ShopBL: IShopBL{

        // ==================================
        private IRepsoitory _repo;

        public ShopBL(IRepository p_rep){
            _repo = p_repo;
        }
        // ==================================

        public Shop AddCustomers(Shop p_){
            Random rand = new Random();

            //It will either subtract or add a range from -5 to 5
            //p_poke.Attack += rand.Next(-5,5);

            List<Customer> listOfCustomers - _repo.GetAllShop();
        }
    }
}