using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagerApi.Models;

namespace ContactManagerApiTests.Data
{
    [TestClass]
    class ContactRepositoryTests
    {
        public LiteDatabase SetupTestDb()
        {
            var db = new LiteDatabase("Data/TestContactsDb");
            var col = db.GetCollection<Contact>("contacts");

            return db;
        }

    }
}
