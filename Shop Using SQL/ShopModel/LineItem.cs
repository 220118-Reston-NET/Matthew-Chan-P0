namespace ShopModel;
public class LineItem{
    public int lineItemId {get; set; }
    public Product Products { get; set; }
    public int Quantity { get; set; }
    
    public LineItem(){
        lineItemId = 0;
        Products = new Product();
        Quantity = 0;
    }
    
    public override string ToString(){
        return $"Product Name: {Products}\nQuantity: {Quantity}";
    }
}