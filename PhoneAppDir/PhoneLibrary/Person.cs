using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneContactLibrary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PhoneContactLibrary
{
    [Serializable()]
    public class Person : ISerializable
    {
         
        //creating the object person
        public Person()
        {
            this.Pid = Pid;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = new Address(); // initializing dependent object Address
            this.phone = new Phone(); //initializing dependent object Phone
        }

            public long Pid { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public Address address { get; set; }
            public Phone phone { get; set; }

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

         public void GetObjectData(SerializationInfo info, StreamingContext context) // serialization function to store object data in a file                                                                      // "SerializationInfo" holds key value pairs for data in the object
                                                                                    // "StreamingContextused" used to hold additional info
        {
            info.AddValue("Personid", Pid);
            info.AddValue("FirstName", firstName);
            info.AddValue("LastName", lastName);
            info.AddValue("Address", address);
            info.AddValue("Phone", phone);
        }

        public Person(SerializationInfo info, StreamingContext context) // for deserialization (or removing) of object data from file
        {
            Pid = (long)info.GetValue("PersonId", typeof(long));
            firstName = (string)info.GetValue("FirstName", typeof(string));
            lastName = (string)info.GetValue("LastName", typeof(string));
            address = (Address)info.GetValue("Address", typeof(Address));
            phone = (Phone)info.GetValue("Phone", typeof(string));
        }
    }
}
