using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // ADO.Net lib
using System.Data.SqlClient;
using PhoneContactLibrary;
using System.Collections;
using NLog;


namespace PhoneLibrary
{

    public class contacts
    {
        public int Per_ID { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }

        public int ph_id { get; set; }
        public String ph_areaCode { get; set; }
        public String ph_countryCode { get; set; }
        public String ph_number { get; set; }
        public String h_no { get; set; }
        public String h_street { get; set; }
        public String h_state { get; set; }
        public String h_zipCode { get; set; }

        public String h_country { get; set; }
        public override string ToString()
        {
            return "Person ID: " + Per_ID + "\nFirst Name: " + Fname + "\nLast Name: " + Lname + "\nphone No: " + ph_countryCode + "-" + ph_areaCode + "-" + ph_number + "\nHouse No: " + h_no + "\nStreet: " + h_street + "\nState: " + h_state + "\ncountry: " + h_country;
        }
    }


    public class UserInterface
    {
        int H_id;
        string conStr = "Data Source=rev-cuny-b-server.database.windows.net;Initial Catalog=PhoneDirApp;Persist Security Info=True;User ID=bunmialo;Password=Olamide1";


        #region
        //static async Task<IEnumerable<User>> get()
        public void showRecord()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(conStr);
                con.Open();

                String query = "select * from Person";
                //2. SQL Command
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "\t" + dr[1] + "\t" + dr[2] + "\t" + dr[3] + "\t" + dr[4] );
                    Console.WriteLine();
                }
                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Whoops!");

                Console.WriteLine(e);
            }
            //showing person record
            Console.WriteLine("\n\n");
            Console.WriteLine("Person record\n");
            try
            {
                con = new SqlConnection(conStr);
                con.Open();

                String query = "select * from Person";
                //2. SQL Command
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "\t" + dr[1] + "\t" + dr[2] + "\t" + dr[3] + "\t" + dr[4]);
                    Console.WriteLine();
                }
                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Whoops!");

                Console.WriteLine(e);
            }
            //showing phone record
            Console.WriteLine("\n\nphone record");
            try
            {
                con = new SqlConnection(conStr);
                con.Open();

                String query = "select * from Phone";
                //2. SQL Command
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "\t" + dr[1] + "\t" + dr[2] + "\t" + dr[3]);
                    Console.WriteLine();
                }
                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Whoops!");

                Console.WriteLine(e);
            }
        }
        #endregion

        #region
        public void EditRecord()
        {
           
            //int counter = 0;
            Console.WriteLine("Existing person records in the database:\n\n");
            showRecord();

            Console.WriteLine("Please enter the ID whose record you would like to edit");
            int id = Convert.ToInt16(Console.ReadLine()); //converting int to long
            string fname, lname;
            Console.WriteLine("Please enter new data for person ID: " + id);
            Console.WriteLine("please enter first name: ");
            fname = Console.ReadLine();
            Console.WriteLine("Please enter last name");
            lname = Console.ReadLine();
           

            SqlConnection con = null;
            string command = "update Person  set FirstName= '" + fname + "',Lastname='"+lname+"' where ID='"+id+"'";


            //1. SQL Connection
            try
            {
                con = new SqlConnection(conStr);
                con.Open();

                //2. SQL Command
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record updated successfully!");
                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Whoops!");

                Console.WriteLine(e);
            }
        }

        #endregion

        #region
        public void addPhone(long id, string areacode, string countryCode, String number)
        {
            SqlConnection con = null;
 
            try
            {
                SqlCommand com = new SqlCommand();
                con = new SqlConnection(conStr);
                con.Open();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.CommandText = "insert into Phone values('" + id + "','" + countryCode + "','" + areacode + "','" + number + "')";
                com.ExecuteNonQuery();
                Console.WriteLine("Record of Phone save successfuly!");
                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Whoops!");

                Console.WriteLine("Error is " + e);
            }
        }
        public void addAdress(long H_id, String H_No, String H_streetName, String H_city, State H_state, string H_zipCode, Country H_country)
        {
           
            SqlConnection con = null;

            try
            {
                SqlCommand com = new SqlCommand();
                con = new SqlConnection(conStr);
                con.Open();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.CommandText = "insert into Address values('" + H_id + "','" + H_No + "','" + H_streetName + "','" + H_city + "','" + H_state + "','" + H_zipCode + "','" + H_country + "')";
                com.ExecuteNonQuery();
                Console.WriteLine("Record of adresses save successfully!");
                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Whoops!");
                Console.WriteLine("Error is " + e);
            }
        }
        public void addPerson(long h_id, long per_id, long ph_id, string firstname, string lastname)
        {

            SqlConnection con = null;

            try
            {
                SqlCommand com = new SqlCommand();
                con = new SqlConnection(conStr);
                con.Open();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.CommandText = "insert into Person values('" + per_id + "','" + firstname + "','" + lastname + "','" + h_id + "','" + ph_id + "')";
                com.ExecuteNonQuery();
                Console.WriteLine("person  record added successfully!");
                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Whoops!");
                Console.WriteLine("Error while saving person record " + e);
            }
            return;
        }
        #endregion

        #region
        public void Remove()
        {
            SqlConnection con = null;
            int ID=0;
            try
            {
                con = new SqlConnection(conStr);
                con.Open();

                String query = "select * from Person";
                //2. SQL Command
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "\t" + dr[1] + "\t" + dr[2] + "\t" + dr[3] + "\t" + dr[4]);
                    Console.WriteLine();
                }
                Console.WriteLine("Please enter Person id to rewmove it\n");
                ID = Convert.ToInt16(Console.ReadLine());

                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Whoops!");

                Console.WriteLine(e);
            }
          
            try
            {
                con = new SqlConnection(conStr);
                con.Open();
         
                String query = "delete From Person where ID='"+ID+"'";
                //2. SQL Command
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("person ID " + ID + " remove successfully!");

                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Whoops!");

                Console.WriteLine(e);
            }
        }
        #endregion
        #region
        public void search()
        {
            SqlConnection con = null;

            Console.WriteLine("Enter ID and first name to seacrh");
            int person_ID,counter=0;
            String firstname;
            Console.WriteLine("Enter ID: ");
            person_ID = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter first name: ");
            firstname = Console.ReadLine();
            try
            {
                con = new SqlConnection(conStr);
                con.Open();

                String command = "select *from Person where FirstName='" +firstname + "'and ID='"+person_ID+"'";
                SqlCommand cmd = new SqlCommand(command, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "\t" + dr[1] + "\t" + dr[2] + "\t" + dr[3] + "\t" + dr[4]);
                    counter++;
                }
                if (counter == 0)
                {
                    Console.WriteLine("No record exist with such name and id");
                }
            }
            catch(Exception e)
            {
                // Logging exception here using NLog
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Whoops!");

                Console.WriteLine(e);
            }
        }
        #endregion
    }
}
