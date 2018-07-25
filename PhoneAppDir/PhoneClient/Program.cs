using System;
using System.Collections;// Non Generics
using System.Collections.Generic;// generics
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // ADO.Net lib
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json; // library to serialize and deserialize
using System.Net.Http.Headers;
using PhoneContactLibrary;


namespace PhoneContactClient

{
    class Programs
    {
        //static async Task<IEnumerable<User>> get()
            public List<Person> Get()
        {
            Person p1 = new Person();
            p1.firstName = "Bunmi";
            p1.lastName = "Alo";
            p1.Pid = DateTime.Now.Ticks;
            p1.address.houseNo = "419";
            p1.address.Pid = p1.Pid;
            p1.address.streetName = "2nd";
            p1.address.city = "New York";
            p1.address.State = State.NY;
            p1.address.Country = Country.US;
            p1.address.zipCode = "10001";
            p1.phone.Pid = p1.Pid;
            p1.phone.areaCode = "347";
            p1.phone.countryCode = Country.US;
            p1.phone.ext = "";
            p1.phone.number = "3452878991";

            Person p2 = new Person();
            p1.firstName = "Ola";
            p1.lastName = "Mide";
            p1.Pid = DateTime.Now.Ticks;
            p1.address.houseNo = "234";
            p1.address.Pid = p1.Pid;
            p1.address.streetName = "1st";
            p1.address.city = "New York";
            p1.address.State = State.NY;
            p1.address.Country = Country.US;
            p1.address.zipCode = "10047";
            p1.phone.Pid = p1.Pid;
            p1.phone.areaCode = "212";
            p1.phone.countryCode = Country.US;
            p1.phone.ext = "";
            p1.phone.number = "3452878992";

            List<Person> p = new List<Person>();
            p.Add(p1);
            p.Add(p2);
            return p;
        }
 


        static void Main(string[] args)
        {

            SqlConnection con = null;
            string command = "select * from CUNY_SPS_DDL";
            string conStr = "Data Source=rev-cuny-b-server.database.windows.net;Initial Catalog=REV-CUNY;Persist Security Info=True;User ID=bunmialo;Password=Olamide1";
            //1. SQL Connection
            try
            {
                con = new SqlConnection(conStr);
                con.Open();

                //2. SQL Command
                SqlCommand cmd = new SqlCommand(command, con);

                //3. Execute query
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("Id Name      City");
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[4]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            Console.WriteLine();
            Console.ReadLine();

            //var users = get();
            //foreach (var user in users.Res)
        }

    }
}
