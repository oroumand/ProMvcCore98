using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Session14.Models.Models
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
        [BindNever]
        public string NeverUpdate { get; set; }
        
    }
}
