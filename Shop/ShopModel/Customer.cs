namespace CustomerModel;
public class Customer{

    public string _name;
    public int _age;
    public string _address;
    public string _email;
    public string _phoneNumber;
    //private static int _CurrentUniqueCustomerID;
    private List<Order> _orders;

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

    
    public Customer(){
        Name = "John Smith";
        Age = 33;
        Address = "Utopia";
        Email = "John.Smith@gmail.com";
        PhoneNumber = 123-456-7890;
    }
    
}