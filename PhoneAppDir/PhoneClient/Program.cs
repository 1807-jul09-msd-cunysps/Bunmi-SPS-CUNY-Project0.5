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

    public class Person
    {

        public long Per_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public long ph_id { get; set; }
        public string ph_areaCode { get; set; }
        public String ph_countryCode { get; set; }
        public String ph_number { get; set; }
        public override string ToString()
        {
            return "Person Id: " + Per_id + "\nFirst Name: " + firstName + "\nLast Name: " + lastName + "\nphone No: " + ph_countryCode + "-" + ph_areaCode + "-" + ph_number;

        }
    }

    //the classes that are implement above we are making the list of that classes in this class so list will be seperate and its all functions will be in same place
    public class Operations
    {
        List<Person> personList = new List<Person>();
        List<Address> mylist = new List<Address>();
        public void addAddress(long _Pid, String _houseno, string _streetname, string _city, State _state, string _zipcode, Country _country)
        {
            mylist.Add(new Address { Pid = _Pid, houseNo = _houseno, streetName = _streetname, city = _city, state = _state, zipCode = _zipcode, Country = _country });
            Console.WriteLine("House No: " + _houseno + " hass been added!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void addpPerson(long _perId,string _fname,String _lname,long _ph_id,String _areaCode,String _countryCode,String _number)
        {
            personList.Add(new Person { Per_id = _perId, firstName = _fname, lastName = _lname, ph_id = _ph_id, ph_areaCode = _areaCode, ph_countryCode = _countryCode, ph_number = _number });
            Console.WriteLine("Person id " + _perId + " has been added!");
        }
        public void showPerson()
        {
            int counter = 0;
            foreach (Person reader in personList)
            {
                Console.WriteLine(reader);
                counter++;
            }
            if (counter == 0)
            {
                Console.WriteLine("No record found!");
            }
        }
        public void showAdress()
        {
            int counter = 0;
            foreach (Address reader in mylist)
            {
                Console.WriteLine(reader);
                counter++;
            }
            if (counter == 0)
            {
                Console.WriteLine("No record found!");
            }
        }
    }
    class Programs
    {
        static void Main(string[] args)
        {
            Operations operation = new Operations();
            long h_id,p_id,ph_id; 
            String H_no, H_street, H_state, H_zipCode, H_city, H_country,p_fname,p_lname,ph_areacode,ph_countryCode,ph_number;
            #region
              UserInterface users = new UserInterface();
            char y = 'y';//assign the character variable y to 'y' because we have to start the looop only if value of y is 'y' other wise it will be terminate
            while (y == 'y')
            {
                Console.Clear(); // We have very large number of data on console and it make program too bad so thats why to clean the window when ever you return to  menu
                Console.WriteLine(" ********HELLO AND WELCOME TO BUNMI'S PHONE DIRECTORY!********\n\n");
                Console.WriteLine(" Please select an option from the menu below:\n");
                Console.WriteLine(" Press 1 to show records\n Press 2 to add a record\n Press 3 to Remove a record\n press 4 to edit person Record\n5 to search6- Exit");
                int choice;
                
                choice = Convert.ToInt16(Console.ReadLine());//console.readline() only accept string as a input so in order to take input in other variable we need to convert to specific object type
                switch (choice)
                {
                    case 1:
                        users.showRecord();
                        Console.WriteLine("Data in list\n\n");
                        operation.showAdress();
                        operation.showPerson();
                        break;
                    case 2:
                        Console.WriteLine("Enter Id: ");
                        h_id = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Enter house No: ");
                        H_no = Console.ReadLine();
                        Console.WriteLine("Enter Street name: ");
                        H_street = Console.ReadLine();
                        Console.WriteLine("Enter city: ");
                        H_city = Console.ReadLine();
                        Console.WriteLine("Enter zip code: ");
                        H_zipCode = Console.ReadLine();
                        Console.WriteLine("Enter person ID");
                        p_id = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Enter first name: ");
                        p_fname = Console.ReadLine();
                        Console.WriteLine("Enter last name: ");
                        p_lname = Console.ReadLine();
                        Console.WriteLine("Enter phone Id: ");
                        ph_id = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Enter country code: ");
                        ph_countryCode = Console.ReadLine();
                        Console.WriteLine("Enter area code: ");
                        ph_areacode = Console.ReadLine();
                        Console.WriteLine("Enter Phone NUmber: ");
                        ph_number = Console.ReadLine();
                        operation.addAddress(h_id, H_no, H_street, H_city, State.AK, H_zipCode, Country.UK); //These variables cannot accept user input which isa in the form off string so that why i put in this way in that shoprogram why do we specifically use the values in the code like AK and UK for the state and country respectively?
                        operation.addpPerson(p_id, p_fname, p_lname, ph_id, ph_areacode, ph_countryCode, ph_number);// this is use to perform operation on the list of address andf person that doesnot matter what is the class name you can chnage it to another name

                        users.addAdress(h_id, H_no, H_street, H_city, State.AK, H_zipCode, Country.UK);
                        users.addPhone(ph_id, ph_areacode, ph_countryCode, ph_number);
                        users.addPerson(h_id, p_id, ph_id, p_fname, p_lname);
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
                Console.WriteLine("Doo you want to continue y\n");
                y = Convert.ToChar(Console.ReadLine());
                if (y != 'y')
                {
                    Console.WriteLine("Thank you for your time!\n");
                    Environment.Exit(0);
                }
            }//while close
               Console.ReadKey();
               #endregion
           }

       
        }
    }