

using System;
using System.Collections.Generic;
using System.IO;

namespace DL_Lists
{
    class DLLists
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dlPairs = DLsAndOwners<string, string>(); //method to read from txt file and create pairs of DLs and DL Owners
            StreamWriter writeDLtoCSV = new StreamWriter(@"C:\Users\mbm6415\source\Data\DL_Owners.txt"); // Question: don't know how to create method for writing to file
            foreach (var kvp in dlPairs) // Question: kvp type is KeyValuePair, but when I specify it, code doesn't work, it works with var. What type should be specified for kvp?
            {
                writeDLtoCSV.WriteLine("Owner: " + kvp.Value);
                writeDLtoCSV.WriteLine("DL: " + kvp.Key);
                writeDLtoCSV.WriteLine();
            }

            writeDLtoCSV.Close(); // Question: is there an easy way to get rid of headers or first line in the file?
        }

        private static Dictionary<string, string> DLsAndOwners<T1, T2>()
        {
            Dictionary<string, string> dlPairs = new Dictionary<string, string>();
            StreamReader readDLfile = new StreamReader(@"C:\Users\mbm6415\source\Data\InfoForComms.txt");
            while (readDLfile.EndOfStream == false)
            {
                string line = readDLfile.ReadLine();
                string[] items = line.Split('\t');
                dlPairs.Add(items[0], items[1]);
            }
            readDLfile.Close();
            return dlPairs;
        }
    }
}
