using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneLibrary;
using System.Runtime.Serialization;

namespace PhoneLibrary
{
    public class Person
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
            
    }
}
