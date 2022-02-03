namespace ShopModel;
public class Order{
    
    List<LineItem> LineItems { get; set; }
    List<StoreFront> StoreFrontLocation {get; set;}

    public Order(){
        LineItems = new List<LineItem>{};
        StoreFrontLocation = new List<StoreFront>{};
    }
    
    public override string ToString(){
        return $"????????????";
    }
}