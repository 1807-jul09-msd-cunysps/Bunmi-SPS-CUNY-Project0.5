using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneLibrary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PhoneLibrary
{
    [Serializable()]
    public class Person : ISerializable
    {
        //creating the object person
        public Person(int pid, string firstName, string lastName)
        {
            this.pid = pid;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = new Address(); // creating new instance of address
            this.phone = new Phone(); //creating new instance of phone
        }

            public int pid { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public Address address { get; set; }
            public Phone phone { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context) // serialization function to store object data in a file
                                                                                    // "SerializationInfo" holds key value pairs for data in the object
                                                                                    // "StreamingContextused" used to hold additional info
        {
            info.AddValue("Personid", pid);
            info.AddValue("FirstName", firstName);
            info.AddValue("LastName", lastName);
            info.AddValue("Address", address);
            info.AddValue("Phone", phone);
        }

        public Person(SerializationInfo info, StreamingContext context) // for deserialization (or removing) of object data from file
        {
            pid = (int)info.GetValue("Personid", typeof(int));
            firstName = (string)info.GetValue("FirstName", typeof(string));
            lastName = (string)info.GetValue("LastName", typeof(string));
            address = (Address)info.GetValue("Address", typeof(Address));
            phone = (Phone)info.GetValue("Phone", typeof(string));
        }
    }
}
