﻿#nullable enable

namespace LanguageFeatures.Cs8
{
    public class Address
    {
        public void Test()
        {
            var addr = Factory();
            Console.WriteLine(addr.Address2.Trim());
        }

        public static Address Factory()
        {
            return new Address("Microsoft", "Alphretta", "GA", null);
        }

        public string Address1 { get; set; }
        public string Address2 { get; set; } // Compiler warning because value is not set in constructor
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Address(string addr1, string city, string state, string zip)
        {
            Address1 = addr1;
            //Address2 = "";
            City = city;
            State = state;
            Zip = zip ?? "";
        }
    }
}
