using System.Collections.Generic;
using System.IO;

namespace DL_Lists
{
    class DLLists
    {
        private const string _fileName = @"C:\Users\mbm6415\source\Data\DL_Owners.txt";
        private const string _resultFileName = @"C:\Users\mbm6415\source\Data\InfoForComms.txt";

        static void Main()
        {
            Dictionary<string, string> dlPairs = GetDLsAndOwners(_fileName);
            WriteToFile(dlPairs, _resultFileName);
        }

        private static void WriteToFile(Dictionary<string, string> dlPairs, string fileName)
        {
            using (var writeDLtoCSV = new StreamWriter(fileName))
            {
                foreach (KeyValuePair<string, string> kvp in dlPairs)
                {
                    writeDLtoCSV.WriteLine("Owner: " + kvp.Value);
                    writeDLtoCSV.WriteLine("DL: " + kvp.Key);
                    writeDLtoCSV.WriteLine();
                }
                writeDLtoCSV.Close();
            }
        }

        private static Dictionary<string, string> GetDLsAndOwners(string fileName)
        {
            var dlPairs = new Dictionary<string, string>();

            dlPairs.ContainsKey("key");
            dlPairs.ContainsKey("value");

            // using statement for explicit disposing of unused objects
            using (var readDLfile = new StreamReader(fileName))
            {
                readDLfile.ReadLine(); // Skip first line (headers)
                while (!readDLfile.EndOfStream)
                {
                    string line = readDLfile.ReadLine();
                    string[] items = line.Split('\t');
                    dlPairs.Add(items[0], items[1]);
                }
                readDLfile.Close();
            }
            return dlPairs;
        }
    }
}
