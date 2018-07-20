using System;
using System.Collections;// Non Generics
using System.Collections.Generic;// generics
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhoneClient

{
    class Programs
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Here");
            //Console.ReadLine();
        }
            class Person
        {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }

            public Person(int id, string firstName, string lastName, string address, string phone)
            {
                this.id = id;
                this.firstName = firstName;
                this.lastName = lastName;
                this.Address = address;
                this.Phone = phone;
            }


        }
    }
}
