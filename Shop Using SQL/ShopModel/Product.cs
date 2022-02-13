namespace ShopModel;
public class Product{
    
    public int prodId {get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Desc { get; set; }
    public int Age_Restriction { get; set; }
    

    public Product(){
        prodId = 0;
        Name = "Candy Bar";
        Price = 1;
        Desc = "Yummy fot the tummy";
        Age_Restriction = 4;
    }
    
    public Product(string productName, int productPrice){
        prodId = 0;
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