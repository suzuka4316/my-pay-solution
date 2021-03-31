using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{   
    /// <summary>
    /// The base abstract class of the two other Record classes. (ResidentPayRecord, WorkingHolidayPayRecord)
    /// </summary>
    /// <remarks>
    /// This class is used for each employee's data, which are an array of hours/rates, id, gross, tax, net.
    /// </remarks>
    public abstract class PayRecord
    {
        /// <summary>
        /// A field for an array of each employee's working hours.
        /// </summary>
        protected double[] hours;
        /// <summary>
        /// A field for an array of each employee's rate per hour.
        /// </summary>
        protected double[] rates;
        
        /// <summary>
        /// Auto property to set an id value only from inside this PayRecord class, and to get the value.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Auto property to get a gross value. It is read-only.
        /// </summary>
        public double Gross { get; }

        /// <summary>
        /// Auto property to get a tax value. It is read-only.
        /// Cannot calculate the tax at this point yet because there are two type of employee, hence the abstract.
        /// Modifier of this class must also be abstract because of this property.
        /// </summary>
        public abstract double Tax { get; }

        /// <summary>
        /// Auto property to get a net value. It is read-only.
        /// Substract a tax value from a gross income.
        /// </summary>
        public double Net
        {
            get
            {
                return Gross - Tax;
            }
        }


        /// <summary>
        /// Method (constructor) that intializes the fields values above.
        /// </summary>
        /// <param name="id">Each employee's id.</param>
        /// <param name="hours">Collection of hours the employee has worked.</param>
        /// <param name="rates">Collection of rates per hour.</param>
        public PayRecord(int id, double[] hours, double[] rates)
        {
            Id = id;
            this.hours = hours;
            this.rates = rates;

            //Not writing this to Gross property because you cannot assign a value to it.
            for (int i = 0; i < hours.Length; i++)
            {
                Gross += hours[i] * rates[i];
            }
        }

        /// <summary>
        /// Method to display the details of an employee.
        /// </summary>
        /// <returns>Information of id, calculated gross, net, and tax - returns string data type.</returns>
        public virtual string GetDetails()
        {
            return $" ---------- EMPLOYEE: {Id} ----------\n" +
                $"GROSS:\t{String.Format("{0:C}", Gross)}\n" +
                $"NET:\t{String.Format("{0:C}", Net)}\n" +
                $"TAX:\t{String.Format("{0:C}", Tax)}\n";
        }
    }
}
