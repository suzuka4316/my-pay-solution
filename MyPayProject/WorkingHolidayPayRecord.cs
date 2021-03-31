using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyPayProject
{
    /// <summary>
    /// This class is for workers that hold working holiday visa. It is a subclass of PayRecord class.
    /// </summary>
    public class WorkingHolidayPayRecord : PayRecord
    {
        /// <summary>
        /// Auto property that returns a tax value by calling CalculateWorkingHolidayTax method from TaxCalculator class.
        /// </summary>
        public override double Tax
        { 
            get
            {
                return TaxCalculator.CalculateWorkingHolidayTax(Gross, YearToDate);
            }
        }

        /// <summary>
        /// Auto property to set a visa value only from inside this WorkingHolidayPayRecord class, and to get the value.
        /// </summary>
        public int Visa { get; private set; }

        /// <summary>
        /// Auto property to set a year-to-date value only from inside this class, and to get the value.
        /// </summary>
        public int YearToDate { get; private set; }


        /// <summary>
        /// Constructor method that passes the id, hours, and rates values to the base class constructor,
        /// and initializes the visa and year to date values.
        /// </summary>
        /// <param name="id">Each employee's id.</param>
        /// <param name="hours">Collection of hours the employee has worked.</param>
        /// <param name="rates">Collection of rates per hour.</param>
        /// <param name="visa">Employee's visa number.</param>
        /// <param name="yearToDate">Employee's year to date value.</param>
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base(id, hours, rates)
        {
            Visa = visa;
            YearToDate = yearToDate + (int)Gross;
        }


        /// <summary>
        /// Method to display the details of a working holiday employee.
        /// The GetDetails method of the base class is overridden and additional information is added.
        /// </summary>
        /// <returns>Information of id, calculated gross, net, tax, and visa number and year to date value - returns string data type.</returns>
        public override string GetDetails()
        {
            return $"{base.GetDetails()}" +
                $"VISA:\t{Visa}\n" +
                $"YTD:\t{String.Format("{0:C}", YearToDate)}\n";
        }
    }
}
