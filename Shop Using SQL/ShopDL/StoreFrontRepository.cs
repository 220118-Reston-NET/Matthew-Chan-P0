/*
using System.Text.Json;
using ShopModel;

namespace ShopDL{
    public class StoreFrontRepository : IStoreFrontRepository{
        //Relative filepath is from the PokeUI isnce that is the starting point of our application
        private string _filepath = "../ShopDL/Database/"; // cause our main method is in pokeUI
        private string _jsonString;

        public StoreFront AddStoreFront(StoreFront s_store)
        {
            //So we can change which JSOn files we can pick on other methods
            string path = _filepath + "StoreFront.json";

            List<StoreFront> listOfStoreFront = GetAllStoreFront();
            
            //going to need to figure out a way to make customer unique id

            listOfStoreFront.Add(s_store);

            _jsonString = JsonSerializer.Serialize(listOfStoreFront, new JsonSerializerOptions {WriteIndented = true});

            Console.WriteLine(_jsonString);
            Console.ReadLine();
            File.WriteAllText(path , _jsonString);
            
            return s_store;
        }

        
        
        public List<StoreFront> GetAllStoreFront(){
            _jsonString = File.ReadAllText(_filepath + "StoreFront.json");
            return JsonSerializer.Deserialize<List<StoreFront>>(_jsonString);
        }
    }
}
*/