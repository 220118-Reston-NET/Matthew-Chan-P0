namespace ShopModel;
public class LineItem{
    
    public List<Product> Products { get; set; }
    public int Quantity { get; set; }
    
    public LineItem(){
        Products = new List<Product>{};
        Quantity = 1;
    }
    
    public override string ToString(){
        string productString = string.Join( "\n", Products);
        return $"Product Name: {productString}\nQuantity: {Quantity}";
    }
}