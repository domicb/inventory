using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string status;
        private Boolean isConnect = false;
        List<Product> listProducts;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        public void Initialize()
        {
            server = "localhost";
            database = "mydb";
            uid = "root";
            password = "GambaBlanca80";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public string getStatus()
        {
            status = connection.State.ToString();
            return status;
        }

        //open connection to database
        public bool OpenConnection()
         {
            try
            {
                status = getStatus();
                if(status == "Open")
                {
                    isConnect = true;
                    return isConnect;
                }
                else
                {
                    connection.Open();

                    isConnect = true;
                    return isConnect;
                }         

            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                isConnect = false;
                return isConnect;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public string idProduct(string name)
        {
            //TODO
            //NECESITAMOS LA ID DEL PADRE PARA REALIZAR EL INSERT ES OBLIGATORIO
            string query = "SELECT idproduct FROM `product` WHERE `name` LIKE '%" + name + "%'";
            return  "";
        }

        //Insert statement
        public int Insert(Product product, string padre)
        {
            //TODO
            //INFORMAR DE LA INSERCION Y DESARROLLAR INSERT IN TO SUBPRODUCT
            string name = product.getName();
            string size = product.getSize();
            string quantity = product.getQuantity();
            string kg = product.getKg();
            string price = product.getPrice();
            string query = "";
            DateTime dateOut = DateTime.Now;
            DateTime dateIn = DateTime.Now;
            if (padre != "")
            {
                query = "INSERT INTO `subproduct`(`name`,`size`,`product_idproduct`,`quantity`,`dateIn`,`dateOut`,`kg`,`price`)VALUES(@name, @size, @idproduct, @quantity, @dateIn, @dateOut, @kg , @price );";
            }
            else
            {
                query = "INSERT INTO `product`(`name`,`size`,`quantity`,`dateIn`,`dateOut`,`kg`,`price`)VALUES(@name, @size, @quantity, @dateIn, @dateOut, @kg , @price );";
            }
            
            if (this.OpenConnection() == true)
            {
                try
                {

                    //Create Command
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@size", MySqlDbType.VarChar).Value = size;
                        cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = quantity;
                        cmd.Parameters.Add("@dateIn", MySqlDbType.DateTime).Value = dateIn;
                        cmd.Parameters.Add("@dateOut", MySqlDbType.DateTime).Value = dateOut;
                        cmd.Parameters.Add("@kg", MySqlDbType.VarChar).Value = kg;
                        cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = price;
                        return cmd.ExecuteNonQuery();                      
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                    return -1;
                }

            }
            else
            {
                return -1;
            }
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        public List<Product> SelectSubProduct(string product = "pedro")
        {
           string query = "SELECT * FROM `subproduct` WHERE `name` LIKE '%" + product + "%'";
            //Create a list to store the result
            listProducts = new List<Product>();

            //Open connection
            if (this.OpenConnection() == true)
            {

                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    
                    Product producto = new Product(dataReader["name"].ToString(), dataReader["size"].ToString(), dataReader["kg"].ToString(), dataReader["quantity"].ToString(), dataReader["price"].ToString(),dataReader["dateIn"].ToString());
                    listProducts.Add(producto);
                }
                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return listProducts;
            }
            else
            {
                return listProducts;
            }
        }

        //Select statement
        public List<Product> SelectProduct()
        {

            string query = "SELECT * FROM product ";                  

            //Create a list to store the result
            List<Product> list = new List<Product>();


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list      
                while (dataReader.Read())
                {
                    Product producto = new Product(dataReader["name"].ToString(), dataReader["size"].ToString(), dataReader["kg"].ToString(), dataReader["quantity"].ToString(), dataReader["price"].ToString(), dataReader["dateIn"].ToString());
                    list.Add(producto);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Select statement
        public List<string>[] SelectClient()
        {
            string query = "SELECT * FROM client";

            //Create a list to store the result
            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["idclient"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["tlf"] + "");
                    list[3].Add(dataReader["email"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        /*//Count statement
        public int Count()
        {
        }*/

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }
}
