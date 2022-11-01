using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_3_pz_framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using lab_3_pz_framework;


namespace lab_3_pz_framework.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void summaTest1()
        {
            int x = 5;
            int y = 10;
            int z = 15;
            int result;
            var form = new Form1();

            result= form.summa(x, y); 

            Assert.AreEqual(result,15);
        }  
        [TestMethod()]
        public void summaTest2()
        {
            int x = 5;
            int y = 10;
            int z = 15;
            int result;
            var form = new Form1();

            result= form.summa(x, y); 

            Assert.AreEqual(result,z);
        }
    }
}