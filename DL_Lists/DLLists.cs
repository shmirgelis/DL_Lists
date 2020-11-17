

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DL_Lists
{
    class DLLists
    {
        public const string filePathReader = @"C:\Users\mbm6415\source\Data\InfoForComms.txt";
        public const string filePathWriter = @"C:\Users\mbm6415\source\Data\TransformedDLs.txt";
        static void Main(string[] args)
        {
            var dlsOwners = ReadInDLsAndOwners(); //method to read from txt file and create pairs of DLs and DL Owners
            using (StreamWriter writeDLtoCSV = new StreamWriter(filePathWriter)) 
            foreach (var kvp in dlsOwners) 
            {
                List<string> valuesList = kvp.Value;
                string joinValues = string.Join(", ", valuesList);
                writeDLtoCSV.WriteLine(string.Format("{0, -50}{1, 0}" , kvp.Key, joinValues));
            }
        }
              
        private static Dictionary<string, List<string>> ReadInDLsAndOwners()
        {
            var dlPairs = new Dictionary<string, List<string>>();
            using (StreamReader readDLfile = new StreamReader(filePathReader))
            {
                readDLfile.ReadLine();
                while (!readDLfile.EndOfStream)
                {
                    string line = readDLfile.ReadLine();
                    string[] items = line.Split('\t',',');
                    for(int i = 1; i < items.Length; i++)
                    {
                        if (dlPairs.ContainsKey(items[i]))
                        {
                            dlPairs[items[i]].Add(items[0]);
                        }
                        else
                        {
                            var valueList = new List<string>();
                            valueList.Add(items[0]);
                            dlPairs.Add(items[i], valueList);
                        }
                    }
                }
                return dlPairs;
            }
          
        }
    }
}
