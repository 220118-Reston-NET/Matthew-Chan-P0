namespace CustomerModel;
public class Customer{

    private string _name;
    private int _age;
    private string _age;
    private string _address;
    private string _email;
    private string _PhoneNumber;
    private static int _CurrentUniqueCustomerID;
    public string Name { 
        get{
            return Name;
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
            if(string.IsNullOrEmpty(value))
        }
        }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }


    
}