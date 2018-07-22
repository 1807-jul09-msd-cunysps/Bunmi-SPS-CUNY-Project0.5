using System;
using System.Collections;// Non Generics
using System.Collections.Generic;// generics
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace PhoneClient

{
    class Programs
    {
        static void Main(string[] args)
        {

            List<Person> persons = new List<Person>
            {
                new Person(){ Personid = 1, firstName = "Tobi", lastName = "Loba", }
            };

     
            Stream stream = File.Open("PersonData.dat",
                FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, tobi);
            stream.Close();
            tobi = null;

            stream = File.Open("PersonData.dat", FileMode.Open);

            bf = new BinaryFormatter();

            tobi = (Person)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine(tobi.ToString());

            Console.ReadLine();
        }

    }
}
