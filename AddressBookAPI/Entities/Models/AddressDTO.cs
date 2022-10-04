namespace AddressBookAPI.Entities.Models
{
    public class AddressDTO
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }
        public Type Type { get; set; }
        public Type Country { get; set; }
    }
}
