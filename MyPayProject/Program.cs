using System;
using System.IO;
using System.Collections.Generic;



namespace MyPayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calling a static method - className.methodName

            //Calling ImportPayRecords method with a file name as an argument - this is for reading the csv data.
            List<PayRecord> myRecordList = CsvImporter.ImportPayRecords("../../Import/employee-payroll-data.csv");

            //Calling Write method with three arguments which are a file name, list of PayRecord objects, and boolean(optional).
            //This method creates a file and write the calculated data.
            //With the boolean argument true, you can see the calculation result on the output window.
            PayRecordWriter.Write($"{DateTime.Now.Ticks}-records.csv", myRecordList, true);



            //Manual testing two methods of TaxCalculator class.
            //Console.WriteLine(TaxCalculator.CalculateResidentialTax(652));
            //Console.WriteLine(TaxCalculator.CalculateWorkingHolidayTax(418, 47938));

            /*Manual testing 3 classes (PayRecord, ResidentPayRecord, and WorkingHolidayPayRecord)
             * by instantiating each object.*/
            //ResidentPayRecord employee1 = new ResidentPayRecord(1, new double[6] { 2, 3, 3, 4, 5, 6 }, new double[6] { 25, 25, 25, 25, 32, 32 });
            //WorkingHolidayPayRecord employee2 = new WorkingHolidayPayRecord(2, new double[8] { 2, 2, 2, 2, 2, 2, 2, 2 }, new double[8] { 25, 25, 25, 25, 25, 28, 28, 28 }, 417, 47520);
            //ResidentPayRecord employee3 = new ResidentPayRecord(3, new double[8] { 8, 8, 8, 8, 8, 8, 6, 6 }, new double[8] { 36, 36, 36, 36, 37.5, 37.5, 37.5, 37.5 });
            //WorkingHolidayPayRecord employee4 = new WorkingHolidayPayRecord(4, new double[7] { 5, 5, 5, 5, 5, 5, 2 }, new double[7] { 34.5, 34.5, 34.5, 34.5, 34.5, 34.5, 34.5 }, 462, 23000);
            //ResidentPayRecord employee5 = new ResidentPayRecord(5, new double[7] { 7, 6.5, 7, 7, 7, 3, 3 }, new double[7] { 42.5, 42.5, 42.5, 42.5, 42.5, 55.2, 55.2 });
            //Console.WriteLine(employee1.GetDetails());
            //Console.WriteLine(employee2.GetDetails());
            //Console.WriteLine(employee3.GetDetails());
            //Console.WriteLine(employee4.GetDetails());
            //Console.WriteLine(employee5.GetDetails());

            //Manual testing CsvImporter class
            //List<PayRecord> myRecordList = CsvImporter.ImportPayRecords("../../Import/employee-payroll-data.csv");
            //foreach (var r in myRecordList)
            //{
            //    Console.WriteLine(r.GetDetails());
            //}


            Console.ReadKey();

        }

    }
}
