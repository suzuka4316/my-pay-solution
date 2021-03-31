using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace MyPayProject
{
    /// <summary>
    /// This class is to write each employee's data in a csv file.
    /// </summary>
    public class PayRecordWriter
    {
        /// <summary>
        /// This method is to write the result of calculation(id, gross, tax, net) for each employee in a file.
        /// It takes three parameters.
        /// The file will be created inside the bin folder of this project if not specified the path of the file.
        /// This method is using a package called CsvHelper.
        /// </summary>
        /// <param name="file">Name of a file that you want to create to write in.</param>
        /// <param name="data">List of employees' data.</param>
        /// <param name="writeToConsole">This boolean(true or false) is optional, and it is for displaying the result on the output window.</param>
        public static void Write(string file, List<PayRecord> data, bool writeToConsole = false)
        {
            StreamWriter writer = new StreamWriter(file);
            CsvWriter csvW = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvW.WriteRecords(data);

            if (writeToConsole == true)
            {
                foreach (PayRecord r in data)
                {
                    Console.WriteLine($"{r.GetDetails()}");
                }
            }
            writer.Dispose();
            csvW.Dispose();
        }
    }
}
