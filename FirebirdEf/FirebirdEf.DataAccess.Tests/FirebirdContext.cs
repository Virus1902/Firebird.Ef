using System;
using System.Data.Entity;
using System.Linq;
using FirebirdEf.DataAccess.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirebirdEf.DataAccess.Tests
{
    [TestClass]
    public class FirebirdContextTests
    {
        private FirebirdContext _db;
        private DbContextTransaction _tran;

        [TestInitialize]
        public void TestStart()
        {
            _db = new FirebirdContext();
            _tran = _db.Database.BeginTransaction();
        }

        [TestMethod]
        public void SelectAllPerson()
        {
            var persons = _db.Persons.ToList();
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void AddPerson()
        {
            var newPerson = new Person()
            {
                FirstName = "Tadeusz",
                LastName = "Nowak"
            };
            _db.Persons.Add(newPerson);
            _db.SaveChanges();

            var persons = _db.Persons.ToList();

            Assert.IsTrue(persons.Any());
            Assert.IsTrue(persons.Contains(newPerson));
        }

        [TestMethod]
        public void UpdatePerson()
        {
            var newPerson = new Person()
            {
                FirstName = "Marek",
                LastName = "Kowalski"
            };

            _db.Persons.Add(newPerson);
            _db.SaveChanges();

            const string newLastName = "Nowak";

            newPerson.LastName = newLastName;
            _db.SaveChanges();

            var updatedPerson = _db.Persons.Single(x => x.Id == newPerson.Id);

            Assert.AreEqual(updatedPerson.LastName, newLastName);
        }

        [TestMethod]
        public void DeletePerson()
        {
            var newPerson = new Person()
            {
                FirstName = "Marek",
                LastName = "Kowalski"
            };

            _db.Persons.Add(newPerson);
            _db.SaveChanges();

            var persons = _db.Persons.ToList();
            var personsCount = persons.Count();

            _db.Persons.Remove(newPerson);
            _db.SaveChanges();

            persons.Clear();
            persons = _db.Persons.ToList();
            var personsCountAfterDelete = persons.Count();

            Assert.AreEqual(personsCount, personsCountAfterDelete + 1);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _tran.Rollback();
            _tran.Dispose();
            _db.Dispose();
        }
    }
}
