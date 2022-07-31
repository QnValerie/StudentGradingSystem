using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer
{
    internal class DataValidator
    {
        public static List<string> Studentnumber()
        {
            List<string> dataList = new List<string>();
            string studentnumber;
            do
            {

                Console.Write("\n\t\t\t\tStudent Number : ");
                studentnumber = Console.ReadLine();

                if (studentnumber.Length == 15 && studentnumber.StartsWith("20") && studentnumber.EndsWith("BN-0"))
                {
                    dataList.Add(studentnumber);
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t\t\tInvalid Input");

                }
                Console.ReadLine();
                Console.Clear();

            } while (studentnumber.Length != 0);

            return dataList;

        }

    }
}
