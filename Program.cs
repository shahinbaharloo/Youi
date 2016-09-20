using System;
using System.IO;
using Youi.BusinessLogic;
using Youi.FileReader;

namespace Youi
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            CSVReader reader = new CSVReader();
            Methods sort = new Methods();


            while (true)
            {
                
                Console.WriteLine("1.Show the frequency of the first and last names ordered by frequency and then alphabetically.");
                Console.WriteLine("2.Show the addresses sorted alphabetically by street name.");
                Console.WriteLine("3.Quit");

                Console.WriteLine("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 3)
                    break;
                try
                {
                    switch (choice)
                {
                    case 1:
                            System.Console.WriteLine("Process started");
                            FileWriter.Writers.WriteFrFirstAndLastNameToOutputTXTFile(reader.ReadValues());
                            System.Console.WriteLine("Process completed");
                            break;
                    case 2:
                            System.Console.WriteLine("Process started");
                            FileWriter.Writers.WriteAddressToOutputTXTFile(sort.SortAddresses(reader.ReadValues()));
                            System.Console.WriteLine("Process completed");
                            break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;

                }
                }

                catch (DirectoryNotFoundException dirEx)
                {
                    System.Console.Error.WriteLine("Directory not found: " + dirEx.Message);
                    System.Console.WriteLine("press q to quit. any other key to try again.");
                    var key = System.Console.ReadKey(true);
                    if (key.KeyChar == 'q' || key.KeyChar == 'Q') break;
                }
                catch (Exception e)
                {
                    System.Console.Error.WriteLine(e.Message);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Existing");
        }
    }
}
