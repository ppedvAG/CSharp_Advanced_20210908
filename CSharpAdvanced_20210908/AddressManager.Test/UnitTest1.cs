using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AddressManager.Test
{
    [TestClass]
    public class UnitTest1
    {

        private AddressBook _addressBook;

        [TestInitialize]
        public void Initialize()
        {
            _addressBook = new AddressBook();
        }

        

        [TestMethod]
        public void TestInsertAddress()
        {
            Address address = new Address();
            address.Id = 1;
            address.Name = "Gottschalk";
            address.Street = "Gotschalk Allee";
            address.PostalCode = "12345";
            address.Place = "Berlin";


            Address address1 = new Address();
            address.Id = 1;
            address.Name = "Gottschalk";
            address.Street = "Gotschalk Allee";
            address.PostalCode = "12345";
            address.Place = "Berlin";


            //Unit Test für Insert Methode
            _addressBook.Insert(address);


            Address readedAddress = _addressBook.Addresses.SingleOrDefault(s => s.Id == 1);

            //Assert.AreEqual(address, readedAddress);
            Assert.AreSame(address, readedAddress);
        }


        [TestMethod]
        public void TestDeleteAddress()
        {
            Address address = new Address();
            address.Id = 1;
            address.Name = "Gottschalk";
            address.Street = "Gotschalk Allee";
            address.PostalCode = "12345";
            address.Place = "Berlin";

            _addressBook.Insert(address);


            _addressBook.Delete(address.Id);


            //Wenn Datensatz nicht gefunden wird, ist durch SingleOrDefault die readedAddress.Id = 0
            Address readedAddress = _addressBook.Addresses.SingleOrDefault(a => a.Id == address.Id);

            //gelöschter Datensatz wird auf null geprüft. 
            Assert.AreEqual(readedAddress, null);

           
            //Assert.AreNotEqual(readedAddress.Id, address);
        }
    }
}
