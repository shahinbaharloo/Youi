using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Youi.Model;

namespace Youi.FileWriter
{
    class Writers
    {

        public static void WriteAddressToOutputTXTFile(List<string> List)
        {

            List<string> Lines = new List<string>();
            string Header = "Addresses";
            Lines.Add(Header);

            Lines.AddRange(List);

            string outputFilePath = ConfigurationManager.AppSettings["OutputAddresses"];
            using (System.IO.StreamWriter outputFile =
            new System.IO.StreamWriter(outputFilePath, true))
            {
                foreach (string line in Lines)
                    outputFile.WriteLine(line);
            }
        }



        public static void WriteFrFirstAndLastNameToOutputTXTFile(List<AllValuesToProcess> AllValues)
        {
            List<OutputFrFirstLastNames> List = new List<OutputFrFirstLastNames>();
            List<string> Lines = new List<string>();
            string Delimeter = ",";
            string FirstNameHeader = "FirstName";
            string LastNameHeader = "LastName";
            string FrequencyHeader = "Frequency";

            List.AddRange
                (

            AllValues

            .GroupBy(x => new
            {
                x.FirstName,
                x.LastName
            })
            .Select(t => new OutputFrFirstLastNames
            {
                FirstName = t.Key.FirstName,
                LastName = t.Key.LastName,
                Frequency = t.Count()
            })
                .OrderBy(x => x.Frequency
                
                )
                .OrderBy(x => x.FirstName
                ));

            Lines.Add(FirstNameHeader + Delimeter + LastNameHeader + Delimeter + FrequencyHeader);

            foreach (var output in List)
            {
                Lines.Add(output.FirstName + Delimeter + output.LastName + Delimeter + output.Frequency.ToString() );
            }

            string outputFilePath = ConfigurationManager.AppSettings["OutputFrequencyFirstLastNamePath"];
            using (System.IO.StreamWriter outputFile =
            new System.IO.StreamWriter(outputFilePath, true))
            {
                foreach (string line in Lines)
                    outputFile.WriteLine(line);
            }
        }

    }
}
