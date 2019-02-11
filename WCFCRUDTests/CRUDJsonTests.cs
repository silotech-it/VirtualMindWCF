using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFCRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFCRUD;

namespace WCFCRUD.Tests
{
    [TestClass()]
    public class CRUDJsonTests
    {
        [TestMethod()]
        public void FindTest()
        {
            ICRUDJson rec = new CRUDJson();
            string id = rec.FindAll().FirstOrDefault()?.id.ToString();
            var data = rec.Find(id);
            Assert.IsTrue(data.id > 0);
        }
    }
}