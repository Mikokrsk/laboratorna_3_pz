using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laboratorna_3_pz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_3_pz.Tests
{
    [TestClass()]
    public class Form2Tests
    {
        [TestMethod()]
        public void checkTest1()
        {
            int card = 12345;
            int code = 1234;
            bool expected;
            Form2 form = new Form2();
            expected = form.check(card, code);
            Assert.IsTrue(expected);
        }
        [TestMethod()]
        public void checkTest2()
        {
            int card = 12345;
            int code = 1214433;
            bool expected;
            Form2 form = new Form2();
            expected = form.check(card, code);
            Assert.IsFalse(expected);
        }
        [TestMethod()]
        public void checkTest3()
        {
            int card = 12423451;
            int code = 1234;
            bool expected;
            Form2 form = new Form2();
            expected = form.check(card, code);
            Assert.IsFalse(expected);
        }


    }
}