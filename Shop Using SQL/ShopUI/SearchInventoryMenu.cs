
using ShopBL;
using ShopModel;

namespace ShopUI
{
    public class SearchInventoryMenu : IMenu
    {
        private IStoreFrontBL _storeBL;
        public SearchInventoryMenu(IStoreFrontBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }

        public void Display()
        {
            Console.WriteLine("Please select the shop(by name)");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            List<StoreFront> listOfStoreFromName = _storeBL.SearchStoreFrontName(userInput);
                    
            if(_storeBL.CheckIfEmpty(listOfStoreFromName) == true){
                Console.WriteLine("We could not find a store from that name. Please try another method");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "SearchStoreFront";
            }

            
            Console.WriteLine("The store " + listOfStoreFromName[0].Name + " was found.");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();

            Inventory storeInventory = _storeBL.GetSpecificInventory(listOfStoreFromName[0].storeId);

            _storeBL.printProductsInInventory(storeInventory);            
            
            Console.WriteLine("Done");
            Console.ReadLine();
            
            
            return "MainMenu";
            
        }
    }
}

