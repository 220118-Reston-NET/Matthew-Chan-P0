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

    public LineItem(Product p, int q){
        lineItemId = -1;
        Products = p;
        Quantity = q;
    }

    public LineItem(int lId, Product p, int q){
        lineItemId = lId;
        Products = p;
        Quantity = q;
    }
    
    public override string ToString(){
        return $"{Products}\nQuantity: {Quantity}";
    }
}