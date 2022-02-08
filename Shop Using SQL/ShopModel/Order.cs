namespace ShopModel;
public class Order{
    public int orderNumber { get; set; }
    List<LineItem> LineItems { get; set; }
    List<string> StoreFrontLocation {get; set;}
    int totalPrice { get; set; }
    public Order(){
        orderNumber = 0;
        LineItems = new List<LineItem>{};
        StoreFrontLocation = new List<string>{};
        totalPrice = 0;
    }
    
    public Order(int oId, List<LineItem> lItem, List<string> sfLoc, int tPrice){
        orderNumber = oId;
        LineItems = lItem;
        StoreFrontLocation = sfLoc;
        totalPrice = tPrice;
    }

    public override string ToString(){
        string lineItemString = string.Join( "\n", LineItems);
        string storeFrontLocationString = string.Join( "\n", StoreFrontLocation);
        //string totalPrice = string.Join( "\n", totalPrice);
        return $"Line Items: {lineItemString}\nStore Front Locations: {storeFrontLocationString}\nTotal Price: ";
    }
}

/* Some Pseudocode
instantiate blank Order class
    loop though file
    add a LItem into the lineitem list( /// add p product, then, then add quantitiy)
    increase the total price by quantitiy + price
*/


