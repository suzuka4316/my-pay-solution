using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MyPayProject
{
    /// <summary>
    /// This class is for importing a xml file that has each employee's data and 
    /// reshaping the data to calculate the gross and net income, and the tax.
    /// </summary>
    public class CsvImporter
    {
        /// <summary>
        /// This method is for reading a csv file line by line, 
        /// and reshaping the data so it can be used in PayRecord class to be calculated.
        /// This method is using a package called CsvHelper.
        /// </summary>
        /// <param name="file">A csv file that you want to read - currently the only file we have is employee-payroll-data.csv.</param>
        /// <returns>A list of information of each employee - an element contains id, gross, net, tax, array of hours, and array of rates,  
        /// if employee is a working holiday visa holder, then also visa number, and year to date. </returns>
        public static List<PayRecord> ImportPayRecords(string file)
        {
            List<PayRecord> records = new List<PayRecord>();

            try
            {
                StreamReader reader = new StreamReader(file);
                CsvReader csvR = new CsvReader(reader, CultureInfo.InvariantCulture);
                csvR.Read();
                csvR.ReadHeader();

                List<double> hourList = new List<double>();
                List<double> rateList = new List<double>();
                int prevId = -1;
                string prevVisa = "";
                string prevYtd = "";

                while (csvR.Read())
                {

                    int id = csvR.GetField<int>("EmployeeId");
                    string hour = csvR.GetField("Hours");
                    string rate = csvR.GetField("Rate");
                    string visa = csvR.GetField("Visa");
                    string ytd = csvR.GetField("YearToDate");

                    if (prevId != -1 && prevId != id)
                    {
                        PayRecord currRecord = CreatePayRecord(prevId, hourList.ToArray(), rateList.ToArray(), prevVisa, prevYtd);
                        hourList.Clear();
                        rateList.Clear();
                        records.Add(currRecord);
                    }

                    hourList.Add(double.Parse(hour));
                    rateList.Add(double.Parse(rate));

                    prevId = id;
                    prevVisa = visa;
                    prevYtd = ytd;
                }

                PayRecord lastRecord = CreatePayRecord(prevId, hourList.ToArray(), rateList.ToArray(), prevVisa, prevYtd);
                hourList.Clear();
                rateList.Clear();
                records.Add(lastRecord);

                reader.Dispose();
                csvR.Dispose();
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
            return records;
        }


        /// <summary>
        /// This method is called inside ImportPayRecords method once the method finish reading one employee's information.
        /// Those information is passed as arguments and this method checks if the visa number is an empty string or not.
        /// If not empty, then WorkingHolidayPayRecord object is instantiated, otherwise ResidentPayRecord object is instantiated.
        /// </summary>
        /// <returns>returns the object that has been instantiated</returns>
        public static PayRecord CreatePayRecord(int prevId, double[] hourList, double[] rateList, string prevVisa, string prevYtd)
        {
            if (prevVisa != "")
            {
                WorkingHolidayPayRecord e = new WorkingHolidayPayRecord(prevId, hourList, rateList, int.Parse(prevVisa), int.Parse(prevYtd));
                return e;
            }
            else
            {
                ResidentPayRecord e = new ResidentPayRecord(prevId, hourList, rateList);
                return e;
            }
        }


        //public static List<PayRecord> ImportPayRecords(string file)
        //{
        //    List<PayRecord> records = new List<PayRecord>();

        //    try
        //    {
        //        StreamReader reader = new StreamReader(file);
        //        reader.ReadLine();

        //        List<double> hourList = new List<double>();
        //        List<double> rateList = new List<double>();
        //        int prevId = -1;
        //        string prevVisa = "";
        //        string prevYtd = "";

        //        while (!reader.EndOfStream)
        //        {
        //            string line = reader.ReadLine();
        //            string[] lineItems = line.Split(',');

        //            int id = int.Parse(lineItems[0]);
        //            string hour = lineItems[1];
        //            string rate = lineItems[2];
        //            string visa = lineItems[3];
        //            string ytd = lineItems[4];

        //            if (prevId != -1 && prevId != id)
        //            {
        //                PayRecord currRecord = CreatePayRecord(prevId, hourList.ToArray(), rateList.ToArray(), prevVisa, prevYtd);
        //                hourList.Clear();
        //                rateList.Clear();
        //                records.Add(currRecord);
        //            }

        //            hourList.Add(double.Parse(hour));
        //            rateList.Add(double.Parse(rate));

        //            prevId = id;
        //            prevVisa = visa;
        //            prevYtd = ytd;
        //        }

        //        PayRecord lastRecord = CreatePayRecord(prevId, hourList.ToArray(), rateList.ToArray(), prevVisa, prevYtd);
        //        hourList.Clear();
        //        rateList.Clear();
        //        records.Add(lastRecord);

        //        reader.Dispose();
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("ERROR");
        //    }

        //    return records;
        //}

        //public static PayRecord CreatePayRecord(int prevId, double[] hourList, double[] rateList, string prevVisa, string prevYtd)
        //{
        //    if (prevVisa != "")
        //    {
        //        WorkingHolidayPayRecord e = new WorkingHolidayPayRecord(prevId, hourList, rateList, int.Parse(prevVisa), int.Parse(prevYtd));
        //        return e;
        //    }
        //    else
        //    {
        //        ResidentPayRecord e = new ResidentPayRecord(prevId, hourList, rateList);
        //        return e;
        //    }
        //}


    }
}
