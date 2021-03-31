using System;
using NUnit.Framework;
using MyPayProject;
using System.Collections.Generic;
using System.IO;

namespace MyPayNUnitTestProject
{
    public class Tests
    {
        private List<PayRecord> _records = null;

        [SetUp]
        public void SetUp()
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            _records = CsvImporter.ImportPayRecords(path + "/import/employee-payroll-data.csv");
        }

        [Test]
        public void TestImport()
        {
            //_records field is not null and contains five objects
            Assert.IsNotNull(_records);
            Assert.AreEqual(5, _records.Count);
        }

        [Test]
        public void TestGross()
        {
            //Gross amount calculated for each employee is correct
            double[] expectedGross = new double[5] { 652, 418, 2202, 1104, 1797.4499999999998 };
            for (int i = 0; i < expectedGross.Length; i++)
            {
                Assert.AreEqual(expectedGross[i], _records[i].Gross);
            }
        }

        [Test]
        public void TestTax()
        {
            //Tax amount calculated for each employee is correct
            double[] expectedTax = new double[5] { 182.4528, 133.76, 754.91429999999991, 165.6, 597.13979999999992 };
            for (int i = 0; i < expectedTax.Length; i++)
            {
                Assert.AreEqual(expectedTax[i], _records[i].Tax);
            }
        }

        [Test]
        public void TestNet()
        {
            //Net amount calculated for each employee is correct
            double[] expectedNet = new double[5] { 469.5472, 284.24, 1447.08570000000009, 938.4, 1200.31019999999988 };
            for (int i = 0; i < expectedNet.Length; i++)
            {
                Assert.AreEqual(expectedNet[i], _records[i].Net);
            }
        }

        [Test]
        public void TestExport()
        {
            //writer successfully writes a file to the export folder by checking if the file exists
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            PayRecordWriter.Write(path + "../../Export/exportData.csv", _records);
            bool exists = File.Exists(path + "../../Export/exportData.csv");
            Assert.IsTrue(exists);
        }
    }
}
