namespace ShopModel;
public class StoreFront{
    
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Product> Products { get; set; }
    public List<Order> Orders {get; set;}

    // need some kind of unique store ID
    
    public StoreFront(){
        Name = "N/A";
        Address = "9001 Utopia Circle";
        Products = new List<Product>{};
        Orders = new List<Order>{};
        
    }
    public override string ToString(){
        string productString = string.Join( "\n", Products);
        string OrderString = string.Join( ",", Orders);
        return $"Name: {Name}\nPrice: {Address}\nProducts: {productString}\nOrders: {OrderString}";
    }
}