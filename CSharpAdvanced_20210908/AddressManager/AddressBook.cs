using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManager
{
    public class AddressBook
    {
        private IList<Address> addresses = new List<Address>();

        public IList<Address> Addresses
        {
            get
            {
                return addresses;
            }

            set
            {
                addresses = value;
            }
        }


        public AddressBook()
        {

        }


        public void Insert(Address newAddress)
        {
            Addresses.Add(newAddress);
        }

        public void Delete (int Id)
        {
            Address toDelete = Addresses.Single(a => a.Id == Id);
            Addresses.Remove(toDelete);
        }
    }
}
