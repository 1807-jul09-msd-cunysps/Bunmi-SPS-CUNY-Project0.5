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

  
    public class UserInterface
    {

        string conStr = "data source=rev-cuny-b-server.database.windows.net;initial catalog=phonedirapp;persist security info=true;user id=bunmialo;password=Olamide1";


        public void showRecord()
        {
            SqlConnection conPerson = null;

            try

            {
                conPerson = new SqlConnection(conStr);
                conPerson.Open();
                String p_Query = "select * from Person";
                SqlCommand cmd = new SqlCommand(p_Query, conPerson);
                SqlDataReader Person = cmd.ExecuteReader();

                while (Person.Read())
                {
                    Console.WriteLine(Person[0] + "\t" + Person[1] + "\t" + Person[2] + "\t" + Person[3] +
                                            "\t" + Person[4] + "\t" + Person[5] + "\t" + Person[6] + "\t" +
                                            Person[7] + "\t" + Person[8] + "\t" + Person[9] + "\t" + Person[10]);
                }
                conPerson.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                LogManager.GetCurrentClassLogger().Error(e, "Whoops!");
                Console.WriteLine(e);
            }
        }

        #region
        public void EditRecord()
        {

            //int counter = 0;
            Console.WriteLine("Existing person records in the database:\n\n");
            showRecord();

            Console.WriteLine("Please enter the ID whose record you would like to edit");
            int id = Convert.ToInt16(Console.ReadLine()); //converting int to short
            string fname, lname, houseno, str_name, city, state, zipcode, country, c_code, phone;
                                                          Console.WriteLine("Please enter new data for person ID: " + id);
            Console.WriteLine("please enter first name: ");
            fname = Console.ReadLine();
            //Console.WriteLine("Please enter last name");
            //lname = Console.ReadLine();
            //Console.WriteLine("Enter House No: ");
            //houseno = Console.ReadLine();
            //Console.WriteLine("Enter Street Name: ");
            //str_name = Console.ReadLine();
            //Console.WriteLine("Enter City: ");
            //city = Console.ReadLine();
            //Console.WriteLine("Enter State: ");
            //state = Console.ReadLine();
            //Console.WriteLine("Enter Zip Code: ");
            //zipcode = Console.ReadLine();
            //Console.WriteLine("Enter Country: ");
            //country = Console.ReadLine();
            //Console.WriteLine("Enter Country Code: ");
            //c_code = Console.ReadLine();
            //Console.WriteLine("Enter Phone Number: ");
            //phone = Console.ReadLine();


            SqlConnection con = null;
            string command = "update Person  set FirstName= '" + fname + "' where ID='" + id + "'";
            //    //string command1 = "update Person  set Lastname='" + lname + "' where ID='" + id + "'";
            //    //string command2 = "update Person  set HouseNo= '" + houseno + "' where ID='" + id + "'";
            //    //string command3 = "update Person  set StreetName= '" + str_name + "' where ID='" + id + "'";
            //    //string command4 = "update Person  set City= '" + city + "' where ID='" + id + "'";
            //    //string command5 = "update Person  set State= '" + state + "' where ID='" + id + "'";
            //    //string command67 = "update Person  set Zipcode= '" + zipcode + "' where ID='" + id + "'";
            //    //string command8 = "update Person  set Country= '" + country + "' where ID='" + id + "'";
            //    //string command9 = "update Person  set CountryCode= '" + c_code + "' where ID='" + id + "'";
            //    //string command10 = "update Person  set Phone= '" + phone + "' where ID='" + id + "'";


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

        public void addPerson(string fname, string lname, string houseno, string str_name, string city, string state, string zipcode, string country, string c_code, string phone)
        {

            SqlConnection con = null;

            try
            {
                
                con = new SqlConnection(conStr);
                con.Open();
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.CommandText = "insert into Person values('" + fname + "','" + lname + "','" + houseno + "','" + str_name + "', '" + city + "', '" + state + "', '" + zipcode + "', '" + country + "', '" + c_code + "', '" + phone + "')";
                com.ExecuteNonQuery();
                Console.WriteLine("person  record added successfully!");
                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                LogManager.GetCurrentClassLogger().Error(e, "Whoops!");
                Console.WriteLine("Error while saving person record " + e);
            }
            return;
        }

        #region
        public void Remove()
        {
            SqlConnection con = null;
            int ID = 0;
            try
            {
                string conStr = null;
                con = new SqlConnection(conStr);
                con.Open();

                String query = "select * from Person";
                //2. SQL Command
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "\t" + dr[1] + "\t" + dr[2] + "\t" + dr[3] + "\t" + dr[4] + "\t" +
                                      dr[5] + "\t" + dr[6] + "\t" + dr[7] + "\t" + dr[8] + "\t" + dr[9] + "\t" + dr[10]);
                    Console.WriteLine();
                }
                Console.WriteLine("Please enter Person id to remove it\n");
                ID = Convert.ToInt16(Console.ReadLine());

                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                LogManager.GetCurrentClassLogger().Error(e, "Whoops!");

                Console.WriteLine(e);
            }

            try
            {
                string conStr = null;
                con = new SqlConnection(conStr);
                con.Open();

                String query = "delete From Person where ID='" + ID + "'";
                //2. SQL Command
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Person ID " + ID + " removed successfully!");

                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                LogManager.GetCurrentClassLogger().Error(e, "Whoops!");

                Console.WriteLine(e);
            }
        }
        #endregion

        #region
        public void search()
        {
            SqlConnection con = null;

            Console.WriteLine("First Name to search");
            String firstname;
            int counter = 0;
            Console.WriteLine("Enter First Name: ");
            firstname = Console.ReadLine();
            try
            {
                string conStr = null;
                con = new SqlConnection(conStr);
                con.Open();

                String command = "select *from Person where FirstName='" + firstname + "'";
                SqlCommand cmd = new SqlCommand(command, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "\t" + dr[1] + "\t" + dr[2] + "\t" + dr[3] + "\t" + dr[4] + "\t" +
                                      dr[5] + "\t" + dr[6] + "\t" + dr[7] + "\t" + dr[8] + "\t" + dr[9] + "\t" + dr[10]);
                    counter++;
                }
                if (counter == 0)
                {
                    Console.WriteLine("No record exists with such name");
                }
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                LogManager.GetCurrentClassLogger().Error(e, "Whoops!");

                Console.WriteLine(e);
            }
        }
        #endregion
    }
}