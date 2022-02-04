namespace ShopModel;
public class LineItem{
    
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    
    public LineItem(){
        ProductName = "Candy Bar";
        Quantity = 1;
    }
    
    public override string ToString(){
        return $"Product Name: {ProductName}\nQuantity: {Quantity}";
    }
}