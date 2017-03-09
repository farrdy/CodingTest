using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaraiCSV
{
    static class AddressParseExtension
    {
        public static Address ParseAddress(this string address)
        {

            string[] stringAddress = address.Split(' ');
            int number;
            Int32.TryParse(stringAddress[0], out number);
            return new Address
            {
                Number = number,
                StreetName = string.Format(" {0} {1}", stringAddress[1], stringAddress[2])
            };

        }
    }
}
