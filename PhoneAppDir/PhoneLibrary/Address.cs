namespace PhoneContactLibrary
{
    public class Address
    {
        public long Pid { get; set; }
        public string houseNo { get; set; }
        public string streetName { get; set; }
        public string city { get; set; }
        public State State { get; set; }
        public string zipCode { get; set; }
        public Country Country { get; set; }
    }
}