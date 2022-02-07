namespace ShopModel;
public class Order{
    public int orderNumber { get; set; }
    List<LineItem> LineItems { get; set; }
    List<StoreFront> StoreFrontLocation {get; set;}
    List<int> totalPrice { get; set; }
    public Order(){
        LineItems = new List<LineItem>{};
        StoreFrontLocation = new List<StoreFront>{};
        totalPrice = new List<int>{};
    }
    
    public override string ToString(){
        string lineItemString = string.Join( "\n", LineItems);
        string storeFrontLocationString = string.Join( "\n", StoreFrontLocation);
        //string totalPrice = string.Join( "\n", totalPrice);
        return $"Line Items: {lineItemString}\nStore Front Locations: {storeFrontLocationString}\nTotal Price: ";
    }
}