using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    /// <summary>
    /// This class is for Australian workers. It is a subclass of PayRecord class.
    /// </summary>
    public class ResidentPayRecord : PayRecord
    {
        /// <summary>
        /// Auto property that overrides the Tax property in PayRecord class (base class).
        /// This get method is returning a tax value by calling CalculateResidentialTax method in TaxCalculator class.
        /// </summary>
        public override double Tax 
        {
            get
            {
                return TaxCalculator.CalculateResidentialTax(Gross);
            }
        }

        /// <summary>
        /// Constructor that passes id, hours, and rates values to the PayRecord constructor.
        /// When a new object of this ResidentPayRecord class is instantiated, 
        /// the compiler will run this constructor and pass the three arguments to the base class constructor.
        /// </summary>
        public ResidentPayRecord(int id, double[] hours, double[] rates) : base(id, hours, rates) { }


        /// <summary>
        /// Method to display the details of a resident employee
        /// Base class method GetDetails() is overridden.
        /// </summary>
        /// <returns>Information of id, calculated gross, net, and tax - returns string data type.</returns>
        public override string GetDetails()
        {
            return base.GetDetails();
        }
    }
}
