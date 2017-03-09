using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaraiCSV
{
    /// <summary>
    /// Contact Class
    /// </summary>
   public  class Contact : IEquatable<Contact>
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }

        public bool Equals(Contact other)
        {
            if (other == null)
                return false;
            else
                return object.ReferenceEquals(this.FirstName, other.FirstName) ||
                 this.FirstName != null &&
                 this.FirstName.Equals(other.FirstName);

        }
        public int GetHashCode(Contact contact)
        {
            if (Object.ReferenceEquals(contact, null))
                return 0;

            int hashContact = contact.FirstName == null ? 0 : contact.FirstName.GetHashCode();

            return hashContact;
        }
    }
}
