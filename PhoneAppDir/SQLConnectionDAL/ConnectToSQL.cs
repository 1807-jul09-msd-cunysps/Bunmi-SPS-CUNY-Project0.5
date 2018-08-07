using PhoneContactLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using NLog;
using System.Data;

namespace SQLConnectionDAL
{

    public class ConnectToSQL
    {
        List<Person> directory = new List<Person>();
        string conStr = "Data Source=rev-cuny-b-server.database.windows.net;Initial Catalog=PhoneDirApp;Persist Security Info=True;User ID=bunmialo;Password=Olamide1";

        public List<Person> GET()
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
                    Person p = new Person();
                    p.P_id =Convert.ToInt64(Person[0]);
                    p.firstName = (string)Person[1];
                    p.lastName = (string)Person[2];
                    p.houseNo = (string)Person[3];
                    p.streetName = (string)Person[4];
                    p.city = (string)Person[5];
                    p.state = (string)Person[6];
                    p.zipCode = (string)Person[7];
                    p.country = (string)Person[8];
                    p.countryCode = (string)Person[9];
                    p.phone = (string)Person[10];

                    directory.Add(p);
                }
                conPerson.Close();

                return directory;
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                LogManager.GetCurrentClassLogger().Error(e, "Whoops!");
                return null;
                throw;
            }
        }
        public void POST(Person p)
        {

            SqlConnection con = null;

            try
            {

                con = new SqlConnection(conStr);
                con.Open();
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.CommandText = "insert into Person values('" + p.firstName + "','" + p.lastName + "','" + p.houseNo + "','" + p.streetName + "', '" + p.city + "', '"
                                                            + p.state + "', '" + p.zipCode + "', '" + p.country + "', '" + p.countryCode + "', '" + p.phone + "')";
                com.ExecuteNonQuery();
                //Console.WriteLine("person  record added successfully!");
                con.Close();
            }
            catch (Exception e)
            {
                // Logging exception here using NLog
                LogManager.GetCurrentClassLogger().Error(e, "Whoops!");
                //Console.WriteLine("Error while saving person record " + e);
            }
            return;
        }
    }
}