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
        public static long lastId;

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

        public string idTipo(string name)
        {
            string query = "SELECT idtipoProducto FROM tipoproducto WHERE `tipo` LIKE '%" + name + "%' limit 1";
            string idProduct = "0";
            if (this.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list      
                    while (dataReader.Read())
                    {
                        idProduct = dataReader[0].ToString();
                    }
                    this.CloseConnection();
                    return idProduct;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                    return "error " + ex.Message;
                }
            }
            else
            {
                return "error 44, al recuperar id producto";
            }
        }

        public string idProduct(string name)
        {      
            string query = "SELECT idproduct FROM `product` WHERE `name` LIKE '%" + name + "%' limit 1";
            string idProduct = "0";
            if (this.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list      
                    while (dataReader.Read())
                    {
                       idProduct = dataReader[0].ToString();
                    }
                    this.CloseConnection();
                    return idProduct;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                    return "error "+ ex.Message;
                }
            }
            else
            {
                return "error 44, al recuperar id producto";
            }
        }

        
        public void InsertEntrada(string name, string email, string tlf,string dni, string direccion)
        {
            //dateIn = Convert.ToDateTime(dateIn).ToString("dd/MM/yyyy");
            string query = "INSERT INTO `client`(`name`,`tlf`,`email`,`dni`,`direccion`)VALUES(@name, @tlf, @email, @dni, @direccion );";
            if (this.OpenConnection() == true)
            {                 
                    try
                    {
                        //Create Command
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                            cmd.Parameters.Add("@tlf", MySqlDbType.VarChar).Value = tlf;
                            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                            cmd.Parameters.Add("@dni", MySqlDbType.VarChar).Value = dni;
                            cmd.Parameters.Add("@direccion", MySqlDbType.VarChar).Value = direccion;
                            cmd.ExecuteNonQuery();
                            lastId = cmd.LastInsertedId;
                            MessageBox.Show("Cliente registrado con id: " + lastId + "");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error" + ex.Message);
                    }         
            }
            else
            {
                MessageBox.Show("No hay conexión");
            }           
        }

        //Insert statement
        public void Insert(Product product, int idTipo)
        {
            //TODO
            //Necesitamos insertar primero el registro idLAST
            string name = product.getName();
            string size = product.getSize();
            string quantity = product.getQuantity();
            string kg = product.getKg();
            string price = product.getPrice();
            string info = product.getInfo();
            string lote = product.getLote();           
            //string idProduct = this.idProduct(padre);           
            DateTime dateOut = DateTime.Now;
            DateTime dateIn = DateTime.Now;
            string fecha = dateIn.ToString();
            //registramos la entrada obteniendo el id para asignar y relacionar el producto a la entrada
            long id = lastId;
            string idProduct = id.ToString();

            string query = "INSERT INTO `subproduct`(`name`,`size`,`product_idproduct`,`quantity`,`dateIn`,`dateOut`,`kg`,`price`,`info`,`lote`, `tipoproducto_idtipoproducto`)VALUES(@name, @size, @product_idproduct, @quantity, @dateIn, @dateOut, @kg , @price, @info, @lote, @tipoproducto_idtipoproducto );";
            
            if (this.OpenConnection() == true)
            {
                int contador = Convert.ToInt32(quantity);
                while (contador > 0)
                {
                    contador--;
                    try
                    {
                        //Create Command
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                            cmd.Parameters.Add("@size", MySqlDbType.VarChar).Value = size;
                            cmd.Parameters.Add("@product_idproduct", MySqlDbType.Int32).Value = Int32.Parse(idProduct);
                            cmd.Parameters.Add("@tipoproducto_idtipoproducto", MySqlDbType.Int32).Value = idTipo;
                            cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = quantity;
                            cmd.Parameters.Add("@dateIn", MySqlDbType.DateTime).Value = dateIn;
                            cmd.Parameters.Add("@dateOut", MySqlDbType.DateTime).Value = dateOut;
                            cmd.Parameters.Add("@kg", MySqlDbType.Double).Value = kg;
                            cmd.Parameters.Add("@lote", MySqlDbType.VarChar).Value = lote;
                            cmd.Parameters.Add("@price", MySqlDbType.Double).Value = price;
                            cmd.Parameters.Add("@info", MySqlDbType.VarChar).Value = info;
                            cmd.ExecuteNonQuery();
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error" + ex.Message);                      
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay conexión");
            }
        }

        //Update statement
        public int Update(Product product)
        {
            string name = product.getName();
            string size = product.getSize();
            string quantity = product.getQuantity();
            string kg = product.getKg();
            string price = product.getPrice();
            string idProduct = this.idProduct(name);
            string query = "";
            
            query = "UPDATE `mydb`.`subproduct`SET `name` = @name, `size` = @size,`kg` = @kg, `price` = @price WHERE `idproduct` = @idProduct";
            
            if (this.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@size", MySqlDbType.VarChar).Value = size;
                        cmd.Parameters.Add("@kg", MySqlDbType.Double).Value = kg;
                        cmd.Parameters.Add("@price", MySqlDbType.Double).Value = price;
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

        //Delete statement
        public void Delete()
        {
        }

        public List<Product> SelectSubProduct(string product = "pedro")
        {
            //string query = "SELECT * FROM `subproduct` WHERE `name` LIKE '%" + product + "%'";
            string query = "SELECT distinct name,size,kg,quantity,price,info,lote,dateIn,tipoProducto_idtipoProducto FROM `subproduct` order by `name`;";
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
                    string now = dataReader["dateIn"].ToString();
                    DateTime ahora = Convert.ToDateTime(now);
                    Product producto = new Product(dataReader["name"].ToString(), dataReader["size"].ToString(), dataReader["kg"].ToString(), dataReader["quantity"].ToString(), dataReader["price"].ToString(),ahora, dataReader["info"].ToString(), dataReader["lote"].ToString(), dataReader["tipoProducto_idtipoProducto"].ToString());
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
        public List<tipo> SelectTipo()
        {
            string query = "SELECT * FROM tipoProducto ";                  
            //Create a list to store the result
            List<tipo> list = new List<tipo>();
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
                    tipo producto = new tipo(dataReader["tipo"].ToString());
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

        public List<Cliente> SelectCliente()
        {
            string query = "SELECT * FROM client ";
            //Create a list to store the result
            List<Cliente> list = new List<Cliente>();
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
                    Cliente producto = new Cliente(dataReader["name"].ToString(), dataReader["tlf"].ToString(), dataReader["email"].ToString(), dataReader["dni"].ToString(), dataReader["direccion"].ToString());
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
        
        public string Count(int nameProduct)
        {
            //nameProduct = nameProduct.Substring(0, 5); 
            string query = "SELECT COUNT(*) FROM `subproduct` WHERE `tipoProducto_idtipoProducto` = " + nameProduct + "";
            string cuantos = "0";
            if (this.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list      
                    while (dataReader.Read())
                    {
                        cuantos = dataReader[0].ToString();
                    }
                    this.CloseConnection();
                    return cuantos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                    return "error " + ex.Message;
                }

            }
            else
            {
                return "error 44, al recuperar la cantidad de productos";
            }
        }

        public void InsertCount(int nameProduct)
        {
            //TODO
            //la id es mejor forma de actualizar un producto 
            //dado que por el nombre like encontramos errores sql
            //CORREGIR ID HUEVA CHOCO
            //nameProduct = nameProduct.Substring(0, 4);

            //string id = this.idProduct(nameProduct);
            string cuantos = this.Count(nameProduct);//devolver id del producto ya tenemos la función creada
            string query = "UPDATE `subproduct` SET `quantity` = @quantity WHERE `tipoProducto_idtipoProducto` = @idproduct";
            if (this.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {               
                        cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = cuantos;
                        cmd.Parameters.Add("@idproduct", MySqlDbType.Int32).Value = nameProduct;
                        cmd.ExecuteNonQuery();
                        this.CloseConnection();
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);                  
                }
            }
        }
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
