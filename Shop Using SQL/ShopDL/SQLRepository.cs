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
                            values(@custName, @custAge, @custAddress, @custEmail,@custPhoneNumber)";

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
                //command.Parameters.AddWithValue("@custId", c_cust.custId);
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
        public List<Order> GetListOfOrders(int c_custId)
        {
            List<Order> listOfOrders = new List<Order>();
            
            string sqlQuery = @"o.orderId, p.prodName, p.prodPrice, p.prodDesc, p.prodAgeRestriction,  li.itemQuantity, sf.storeAddress
                            From Customer c 
                            INNER JOIN Orders o ON c.custId = o.custId 
                            INNER JOIN OrderToLineItem ol ON o.orderId = ol.orderId 
                            INNER JOIN LineItem li on ol.lineItemId = li.lineItemId 
                            INNER JOIN Product p ON p.prodId  = li.prodId  
                            INNER JOIN StoreFront sf ON o.storeId = sf.storeId 
 
                            where c.custId = @custId";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open(); 

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@custId", c_custId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfOrders.Add(new Order(){
                        orderNumber = reader.GetInt32(0),

                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        AbId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        PP = reader.GetInt32(2),
                        Power = reader.GetInt32(3),
                        Accuracy = reader.GetInt32(4)
                    });
                }
            }
            return listOfAbility;
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
    public class SQLStoreFrontRepository : IStoreFrontRepository
    {
        private readonly string _connectionStrings;
        public SQLStoreFrontRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        public StoreFront AddStoreFront(StoreFront s_store)
        {
            //@ before the string will ignore special characters like \n
            //This is where you specify the sql statement required to do whatever operation you need based on the method
            //
            string sqlQuery = @"insert into StoreFront 
                            values(@storeName, @storeAddress)";

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
                command.Parameters.AddWithValue("@storeName", s_store.Name);
                command.Parameters.AddWithValue("@storeAddress", s_store.Address);
 
                //Executes the SQL statement
                command.ExecuteNonQuery();
            }

            return s_store;
        }

        public List<StoreFront> GetAllStoreFront()
        {
            List<StoreFront> listOfStoreFront = new List<StoreFront>();

            string sqlQuery = @"select * from StoreFront";
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
                    listOfStoreFront.Add(new StoreFront(){
                        //Zero-based column index
                        storeId = reader.GetInt32(0),
                        Name = reader.GetString(1), 
                        Address = reader.GetString(2),
                        Inv = GetAnInventory(reader.GetInt32(0))
                    });
                }
            } 

            return listOfStoreFront;
            
        }



        public List<Inventory> GetAllInventory()
        {
            List<Inventory> listOfInventory = new List<Inventory>();

            string sqlQuery = @"select * from Inventory 
                                Inner Join Product p ON i.prodId = p.prodId";
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
                    listOfInventory.Add(new Inventory(
                        new List<Product>{new Product(reader.GetInt32(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), reader.GetInt32(8))},
                        new List<int>{reader.GetInt32(2)},
                        reader.GetInt32(3))); 
                }
                /*
                int sId = -1;
                List<Product> productList = new List<Product>{};
                List<int> productQuantity = new List<Product>{};

                int prodQuantity

                while (reader.Read())
                {
                    if(sId != -1 && sId != reader.GetInt32(3)){
                        listOfInventory.Add(new Inventory(productList,productQuantity,sId))
                        productList.Clear();
                        productQuantity.Clear();
                    }
                    productList.Add(new Product(reader.GetInt32(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), reader.GetInt32(8)));
                    productQuantity.Add(reader.GetInt32(2));
                    sId = reader.GetInt32(3);
                }
                // should work, but haven't tested it out
                */
            } 

            return listOfInventory;
        }

        public Inventory GetAnInventory(int s_storeId)
        {
            Inventory inven = new Inventory();

            string sqlQuery = @"select * from Inventory i
                                Inner Join Product p ON i.prodId = p.prodId
                                where i.storeId = @storeId"; 
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();
                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeId", s_storeId);
                //SqlDataReader is a class specialized in reading outputs that came from a sql statement
                //Usually this outputs are in a form of a table and keep that in mind
                SqlDataReader reader = command.ExecuteReader();
                //Read() methods checks if you have more rows to go through
                //If there is another row = true, if not = false
                
                int sId = 0;
                List<Product> productList = new List<Product>{};
                List<int> productQuantity = new List<int>{};

                while (reader.Read())
                {
                    productList.Add(new Product(reader.GetInt32(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), reader.GetInt32(8)));
                    productQuantity.Add(reader.GetInt32(2));
                    sId = reader.GetInt32(3);
                }
                inven = new Inventory(productList,productQuantity, sId);
            } 

            return inven;
        }

        public Inventory RestockInventory(int p_prodId, int s_storeId, int amount)
        {
            string sqlQuery = @"select prodQuantitiy from Inventory
            WHERE inventory.storeId = @s_sId
            AND inventory.prodId = @p_ProdId";

            int currentInv = 0;
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@s_sId", s_storeId);
                command.Parameters.AddWithValue("@p_ProdId", p_prodId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    currentInv = reader.GetInt32(0); 
                }
                
            } 



            sqlQuery = @"UPDATE Inventory
            SET prodQuantitiy = @amnt + @currentInv
            WHERE inventory.storeId = @s_sId
            AND inventory.prodId = @p_ProdId"; 
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();
                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@amnt", amount);
                command.Parameters.AddWithValue("@s_sId", s_storeId);
                command.Parameters.AddWithValue("@p_ProdId", p_prodId);
                command.Parameters.AddWithValue("@currentInv", currentInv);
                //SqlDataReader is a class specialized in reading outputs that came from a sql statement
                //Usually this outputs are in a form of a table and keep that in mind
                SqlDataReader reader = command.ExecuteReader();
                //Read() methods checks if you have more rows to go through
                //If there is another row = true, if not = false
                
            } 
            Inventory inven = GetAnInventory(s_storeId);
            return inven;
        }

        public Inventory AddItemToInventory(int p_prodId, int s_storeId, int amount)
        {
            string sqlQuery = @"insert into inventory 
                            values(@prodId, @prodQuantity, @storeId)";

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
                //command.Parameters.AddWithValue("@custId", c_cust.custId);
                command.Parameters.AddWithValue("@prodId", p_prodId);
                command.Parameters.AddWithValue("@prodQuantity", amount);
                command.Parameters.AddWithValue("@storeId", s_storeId);

                //Executes the SQL statement
                command.ExecuteNonQuery();
            }






            Inventory inven = new Inventory();
            int IId;
            sqlQuery = @"SELECT i.inventoryId  FROM Inventory i 
                        ORDER BY i.inventoryId  DESC 
                        OFFSET 0 ROWS FETCH FIRST 1 ROW ONLY";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                
                
                while (reader.Read())
                {
                    IId = reader.GetInt32(0);
                }
            } 

            return GetAnInventory(s_storeId);


        }

        public List<Product> GetAllProducts(){
            List<Product> listOfProducts = new List<Product>();

            string sqlQuery = @"select * from Product";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listOfProducts.Add(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4))); 
                }   
            }
            return listOfProducts;
        }

    }
    
    
    public class SQLOrderRepository : IOrderRepository 
    {
        private readonly string _connectionStrings;
        public SQLOrderRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }


        /* 
        string sqlQuery = @"insert into Product";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {   
                //Opens the connection to the database
                con.Open();

                //SqlCommand class is a class specialized in executing SQL statements
                //Command will how the sqlQuery that will execute on the currently connection we have in the con object
                for(int i = 0; i < o_order.listOfOrders.Count; i++){

                    //should probably add somethign to check if product is already in product table
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    command.Parameters.AddWithValue("@prodName", o_order.lineItems[i].Products.Name);
                    command.Parameters.AddWithValue("@prodPrice", o_order.lineItems[i].Products.Price);
                    command.Parameters.AddWithValue("@prodDesc", o_order.lineItems[i].Products.Desc);
                    command.Parameters.AddWithValue("@prodAgeRestriction", o_order.lineItems[i].Products.Age_Restriction);
                }

                //Executes the SQL statement
                command.ExecuteNonQuery();
            }
        */    

        public Order AddOrder(Order o_order, int custId, int storeId)
        { 
            List<Order> OrderList = new List<Order>{};
            string sqlQuery = @"insert into LineItem
                            values(@prodId, @itemQuantity)";
            int numberOfItems = o_order.LineItems.Count;

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);

                for(int i = 0; i < numberOfItems; i++){
                    
                    command.Parameters.AddWithValue("@prodId", o_order.LineItems[i].Products.prodId); //??????????????????
                    command.Parameters.AddWithValue("@itemQuantity", o_order.LineItems[i].Quantity);
                }

                command.ExecuteNonQuery();
            }



            List<int> IId = new List<int>{};
            sqlQuery = @"SELECT top(@numOfOrders) * FROM LineItem li
                    ORDER BY li.lineItemid DESC";
            //probably need a way to read the line items to get the lineitemid
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@numOfOrders", numberOfItems);

                SqlDataReader reader = command.ExecuteReader();
                
                
                while (reader.Read())
                {
                    IId.Add(reader.GetInt32(0));
                }
            }
            
            
            
            
            sqlQuery = @"insert into Orders
                    values(@custId, @storeId)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);

                for(int i = 0; i < numberOfItems; i++){
                    
                    command.Parameters.AddWithValue("@custId", custId);
                    command.Parameters.AddWithValue("@storeId", storeId);
                }

                command.ExecuteNonQuery();
            }

            
            List<int> oId = new List<int>{};
            sqlQuery = @"SELECT top(@numOfOrders) * FROM Orders o ORDER BY o.orderId DESC";
            //probably need a way to read the line items to get the lineitemid
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@numOfOrders", numberOfItems);

                SqlDataReader reader = command.ExecuteReader();
                
                
                while (reader.Read())
                {
                    oId.Add(reader.GetInt32(0));
                }
            }




            
            sqlQuery = @"insert into OrderToLineItem
                    values(@orderId, @lineItemId)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                for(int i = 0; i < numberOfItems; i++){
                    command.Parameters.AddWithValue("@orderId", oId[numberOfItems - i - 1]);
                    command.Parameters.AddWithValue("@lineItemId", IId[numberOfItems - i - 1]);
                }

                command.ExecuteNonQuery();
            }
            
            return o_order;
        } 




  
        public List<Order> GetAllOrder()    
        {   
            List<Order> listOfOrder = new List<Order>();    

            string sqlQuery = @"SELECT o.orderId, li.lineItemId, p.prodId, p.prodName, p.prodPrice, p.prodDesc, p.prodAgeRestriction,  li.itemQuantity, sf.storeAddress
                            FROM Customer c     
                            INNER JOIN Orders o ON c.custId = o.custId 
                            INNER JOIN OrderToLineItem ol ON o.orderId = ol.orderId 
                            INNER JOIN LineItem li on ol.lineItemId = li.lineItemId 
                            INNER JOIN Product p ON p.prodId  = li.prodId  
                            INNER JOIN StoreFront sf ON o.storeId = sf.storeId";
//                            where c.custId = @custId";
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

                int oId = -1;
                List<LineItem> listOfLineItems = new List<LineItem>();
                List<string> listOfStoreFrontLocation = new List<string>();
                int tPrice = 0;

                while (reader.Read())
                {
                    if(oId != -1 && oId != reader.GetInt32(0)){
                        listOfOrder.Add(
                            new Order(
                            oId,
                            listOfLineItems,
                            listOfStoreFrontLocation,
                            tPrice
                        ));
                        listOfLineItems.Clear();
                        listOfStoreFrontLocation.Clear();
                        tPrice = 0;
                    }
                    oId = reader.GetInt32(0);
                    listOfLineItems.Add(
                        new LineItem(
                            reader.GetInt32(1),
                            new Product(
                                reader.GetInt32(2),
                                reader.GetString(3),
                                reader.GetInt32(4),
                                reader.GetString(5),
                                reader.GetInt32(6)
                            ),
                            reader.GetInt32(7)
                        )
                    );
                    listOfStoreFrontLocation.Add(reader.GetString(8));
                    tPrice += reader.GetInt32(4);
                }
            } 

            return listOfOrder;
        }

        public List<Order> GetACustomerOrder( int cId)    
        {   
            List<Order> listOfOrder = new List<Order>();    

            string sqlQuery = @"SELECT o.orderId, li.lineItemId, p.prodId, p.prodName, p.prodPrice, p.prodDesc, p.prodAgeRestriction,  li.itemQuantity, sf.storeAddress
                            FROM Customer c     
                            INNER JOIN Orders o ON c.custId = o.custId 
                            INNER JOIN OrderToLineItem ol ON o.orderId = ol.orderId 
                            INNER JOIN LineItem li on ol.lineItemId = li.lineItemId 
                            INNER JOIN Product p ON p.prodId  = li.prodId  
                            INNER JOIN StoreFront sf ON o.storeId = sf.storeId
                            where c.custId = @custId";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();
                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@custId", cId);
                //SqlDataReader is a class specialized in reading outputs that came from a sql statement
                //Usually this outputs are in a form of a table and keep that in mind
                SqlDataReader reader = command.ExecuteReader();
                //Read() methods checks if you have more rows to go through
                //If there is another row = true, if not = false

                int oId = -1;
                List<LineItem> listOfLineItems = new List<LineItem>();
                List<string> listOfStoreFrontLocation = new List<string>();
                int tPrice = 0;

                while (reader.Read())
                {
                    oId = reader.GetInt32(0);
                    listOfLineItems.Add(
                        new LineItem(
                            reader.GetInt32(1),
                            new Product(
                                reader.GetInt32(2),
                                reader.GetString(3),
                                reader.GetInt32(4),
                                reader.GetString(5),
                                reader.GetInt32(6)
                            ),
                            reader.GetInt32(7)
                        )
                    );
                    listOfStoreFrontLocation.Add(reader.GetString(8));
                    tPrice += reader.GetInt32(4);

                    listOfOrder.Add(
                        new Order(
                        oId,
                        listOfLineItems,
                        listOfStoreFrontLocation,
                        tPrice
                    ));
                    
                    
                }
            } 

            return listOfOrder;
        }


        public List<Order> GetAShopOrder( int sId)    
        {   
            List<Order> listOfOrder = new List<Order>();    

            string sqlQuery = @"SELECT o.orderId, li.lineItemId, p.prodId, p.prodName, p.prodPrice, p.prodDesc, p.prodAgeRestriction,  li.itemQuantity, sf.storeAddress
                            FROM Customer c     
                            INNER JOIN Orders o ON c.custId = o.custId 
                            INNER JOIN OrderToLineItem ol ON o.orderId = ol.orderId 
                            INNER JOIN LineItem li on ol.lineItemId = li.lineItemId 
                            INNER JOIN Product p ON p.prodId  = li.prodId  
                            INNER JOIN StoreFront sf ON o.storeId = sf.storeId
                            where c.custId = @shopId";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();
                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@shopId", sId);
                //SqlDataReader is a class specialized in reading outputs that came from a sql statement
                //Usually this outputs are in a form of a table and keep that in mind
                SqlDataReader reader = command.ExecuteReader();
                //Read() methods checks if you have more rows to go through
                //If there is another row = true, if not = false

                int shopId = -1;
                List<LineItem> listOfLineItems = new List<LineItem>();
                List<string> listOfStoreFrontLocation = new List<string>();
                int tPrice = 0;

                while (reader.Read())
                {
                    shopId = reader.GetInt32(0);
                    listOfLineItems.Add(
                        new LineItem(
                            reader.GetInt32(1),
                            new Product(
                                reader.GetInt32(2),
                                reader.GetString(3),
                                reader.GetInt32(4),
                                reader.GetString(5),
                                reader.GetInt32(6)
                            ),
                            reader.GetInt32(7)
                        )
                    );
                    listOfStoreFrontLocation.Add(reader.GetString(8));
                    tPrice += reader.GetInt32(4);

                    listOfOrder.Add(
                        new Order(
                        shopId,
                        listOfLineItems,
                        listOfStoreFrontLocation,
                        tPrice
                    ));
                    
                    
                }
            } 

            return listOfOrder;
        }

        public Product ProductIdToProduct(int prodId){
            string sqlQuery = @"select * from Product p
                            WHERE p.prodId = @productId";
            Product prod = new Product();
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productId", prodId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    prod = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4)); 
                }   
            }
            return prod;
        }



    } 
        
    public class SQLProductRepository : IProductRepository {
        private readonly string _connectionStrings;
        public SQLProductRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        public Product AddProduct(Product p_product)
        {
            //@ before the string will ignore special characters like \n
            //This is where you specify the sql statement required to do whatever operation you need based on the method
            //
            string sqlQuery = @"insert into product 
                            values(@prodName, @prodPrice, @prodDesc, @prodAgeRestriction)";

            //using block is different from our normal using statement
            //It is used to automatically close any resource you stated inside of the parenthesis
            //If an exception occurs, it will still automatically close any resources
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens the connection to the database
                con.Open();


                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@prodName", p_product.Name);
                command.Parameters.AddWithValue("@prodPrice", p_product.Price);
                command.Parameters.AddWithValue("@prodDesc", p_product.Desc);
                command.Parameters.AddWithValue("@prodAgeRestriction", p_product.Age_Restriction);
 
                //Executes the SQL statement
                command.ExecuteNonQuery();
            }

            // possibly adjust product id to match autogenerated id???

            return p_product;
        }

        public List<Product> GetAllProducts(){
            List<Product> listOfProducts = new List<Product>();

            string sqlQuery = @"select * from Inventory 
                                Inner Join Product p ON i.prodId = p.prodId";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listOfProducts.Add(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4))); 
                }   
            }
            return listOfProducts;
        }

        public Product ProductIdToProduct(int prodId){
            string sqlQuery = @"select * from Product p
                            WHERE p.prodId = @productId";
            Product prod = new Product();
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productId", prodId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    prod = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4)); 
                }   
            }
            return prod;
        }

    } 

}
