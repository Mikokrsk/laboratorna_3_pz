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
        //правильний пін-код і номер картки
        [TestMethod()]
        public void checkTest1()
        {
            int card_number = 12345;
            int pin_code = 1234;
            bool expected;
            Form2 form = new Form2();
            expected = form.check(card_number, pin_code);
            Assert.IsTrue(expected);
        }
        
        //не правильний пін-код
        [TestMethod()]
        public void checkTest2()
        {
            int card_number = 12345;
            int pin_code = 1214433;
            bool expected;
            Form2 form = new Form2();
            expected = form.check(card_number, pin_code);
            Assert.IsFalse(expected);
        }
        //не правильний номер картки
        [TestMethod()]
        public void checkTest3()
        {
            int card_number = 12423451;
            int pin_code = 1234;
            bool expected;
            Form2 form = new Form2();
            expected = form.check(card_number, pin_code);
            Assert.IsFalse(expected);
        }
        //правильний добуток
        [TestMethod()]
        public void calculateTest1()
        {
            int price = 1000;
            int num = 5;
           int expected;
            Form1 form = new Form1();
            expected = form.calculate_total_sum(num,price);
            Assert.AreEqual(5000,expected);
        }

        //не правильний добуток  
        [TestMethod()]
        public void calculateTest2()
        {
            int price = 1000;
            int num = 6;
            int expected;
            Form1 form = new Form1();
            expected = form.calculate_total_sum(num, price);
            Assert.AreNotEqual(5000, expected);

        }
        //не правильний добуток
        [TestMethod()]
        public void calculateTest3()
        {
            int price = 235;
            int num = 5;
            int expected;
            Form1 form = new Form1();
            expected = form.calculate_total_sum(num, price);
            Assert.AreNotEqual(5000, expected);
        }

    }
}