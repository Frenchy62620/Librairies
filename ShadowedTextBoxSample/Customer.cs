namespace ShadowedTextBoxSample
{
    public class Customer
    {
        // If you really use this you'll want to make them DependencyProperties
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string JobTitle { get; set; }
        public string Company { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }


        // Get Stub Data
        public static Customer GetHomerSimpson
        {
            get
            {
                Customer customer = new Customer();

                customer.FirstName = "Homer";
                customer.MiddleName = "J";
                customer.LastName = "Simpson";

                customer.City = "Springfield";

                return customer;
            }
        }
    }
}
