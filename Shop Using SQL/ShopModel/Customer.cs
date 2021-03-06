namespace ShopModel; 
public class Customer{
    /*
    public string _name;
    public int _age;
    public string _address;
    public string _email;
    public string _phoneNumber;
    //private static int _CurrentUniqueCustomerID;
    /* private List<Order> _orders;

    public List<Order> Order{
        get {return _orders;}
        set {_order = value;} // remember to come back to decide how to do orders
    }

    public string Name { 
        get{
            return _name;
        } 
        set{
            if(string.IsNullOrEmpty(value)){
                throw new Exception("Error, Empty Value is not permissable");
            }
            _name = value;
        } 
    }
    public int Age { 
        get { 
            return _age;
        } 
        set {
            if (value <= 0 ){
                throw new Exception("Error, return vallue cannot be equal to ");
            }
            else{
                _age = value;
            }
        }
    }
    public string Address { 
        get {
            return _address;
        }
        set {
            if(string.IsNullOrEmpty(value)){
                throw new Exception("Error, Empty Value is not permissable");
            }
            _address = value;
        }
    }
    public string Email { 
        get {
            return _email;
        }
        set {
            if(string.IsNullOrEmpty(value)){
                throw new Exception("Error, Empty Value is not permissable");
            }
            _email = value;
        } 
    }
    public string PhoneNumber { 
        get{
            return _phoneNumber;
        } 
        set{
            if(string.IsNullOrEmpty(value)){
                throw new Exception("Error, Empty Value is not permissable");
            }
            _phoneNumber = value;
        } 
    }
    */
    public int custId {get; set;}
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public string Email {get; set; }
    public string PhoneNumber { get; set; }

    public static int idGenerator = 0;
    public Customer(){
        custId = idGenerator;
        idGenerator++;
        Name = "John Smith";
        Age = 33;
        Address = "Utopia";
        Email = "John.Smith@gmail.com";
        PhoneNumber = "123-456-7890";
    }
    public override string ToString(){
        return $"Name: {Name}\nUnique Customer ID: {custId}\nAge: {Age}\nAddress: {Address}\nEmail: {Email}\nPhoneNumber: {PhoneNumber}";
    }
}