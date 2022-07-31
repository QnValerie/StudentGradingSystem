using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Filestream
    {
        internal static string fileName = $"StudentGrades.txt";


        internal static void AppendFile(List<string> Studentnumber, List<string> Studentname, List<string> Gender, List<string> OOP, List<string> IM, List<string> HCI, List<string> NetAd, List<string> Integ)
        {


            using (StreamWriter file = File.AppendText(fileName))
            {

                WriteDataInFile(file, Studentnumber, Studentname, Gender, OOP, IM, HCI, NetAd, Integ);

            }

        }

        internal static void WriteDataInFile(StreamWriter file, List<string> Studentnumber, List<string> Studentname, List<string> Gender, List<string> OOP,List<string> IM, List<string> HCI, List<string> NetAd, List<string> Integ)
        {

            foreach (var data in Studentnumber)
            {

                if (data.Length == 0)
                {
                    file.Close();
                }
                else
                {
                    file.Write(data);
                    foreach (var data1 in Studentname)
                    {
                        file.Write($"\t\t{data1}");
                    }

                    foreach (var data2 in Gender)
                    {
                        file.Write($"\t\t{data2}");
                    }
                    foreach (var data3 in OOP)
                    {
                        file.Write($"\t\t{data3}\n");
                    }
                    foreach (var data4 in IM)
                    {
                        file.Write($"\t\t{data4}\n");
                    }
                    foreach (var data5 in HCI)
                    {
                        file.Write($"\t\t{data5}\n");
                    }
                    foreach (var data6 in NetAd )
                    {
                        file.Write($"\t\t{data6}\n");
                    }
                    foreach (var data7 in Integ)
                    {
                        file.Write($"\t\t{data7}\n");
                    }
                }


            }

        }


        internal static List<string> ReadFile()
        {
            List<string> dataContent = new List<string>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    dataContent.Add(line);
                    line = sr.ReadLine();

                }
            }

            return dataContent;
        }


        internal static void DisplayData()
        {
            List<string> dataContent = ReadFile();

            foreach (var data in dataContent)
            {
                Console.WriteLine(data);
            }
        }
    }
}

