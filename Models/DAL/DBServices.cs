using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Text;
using System.IO;

using System.Windows;
using System.Configuration;
using ResturantApp.Models;

namespace ResturantApp.Models.DAL
//namespace ResturantApp.Controllers
{
    public class DBServices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        public Customer ReadCustomer(string email, string password)
        {

            SqlConnection con = null;
            Customer c = new Customer();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
                

                //String selectSTR = "SELECT * FROM Customers_2021 Where email=" + email + " and password=" + password;
                //String selectSTR = "SELECT * FROM Customers_2021 Where email= "+"'"+ email +"'"+"+ and password ="+"'"+ password+"'";
                String selectSTR = "SELECT * FROM Customers_2021 where email = " + "'" + email + "'" + " and password = " + "'" + password + "'";

                SqlCommand cmd = new SqlCommand(selectSTR, con);



                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row                   
                    //Customer c = new Customer();
                    c.Email = (string)dr["email"];
                    c.Password = (string)dr["password"];
                    //cusList.Add(c);
                }

                return c;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }
        //for campagin
        public Businesses ReadCampaign(int id)
        {

            SqlConnection con = null;
            Businesses c = new Businesses();
            //List<Customer> cusList = new List<Customer>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file


                //String selectSTR = "SELECT * FROM Customers_2021 Where email=" + email + " and password=" + password;
                //String selectSTR = "SELECT * FROM Customers_2021 Where email= "+"'"+ email +"'"+"+ and password ="+"'"+ password+"'";
                String selectSTR = "SELECT * FROM Restaurants_2021 where id = " + "'" + id + "'";

                SqlCommand cmd = new SqlCommand(selectSTR, con);

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row                   
                    //Customer c = new Customer();
                    //c.Id = Convert.ToInt32(dr["id"]);
                    c.Photo = (string)dr["photo"];
                    c.Name = (string)dr["name"];
                    c.Rating = Convert.ToDouble(dr["rating"]);
                    c.Category = (string)dr["category"];
                    c.PriceRange = Convert.ToInt32(dr["priceRange"]);
                    c.Address = (string)dr["address"];
                    c.Phone = (string)dr["phone"];
                    c.LinkUrl = (string)dr["linkUrl"];
                }

                return c;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        public List<Businesses>  ReadResturantNonReg(string categ)
        {

            SqlConnection con = null;
            //Businesses b = new Businesses();
            List<Businesses> bList = new List<Businesses>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Restaurants_2021 where category = " + "'" + categ + "'";

                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row                   
                    Businesses b = new Businesses();

                    b.Id = Convert.ToInt32(dr["id"]);
                    b.Photo = (string)dr["photo"];
                    b.Name = (string)dr["name"];
                    b.Rating = Convert.ToDouble(dr["rating"]);
                    b.Category = (string)dr["category"];
                    b.PriceRange = Convert.ToInt32(dr["priceRange"]);
                    b.Address = (string)dr["address"];
                    b.Phone = (string)dr["phone"];
                    b.LinkUrl = (string)dr["linkUrl"];

                    bList.Add(b);
                }

                return bList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }
        public List<Campaign> ReadCampaignData()
        {

            SqlConnection con = null;
            List<Campaign> cmpList = new List<Campaign>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Campaign_2021";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row                   
                    Campaign c = new Campaign();

                    c.Id = Convert.ToInt32(dr["id"]);
                    c.InvestedAmount = Convert.ToInt32(dr["investedAmount"]);
                    c.Balance = Convert.ToInt32(dr["balance"]);
                    c.ViewsNum = Convert.ToInt32(dr["viewsNum"]);
                    c.ClicksNum = Convert.ToInt32(dr["clicksNum"]);
                    c.Status = Convert.ToBoolean(dr["status"]); ;
                    cmpList.Add(c);
                }

                return cmpList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        //the put investedAmount!!!!
        ////public void InsertCampignAmont(Campaign campaign)
        ////{

        ////    SqlConnection con;
        ////    SqlCommand cmd;

        ////    try
        ////    {
        ////        con = connect("DBConnectionString"); // create the connection
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        throw (ex);
        ////    }

        ////    String cStr = BuildUpdateCommand(campaign);      // helper method to build the insert string

        ////    cmd = CreateCommand(cStr, con);             // create the command

        ////    try
        ////    {
        ////        int numEffected = cmd.ExecuteNonQuery(); // execute the command
        ////        //return numEffected;
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        // write to log
        ////        throw (ex);
        ////    }

        ////    finally
        ////    {
        ////        if (con != null)
        ////        {
        ////            // close the db connection
        ////            con.Close();
        ////        }
        ////    }

        ////}
        ////private String BuildUpdateCommand(Campaign campaign)
        ////{
        ////    String command;
        ////    command = "UPDATE [Campaign_2021] SET investedAmount=" + campaign.InvestedAmount + "WHERE id=" + campaign.Id;
        ////    //StringBuilder sb = new StringBuilder();
        ////    // use a string builder to create the dynamic string
        ////    //sb.AppendFormat("Values('{0}')", campaign.InvestedAmount);
        ////    //String prefix = "UPDATE [Campaign_2021] SET investedAmount=" + campaign.InvestedAmount + "WHERE id=" + campaign.Id;
        ////    //command = prefix + sb.ToString();

        ////    return command;
        ////}

        public int InsertCustomer(Customer customer)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCustomerCommand(customer);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildInsertCustomerCommand(Customer customer)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}')", customer.Fname, customer.Lname, customer.Email, customer.PhoneN, customer.Password);
            String prefix = "INSERT INTO Customers_2021 " + "(fname, lname, email, phoneN, password) ";
            command = prefix + sb.ToString();

            return command;
        }
        
        public void InsertCustomerHighlight(string email, List<Highlights> highlights)
        {

            SqlConnection con; 
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            String cStr = BuildUpdateCommand(email, highlights);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                //return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildUpdateCommand(string email, List<Highlights> highlights)
        {
            String command; 

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}')", email, highlights);
            String prefix = "INSERT INTO HighlightsToCustomer_2021 " + "(CustomerId, HighlightId) ";
            command = prefix + sb.ToString();
            
            return command;
        }
        public Campaign InsertCampignAmont(Campaign campaign)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            String cStr = BuildUpdateCommand(campaign);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return campaign;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildUpdateCommand(Campaign camp)
        {
            String command;
            command = "UPDATE [Campaign_2021] SET investedAmount=" + camp.InvestedAmount + "WHERE id=" + camp.Id;
            //StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            //sb.AppendFormat("Values('{0}')", campaign.InvestedAmount);
            //String prefix = "UPDATE [Campaign_2021] SET investedAmount=" + campaign.InvestedAmount + "WHERE id=" + campaign.Id;
            //command = prefix + sb.ToString();

            return command;
        }

        public int Insert(Campaign campaign)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(campaign);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildInsertCommand(Campaign campaign)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}', '{4}', '{5}')", campaign.Id, campaign.InvestedAmount, campaign.Balance, campaign.ViewsNum, campaign.ClicksNum, campaign.Status);
            String prefix = "INSERT Campaign_2021 " + "(id, investedAmount, balance, viewsNum, clicksNum, status) ";
            command = prefix + sb.ToString();

            return command;
        }

    }

    


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    //public List<Businesses> ReadBusinesses()
    //{

    //    SqlConnection con = null;
    //    List<Businesses> favList = new List<Businesses>();

    //    try
    //    {
    //        con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

    //        String selectSTR = "SELECT * FROM Campaign_2021";
    //        SqlCommand cmd = new SqlCommand(selectSTR, con);

    //        // get a reader
    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

    //        while (dr.Read())
    //        {   // Read till the end of the data into a row                   
    //            Businesses b = new Businesses();

    //            b.Id = Convert.ToInt32(dr["id"]);
    //            b.Photo = (string)dr["photo"];
    //            b.Name = (string)dr["name"];
    //            b.Rating = Convert.ToDouble(dr["rating"]);
    //            b.Category = (string)dr["category"];
    //            b.PriceRange = Convert.ToInt32(dr["priceRange"]);
    //            b.Address = (string)dr["address"];
    //            b.Phone = (string)dr["phone"];
    //            b.LinkUrl = (string)dr["linkUrl"];
    //            favList.Add(b);
    //        }

    //        return favList;
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }

    //    }

    //}

}
