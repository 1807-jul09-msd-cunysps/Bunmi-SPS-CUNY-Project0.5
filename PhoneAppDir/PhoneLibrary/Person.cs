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
            // initializing dependent object Address
            this.phone = new Phone(); //initializing dependent object Phone
        }

        

        public long Pid { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
           
            public Phone phone { get; set; }

        

         public void GetObjectData(SerializationInfo info, StreamingContext context) // serialization function to store object data in a file                                                                      // "SerializationInfo" holds key value pairs for data in the object
                                                                                    // "StreamingContextused" used to hold additional info
        {
            info.AddValue("Personid", Pid);
            info.AddValue("FirstName", firstName);
            info.AddValue("LastName", lastName);
            
            info.AddValue("Phone", phone);
        }

        public Person(SerializationInfo info, StreamingContext context) // for deserialization (or removing) of object data from file
        {
            Pid = (long)info.GetValue("PersonId", typeof(long));
            firstName = (string)info.GetValue("FirstName", typeof(string));
            lastName = (string)info.GetValue("LastName", typeof(string));
           
        }
    }
}
