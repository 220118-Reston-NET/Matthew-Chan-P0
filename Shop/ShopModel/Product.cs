namespace ShopModel;
public class Product{
    
    public string Name { get; set; }
    public int Price { get; set; }
    public string Desc { get; set; }
    public int Age_Restriction { get; set; }
    

    public Product(){
        Name = "Candy Bar";
        Price = 1;
        Desc = "Yummy fot the tummy";
        Age_Restriction = 4;
    }
    
    public Product(string productName, int productPrice){
        Name = productName;
        Price = productPrice;
        Desc = "";
        Age_Restriction = 0;
    }
    public override string ToString(){
        return $"Name: {Name}\nPrice: {Price}\nDescription: {Desc}\nAge Restriction: {Age_Restriction}";
    }
}