using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace SnackShack
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //SQL COMMAND DEFINITIONS
        internal static string _connString = "Data Source=nphsvr1;Initial Catalog = gmalone; Integrated Security = True"; //road map
        internal static SqlConnection _connection; //enables connection for data base
        internal static SqlCommand _cmd; //enables commands
        internal static SqlDataReader _reader; //enables commands outputs to be stored

        //Class
        internal class Snacks
        {
            //Create variable for each item in data base
            internal int ProductID;
            internal string SnackName;
            internal float PurchasePrice;
            internal float SalePrice;
            internal byte QOH;
            internal byte Slot;
            internal byte QFS;
            internal string ImagePath;
        }

        //List
        internal static List<Snacks> snackList = new List<Snacks>();

        internal static void GetSnacks()
        {
            string sqlString = "SELECT * FROM dbo.Snacks"; //Query Command

            try
            {
                //open connection
                _connection = new SqlConnection(_connString);
                _cmd =  new SqlCommand(sqlString, _connection);

                _connection.Open();

                _reader = _cmd.ExecuteReader();


                //While there is still items to be read
                while(_reader.Read())
                {

                    Snacks snacks = new Snacks(); //new instance of snack
                    snacks.ProductID = Convert.ToInt32(_reader.GetValue(0)); //snacks productID is first index

                    //if values are not null, set corresponding variables
                    if (_reader.GetValue(1) != DBNull.Value)
                        snacks.SnackName = _reader.GetValue(1).ToString();

                    if (_reader.GetValue(2) != DBNull.Value)
                        snacks.PurchasePrice = float.Parse(_reader.GetValue(2).ToString());

                    if (_reader.GetValue(3) != DBNull.Value)
                        snacks.SalePrice = float.Parse(_reader.GetValue(3).ToString());

                    if (_reader.GetValue(4) != DBNull.Value)
                        snacks.QOH = Convert.ToByte(_reader.GetValue(4));

                    if (_reader.GetValue(5) != DBNull.Value)
                        snacks.Slot = Convert.ToByte(_reader.GetValue(5));

                    if (_reader.GetValue(6) != DBNull.Value)
                        snacks.QFS = Convert.ToByte(_reader.GetValue(6));

                    if (_reader.GetValue(7) != DBNull.Value)
                        snacks.ImagePath = _reader.GetValue(7).ToString();

                    snackList.Add(snacks); //add items to list

                }
                _reader.Close(); //close connection
            }
            catch(Exception ex) //show error if try fails
            {
                MessageBox.Show("Error reading from Snacks table: " + ex.Message);
            }
        }
        
        internal static int AddSnacks(string snackname, float purchaseprice, float saleprice, byte qoh, byte slot, byte qfs, string imagepath)
        {
            int id = -1;

            //SQL code set to a string
            string sqlString = "INSERT INTO dbo.Snacks (SnackName, PurchasePrice, SalePrice, QOH, Slot, QFS, ImagePath) " +
                "VALUES(@snackname, @purchaseprice, @saleprice, @qoh, @slot, @qfs, @imagepath); " +
                "SELECT IDENT_CURRENT(\'dbo.Snacks\')";
            
            try
            {
                //set up connection
                _connection = new SqlConnection(_connString);
                _cmd = new SqlCommand(sqlString, _connection);


                //Points to where to get each parameters value
                //Long way to add values
                _cmd.Parameters.Add("@snackname", SqlDbType.NVarChar);
                _cmd.Parameters["@snackname"].Value = snackname;
                //Short way to add values
                //_cmd.Parameters.AddWithValue("@snackname", snackname);

                _cmd.Parameters.AddWithValue("@purchaseprice", purchaseprice);

                _cmd.Parameters.AddWithValue("@saleprice", saleprice);

                _cmd.Parameters.AddWithValue("@qoh", qoh);

                _cmd.Parameters.AddWithValue("@slot", slot);

                _cmd.Parameters.AddWithValue("@qfs", qfs);

                _cmd.Parameters.AddWithValue("@imagepath", imagepath);


                //Start connection
                _connection.Open();

                //Execute sqlString
                id = Convert.ToInt32(_cmd.ExecuteScalar());

                //End connection
                _connection.Close();

            }
            catch (Exception ex)
            {
                //if try doesnt works display error
                MessageBox.Show("Error occured when adding to Snacks: " + ex.Message);
            }
            return id;
        }

        internal static void EditSnacks(int id, string snackname, float purchaseprice, float saleprice, byte qoh, byte slot, byte qfs, string imagepath)
        {
            string sqlString = "UPDATE dbo.Snacks " +
                "SET SnackName = @snackname, PurchasePrice = @purchaseprice, SalePrice = saleprice, QOH = @qoh, Slot = @slot, QFS = @qfs, ImagePath = @imagepath " +
                "WHERE ProductID=@id";

            if (id > 0)
            {
                try
                {
                    //set up connection
                    _connection = new SqlConnection(_connString);
                    _cmd = new SqlCommand(sqlString, _connection);

                    //Points to where to get each parameters value
                    //Short way to add values
                    _cmd.Parameters.AddWithValue("@id", id);

                    _cmd.Parameters.AddWithValue("@snackname", snackname);

                    _cmd.Parameters.AddWithValue("@purchaseprice", purchaseprice);

                    _cmd.Parameters.AddWithValue("@saleprice", saleprice);

                    _cmd.Parameters.AddWithValue("@qoh", qoh);

                    _cmd.Parameters.AddWithValue("@slot", slot);

                    _cmd.Parameters.AddWithValue("@qfs", qfs);

                    _cmd.Parameters.AddWithValue("@imagepath", imagepath);

                    //Start connection
                    _connection.Open();

                    //Execute sqlString
                    _cmd.ExecuteNonQuery();

                    //End connection
                    _connection.Close();

                }
                catch (Exception ex)
                {
                    //if try doesnt works display error
                    MessageBox.Show("Error occured when editing Snacks: " + ex.Message);
                }
            }
        }

        internal static void DeleteSnacks(int id)
        {
            string sqlString = "DELETE FROM dbo.Snacks WHERE ProductID = @id";

            if (id > 0) 
            {
                try
                {
                    //set up connection
                    _connection = new SqlConnection(_connString);
                    _cmd = new SqlCommand(sqlString, _connection);

                    //Points to where to get each parameters value
                    //Short way to add values
                    _cmd.Parameters.AddWithValue("@id", id);

                    //Start connection
                    _connection.Open();

                    //Execute sqlString
                    _cmd.ExecuteNonQuery();

                    //End connection
                    _connection.Close();
                }
                catch (Exception ex)
                {
                    //if try doesnt works display error
                    MessageBox.Show("Error occured when deleting Snacks: " + ex.Message);
                }
            }
        }

        internal static int AddSale(int machineid, int procductid, float salesprice, byte qoh, byte slot, byte qfs)
        {
            int id = -1;

            //SQL code set to a string
            string sqlString = "INSERT INTO dbo.Sales (MachineID, ProductID, SalesPrice, QOH, Slot, QFS, DateTime) " +
                "VALUES(@machineid, @productid, @salesprice, @qoh, @slot, @qfs, @datetime); " +
                "SELECT IDENT_CURRENT(\'dbo.Sales\')";

            try
            {
                //set up connection
                _connection = new SqlConnection(_connString);
                _cmd = new SqlCommand(sqlString, _connection);


                //Points to where to get each parameters value
                //Long way to add values
                //_cmd.Parameters.Add("@snackname", SqlDbType.NVarChar);
                //_cmd.Parameters["@snackname"].Value = snackname;

                //Short way to add values
                _cmd.Parameters.AddWithValue("@machineid", machineid);

                _cmd.Parameters.AddWithValue("@productid", procductid);

                _cmd.Parameters.AddWithValue("@salesprice", salesprice);

                _cmd.Parameters.AddWithValue("@qoh", qoh);

                _cmd.Parameters.AddWithValue("@slot", slot);

                _cmd.Parameters.AddWithValue("@qfs", qfs);

                _cmd.Parameters.AddWithValue("@datetime", DateTime.Now);


                //Start connection
                _connection.Open();

                //Execute sqlString
                id = Convert.ToInt32(_cmd.ExecuteScalar());

                //End connection
                _connection.Close();

            }
            catch (Exception ex)
            {
                //if try doesnt works display error
                MessageBox.Show("Error occured when adding to Snacks: " + ex.Message);
            }
            return id;
        }

        internal static void EditVending(int productid, float saleprice, byte qfs, int machineid, byte slot, byte qoh)
        {
            if (qfs > 0)
            {
                string sqlString = "UPDATE dbo.Vending " +
                "SET SalePrice = @saleprice, QFS = @qfs, MachineID = @machineid, NumSlots = @slot, QOH = @qoh " +
                "WHERE ProductID=@productid";

                if (productid >= 3 && productid <= 10)
                {
                    try
                    {
                        //set up connection
                        _connection = new SqlConnection(_connString);
                        _cmd = new SqlCommand(sqlString, _connection);

                        //Points to where to get each parameters value
                        //Short way to add values
                        _cmd.Parameters.AddWithValue("@productid", productid);

                        _cmd.Parameters.AddWithValue("@saleprice", saleprice);

                        _cmd.Parameters.AddWithValue("@qfs", qfs);

                        _cmd.Parameters.AddWithValue("@machineid", machineid);

                        _cmd.Parameters.AddWithValue("@slot", slot);

                        _cmd.Parameters.AddWithValue("@qoh", qoh);



                        //Start connection
                        _connection.Open();

                        //Execute sqlString
                        _cmd.ExecuteNonQuery();

                        //End connection
                        _connection.Close();


                    }
                    catch (Exception ex)
                    {
                        //if try doesnt works display error
                        MessageBox.Show("Error occured when editing Vending: " + ex.Message);
                    }
                }
            }
        }
    }
}
