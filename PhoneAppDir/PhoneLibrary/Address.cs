namespace PhoneLibrary
{
    public class Address
    {
        public int pid { get; set; }
        public string houseNo { get; set; }
        public string streetName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public Country country { get; set; }
    }
}