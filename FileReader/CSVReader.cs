using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

using Youi.Model;

namespace Youi.FileReader
{
    class CSVReader
    {
        public List<AllValuesToProcess> values;
        public CSVReader()
        {
            values = new List<AllValuesToProcess>();
        }

        public List<AllValuesToProcess> ReadValues()
        {

            string[] allLines = File.ReadAllLines(ConfigurationManager.AppSettings["InputFilePath"]).Skip(1).ToArray();

            var query = from line in allLines

                        let data = line.Split(',')

                        select new

                        {

                            FirstName = data[0],
                            LastName = data[1],
                            Address = data[2],
                            PhoneNumber = data[3]

                        };


            foreach (var s in query)

            {

                values.Add(
                    new AllValuesToProcess(
                        s.FirstName,
                        s.LastName,
                        s.Address,
                        s.PhoneNumber,
                        s.Address.Split(' ')[1]
                    )
                    );

            }
            return values;
        }
    }
}
