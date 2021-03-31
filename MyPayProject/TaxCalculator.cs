using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    /// <summary>
    /// This class is for calculating the tax based on the gross income that has passed as an argument.
    /// </summary>
    public class TaxCalculator
    {
        /// <summary>
        /// This method calculates the amount of tax for resident employees by the gross value that's been passed as an argument.
        /// </summary>
        /// <param name="gross">Gross income of a resident employee.</param>
        /// <returns>Returns the calculated tax - the data type is double.</returns>
        public static double CalculateResidentialTax(double gross)
        {
            double[] resiGrossArr = new double[7] { -1, 72, 361, 932, 1380, 3111, 999999 };
            double[] resiTaxRate = new double[6] { 0.19, 0.2342, 0.3477, 0.345, 0.39, 0.47 };
            double[] taxDeduc = new double[6] { 0.19, 3.213, 44.2476, 41.7311, 103.8657, 352.7888 };
            double resiTax = 0.0;

            for (int i = 0; i < resiGrossArr.Length; i++)
            {
                if (gross > resiGrossArr[i] && gross <= resiGrossArr[i + 1])
                {
                    resiTax = resiTaxRate[i] * gross - taxDeduc[i];
                }
            }
            return resiTax;
        }

        /// <summary>
        /// This method calculates the amount of tax for an employee that holds a working holiday visa.
        /// Gross value and year to date value has to be passed as an argument.
        /// </summary>
        /// <param name="gross">Gross income of a working holiday visa employee.</param>
        /// <param name="yearToDate">Year to date of a working holiday visa employee.</param>
        /// <returns>Returns the calculated tax - the data type is double.</returns>
        public static double CalculateWorkingHolidayTax(double gross, double yearToDate)
        {
            double[] holidayGrossArr = new double[5] { -1, 37000, 90000, 180000, 9999999 };
            double[] holidayTaxRate = new double[4] { 0.15, 0.32, 0.37, 0.45 };
            double totalGross = gross + yearToDate;
            double holidayTax = 0.0;

            for (int i = 0; i < holidayGrossArr.Length; i++)
            {
                if (totalGross > holidayGrossArr[i] && totalGross <= holidayGrossArr[i + 1])
                {
                    holidayTax = gross * holidayTaxRate[i];
                }
            }
            return holidayTax;
        }


        //static methods - no instance is needed because the return value doesn't depend on instatiated object. The equation will always be the same.
        //public static double CalculateResidentialTax(double gross)
        //{
        //    bool[] resiGrossRange = new bool[6] { gross > -1 && gross <= 72, gross > 72 && gross <= 361, gross > 361 && gross <= 932, gross > 932 && gross <= 1380, gross > 1380 && gross <= 3111, gross > 3111 && gross <= 999999 };
        //    double[] resiTaxRate = new double[6] { 0.19, 0.2342, 0.3477, 0.345, 0.39, 0.47 };
        //    double[] taxDeduc = new double[6] { 0.19, 3.213, 44.2476, 41.7311, 103.8657, 352.7888 };
        //    double resiTax = 0.0;

        //    for (int i = 0; i < resiTaxRate.Length; i++)
        //    {
        //        if (resiGrossRange[i] == true)
        //        {
        //            resiTax = resiTaxRate[i] * gross - taxDeduc[i];
        //        }
        //    }
        //    return resiTax;
        //}

        //public static double CalculateWorkingHolidayTax(double gross, double yearToDate)
        //{
        //    double totalGross = gross + yearToDate;
        //    bool[] holiGrossRange = new bool[4] { totalGross > -1 && totalGross <= 37000, totalGross > 37000 && totalGross <= 90000, totalGross > 90000 && totalGross <= 180000, totalGross > 180000 && totalGross <= 9999999 };
        //    double[] holidayTaxRate = new double[4] { 0.15, 0.32, 0.37, 0.45 };
        //    double holidayTax = 0.0;

        //    for (int i = 0; i < holidayTaxRate.Length; i++)
        //    {
        //        if (holiGrossRange[i] == true)
        //        {
        //            holidayTax = gross * holidayTaxRate[i];
        //        }
        //    }
        //    return holidayTax;
        //}


    }
}
