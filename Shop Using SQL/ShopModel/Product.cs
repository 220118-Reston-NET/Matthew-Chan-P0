namespace ShopModel;
public class Product{
    
    public int prodId {get; set; }
    public string Name { get; set; }
    public int Price { 
        get{return Price;} 
        set{
            if(value > 0){
                Price = value;
            }
            else{
                throw new Exception("The price cannot be lower than 0!");
            }
        } 
    }
    public string Desc { get; set; }
    public int Age_Restriction { 
        get{return Age_Restriction;} 
        set{
            if(value > 0){
                Age_Restriction = value;
            }
            else{
                throw new Exception("The Age Restriction cannot be lower than 0!");
            }
        }
    }

    public Product(){
        prodId = -1;
        Name = "Nothing";
        Price = 0;
        Desc = "DNE";
        Age_Restriction = 0;
    }
    
    public Product(string productName, int productPrice){
        prodId = -1;
        Name = productName;
        Price = productPrice;
        Desc = "";
        Age_Restriction = 0;
    }
    public Product(int productId, string productName, int productPrice, string productDescription, int productAgeRestriction){
        prodId = productId;
        Name = productName;
        Price = productPrice;
        Desc = productDescription;
        Age_Restriction = productAgeRestriction;
    }
    public override string ToString(){
        return $"Product Name: {Name}\nPrice: {Price}\nDescription: {Desc}\nAge Restriction: {Age_Restriction}";
    }
}