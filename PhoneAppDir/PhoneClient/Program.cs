using System;
using System.Collections;// Non Generics
using System.Collections.Generic;// generics
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json; // library to serialize and deserialize
using System.Net.Http.Headers;
using PhoneContactLibrary;
using PhoneLibrary;

namespace PhoneContactClient

{
    //Making the list of the implemented classes above in this class so list will be seperate and all of its functions will be in same place
    public class Operations
    {
        List<Person> personList = new List<Person>();

        public void addPerson(string fname, string lname, string houseno, string str_name, string city, string state, string zipcode, string country, string c_code, string phone)
        {
            personList.Add(new Person { firstName = fname, lastName = lname, houseNo = houseno, streetName = str_name, city = city, state = state, zipCode = zipcode, country = country, countryCode = c_code });
            Console.WriteLine("Person ID " + fname + " has been added!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void showPerson()
        {
            int counter = 0;
            foreach (Person reader in personList)
            {
                Console.WriteLine(reader);
                counter++; //increments counts by 1, so if record doesn't exist, it increments by 0. In other words, no increment
            }
            if (counter == 0)
            {
                Console.WriteLine("No record found!");
            }
        }
    }

    #region

    class Programs
    {
        static void Main(string[] args)
        {
          
            UserInterface users = new UserInterface();
            Operations operation = new Operations();
            long p_id; 
            String fname, lname, houseno, str_name, city, state, zipcode, country, c_code, phone;
   
              
            char y = 'y';//assign the character variable y to 'y' because we have to start the looop only if value of y is 'y'. Else, it will be terminated
            while (y == 'y')
            {
                Console.Clear(); // We have very large number of data on console and it make program too bad.That's why it is good practice to clean the window whenever you return to  menu
                Console.WriteLine(" ********HELLO AND WELCOME TO BUNMI'S PHONE DIRECTORY!********\n\n");
                Console.WriteLine(" Please select an option from the menu below:\n");
                Console.WriteLine(" Press 1 to show records\n Press 2 to add a record\n Press 3 to Remove a record\n Press 4 to Edit person record\n Press 5 to search record\n Press 6 to Exit application");
                int choice;
                
                choice = Convert.ToInt16(Console.ReadLine());//console.readline() only accept string as a input so in order to take input in other variable we need to convert to specific object type
                switch (choice)
                {
                    case 1:
                        users.showRecord();
                        Console.WriteLine("Data in list\n\n");
                        operation.showPerson();
                        break;
                    case 2:
                        Console.WriteLine("Enter First Name: ");
                        fname = Console.ReadLine();
                        Console.WriteLine("Enter Last Name: ");
                        lname = Console.ReadLine();
                        Console.WriteLine("Enter House No: ");
                        houseno = Console.ReadLine();
                        Console.WriteLine("Enter Street Name: ");
                        str_name = Console.ReadLine();
                        Console.WriteLine("Enter City: ");
                        city = Console.ReadLine();
                        Console.WriteLine("Enter State: ");
                        state = Console.ReadLine();
                        Console.WriteLine("Enter Zip Code: ");
                        zipcode = Console.ReadLine();
                        Console.WriteLine("Enter Country: ");
                        country = Console.ReadLine();
                        Console.WriteLine("Enter Country Code: ");
                        c_code = Console.ReadLine();
                        Console.WriteLine("Enter Phone Number: ");
                        phone = Console.ReadLine();
                        //These variables cannot accept user input which isa in the form off string so that why i put in this way in that shoprogram why do we specifically use the values in the code like AK and UK for the state and country respectively?
                        operation.addPerson(fname, lname, houseno, str_name, city, state, zipcode, country, c_code, phone);// this is used to perform operation on the list of address and person that doesnot matter what is the class name you can chnage it to another name

                        users.addPerson(fname, lname, houseno, str_name, city, state, zipcode, country, c_code, phone);
                        break;
                    case 3:
                        users.Remove();
                        break;
                    case 4:
                        users.EditRecord();
                        break;
                    case 5:
                        users.search();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("Do you want to continue y/n?");
                y = Convert.ToChar(Console.ReadLine());
                if (y != 'y')
                {
                    Console.WriteLine("Thank you for your time!\n");
                    Environment.Exit(0);
                }
            }//while close
               Console.ReadKey();
           }
        

    }
}
    #endregion