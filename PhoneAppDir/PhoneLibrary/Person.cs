using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneContactLibrary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace PhoneContactLibrary
{

    //[Serializable()]
    public class Person //: ISerializable
    {
        public long P_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string houseNo { get; set; }
        public string streetName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public String zipCode { get; set; }
        public string country { get; set; }
        public String countryCode { get; set; }
        public string phone { get; set; }
    }
}
            








































//creating the object person
            //public Person()
        //{
            //this.Pid = Pid;
            //this.firstName = firstName;
            //this.lastName = lastName;
            //// initializing dependent object Address
            //this.phone = new Phone(); //initializing dependent object Phone
      //  }
            //public long Pid { get; set; }
            //public string firstName { get; set; }
            //public string lastName { get; set; }
            //public Phone phone { get; set; }

        // public void GetObjectData(SerializationInfo info, StreamingContext context) // serialization function to store object data in a file                                                                      // "SerializationInfo" holds key value pairs for data in the object
        //                                                                            // "StreamingContextused" used to hold additional info
        //{
        //    info.AddValue("Personid", Pid);
        //    info.AddValue("FirstName", firstName);
        //    info.AddValue("LastName", lastName);
        //    info.AddValue("Phone", phone);
        //}

        //public Person(SerializationInfo info, StreamingContext context) // for deserialization (or removing) of object data from file
        //{
        //    Pid = (long)info.GetValue("PersonId", typeof(long));
        //    firstName = (string)info.GetValue("FirstName", typeof(string));
        //    lastName = (string)info.GetValue("LastName", typeof(string));
           
        //}