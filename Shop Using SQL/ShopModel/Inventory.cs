namespace ShopModel;
public class Inventory{
    public int inventoryId {get; set; }
    public List<Product> Products {get; set;}
    Dictionary < Product, int > quantity;


    // need some kind of unique store ID
    
    public Inventory(){
        inventoryId = 0;
        Products = new List<Product>{};
        quantity = new Dictionary<Product, int>();
    }
    public override string ToString(){
        string productString = string.Join( "\n", Products);

        return $"Products: {productString}\n";
    }
}