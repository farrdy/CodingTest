using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaraiCSV
{
    public class Address : IComparable<Address>
    {
        public int Number { get; set; }
        public string StreetName { get; set; }

        public int CompareTo(Address other)
        {
            return this.StreetName.CompareTo(other.StreetName);
        }
        
        public int GetHashCode(Address address)
        {           
            if (Object.ReferenceEquals(address, null))
                return 0;

            int hashAddressStreetname = address.StreetName == null ? 0 : address.StreetName.GetHashCode();
            
            return hashAddressStreetname;
        }
    }
}
