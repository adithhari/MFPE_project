using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using InventoryManagement.Domain;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Domain.Tests
{
    public class CustomerEntityShould
    {
        [Test]
        public void Create_NewCustomer_ViaConstructor()
        {
            //Arrange
            string Fullname = "Revathy";
            string PhoneNumber = "9765329870";
            string Address = "Avadi";

            //Act
            var customer = new Customer(Fullname, PhoneNumber, Address);

            //Assert
            Assert.That(customer, Is.Not.Null);
            Assert.That(customer, Is.InstanceOf<Customer>());
            Assert.That(customer.Fullname, Is.EqualTo(Fullname));
            Assert.That(customer.PhoneNumber, Is.EqualTo(PhoneNumber));
            Assert.That(customer.Address, Is.EqualTo(Address));
        }
    }
}
