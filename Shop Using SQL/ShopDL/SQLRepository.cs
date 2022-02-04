using System.Data.SqlClient;
using ShopModel;

namespace ShopDL
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        //SQLRepository now requires you to provide a connectionstring to an existing database to create an object out of it
        //It will also allow SQLRepository to dynamically point to different databases as long as you have the connection string fo rit
        private readonly string _connectionStrings;
        public SQLCustomerRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        public Customer AddCustomer(Customer c_cust)
        {
            //@ before the string will ignore special characters like \n
            //This is where you specify the sql statement required to do whatever operation you need based on the method
            //
            string sqlQuery = @"insert into Customer 
                            values(@custId, @custName, @custAge, @custAddress, @custEmail,@custPhoneNumber)";

            //using block is different from our normal using statement
            //It is used to automatically close any resource you stated inside of the parenthesis
            //If an exception occurs, it will still automatically close any resources
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens the connection to the database
                con.Open();

                //SqlCommand class is a class specialized in executing SQL statements
                //Command will how the sqlQuery that will execute on the currently connection we have in the con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@custId", c_cust.custId);
                command.Parameters.AddWithValue("@custName", c_cust.Name);
                command.Parameters.AddWithValue("@custAge", c_cust.Age);
                command.Parameters.AddWithValue("@custAddress", c_cust.Address);
                command.Parameters.AddWithValue("@custEmail", c_cust.Email);
                command.Parameters.AddWithValue("@custPhoneNumber", c_cust.PhoneNumber);

                //Executes the SQL statement
                command.ExecuteNonQuery();
            }

            return c_cust;
        }


        /*
        public List<Customer> GetCustomerById(int c_custId)
        {
            List<Customer> listOfCustomer = new List<Customer>();
            
            string sqlQuery = @"select * from Customer";
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@pokeId", c_custId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCustomer.Add(new Customer(){
                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        custId = reader.GetInt32(0),
                        Name = reader.GetString(1), //it will get the pokeName column since it is the second column of our select statement
                        Age = reader.GetInt32(2),
                        Address = reader.GetString(3),
                        Email = reader.GetString(4),
                        PhoneNumber = reader.GetString(5)

                    });
                }
            }
            return listOfCustomer;
        }
*/

        public List<Customer> GetAllCustomer()
        {
            List<Customer> listOfCustomer = new List<Customer>();

            string sqlQuery = @"select * from Customer";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();

                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);

                //SqlDataReader is a class specialized in reading outputs that came from a sql statement
                //Usually this outputs are in a form of a table and keep that in mind
                SqlDataReader reader = command.ExecuteReader();

                //Read() methods checks if you have more rows to go through
                //If there is another row = true, if not = false
                while (reader.Read())
                {
                    listOfCustomer.Add(new Customer(){
                        //Zero-based column index
                        custId = reader.GetInt32(0),
                        Name = reader.GetString(1), 
                        Age = reader.GetInt32(2),
                        Address = reader.GetString(3),
                        Email = reader.GetString(4),
                        PhoneNumber = reader.GetString(5)
                    });
                }
            }

            return listOfCustomer;
        }
    }
}