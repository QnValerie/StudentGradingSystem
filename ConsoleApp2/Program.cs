using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
{
    //Declare student structure
    struct student
    {
        public string studentnumber;
        public string studentname;
        public string Gender;
        public float OOP;
        public float IM;
        public float HCI;
        public float NetAd;
        public float Integ;
        public float total;
    };

    //main method
    static void Main(string[] args)
    {
        const int MAX = 30;//create an array to store only 30 students
        try
        {
            student[] st = new student[MAX];
            int itemcount = 0;
            int choice;
            string confirm;

            do
            {     //show menu
                 displaymenu();
                Console.Write("Enter your choice(1-5):");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        add(st, ref itemcount);
                        break;
                    case 2:
                        delete(st, ref itemcount);
                        break;
                    case 3:
                        update(st, itemcount);
                        break;
                    case 4:
                        viewall(st, itemcount);
                        break;
                    case 5:
                        find(st, itemcount);
                        break;
                    default:
                        Console.WriteLine("invalid");
                        break;
                }

                Console.Write("Press y or Y to continue:");
                confirm = Console.ReadLine().ToString();
                Console.Clear();
            } while (confirm == "y" || confirm == "Y");
        }
        catch (FormatException) { Console.WriteLine("Invalid input"); }
        Console.ReadLine();
    }

    static void displaymenu()
    {

        Console.WriteLine("======================================================\n                         MENU                         \n======================================================");
        Console.WriteLine(" 1.Add student records");
        Console.WriteLine(" 2.Delete student records");
        Console.WriteLine(" 5.Find a student by Students Number");
        Console.WriteLine("******************************************************\n");
    }

    //method add/append a new record
    static void add(student[] st, ref int itemcount)
    {

    Again:
        Console.WriteLine("======================================================\n            ADDING STUDENTS DATA/INFORMATION                         \n======================================================");
        Console.Write("Enter student's Number:");
        st[itemcount].studentnumber = Console.ReadLine().ToString();

        if (search(st, st[itemcount].studentnumber, itemcount) != -1)
        {
            Console.Clear();
            Console.WriteLine("The Students Number you Enter already exists.");
            goto Again;

        }
        Console.Write("Enter student's NAME:");
        st[itemcount].studentname = Console.ReadLine().ToString();
        Console.Write("Enter student's GENDER(F or M):");
        st[itemcount].Gender = Console.ReadLine().ToString();
        Console.Write("Enter student's OBJECT ORIENTED PROGRAMMING Grade:");
        st[itemcount].OOP = float.Parse(Console.ReadLine());
        Console.Write("Enter student's INFORMATION MANAGEMENT Grade:");
        st[itemcount].IM = float.Parse(Console.ReadLine());
        Console.Write("Enter student's HUMAN COMPUTER INTERACTION Grade:");
        st[itemcount].HCI = float.Parse(Console.ReadLine());
        Console.Write("Enter student's NETWORK ADMINISTRATION Grade:");
        st[itemcount].NetAd = float.Parse(Console.ReadLine());
        Console.Write("Enter student's INTEGRATIVE PROGRAMMING Grade:");
        st[itemcount].Integ = float.Parse(Console.ReadLine());
        st[itemcount].total = st[itemcount].OOP + st[itemcount].IM + st[itemcount].HCI + st[itemcount].NetAd + st[itemcount].Integ;
        ++itemcount;

    }

    //DELETING DATA OF STUDENTS
    static void delete(student[] st, ref int itemcount)
    {
        string studentnumber;
        int index;
        if (itemcount > 0)
        {
            Console.WriteLine("======================================================\n         DELETING STUDENTS DATA/INFORMATION                         \n======================================================");
            Console.Write("Enter student's Number:");
            studentnumber = Console.ReadLine();
            index = search(st, studentnumber.ToString(), itemcount);

            if ((index != -1) && (itemcount != 0))
            {
                if (index == (itemcount - 1))
                {

                    clean(st, index);
                    --itemcount;

                    Console.WriteLine("The record was deleted.");
                }
                else
                {
                    for (int i = index; i < itemcount - 1; i++)
                    {
                        st[i] = st[i + 1];
                        clean(st, itemcount);
                        --itemcount;
                    }
                }
            }
            else Console.WriteLine("The record doesn't exist.Check the Student Number and try again.");
        }
        else Console.WriteLine("No record to delete");
    }

    //UPDATE DATA OF STUDENTS
    static void update(student[] st, int itemcount)
    {
        string studentnumber;
        int column_index;
        Console.WriteLine("==========================================================\n           UPDATE STUDENTS DATA/GRADES                        \n===========================================================");
        Console.Write("Enter student's Number:");
        studentnumber = Console.ReadLine();
        Console.WriteLine("Which field you want to update(1-7)?:");
        Console.WriteLine("1: Student's Name");
        Console.WriteLine("2: Student's Gender of Student");
        Console.WriteLine("3: Student's OBJECT ORIENTED PROGRAMMING Grade");
        Console.WriteLine("4: Student's INFORMATION MANAGEMENT Grade");
        Console.WriteLine("5: Student's HUMAN COMPUTER INTERACTION Grade");
        Console.WriteLine("6: Student's NETWORK ADMINISTRATION Grade");
        Console.WriteLine("7: Student's INTEGRATIVE PROGRAMMING");
        Console.WriteLine("******************************************************\n");
        column_index = int.Parse(Console.ReadLine());
        int index = search(st, studentnumber.ToString(), itemcount);
        if ((index != -1) && (itemcount != 0))
        {
            if (column_index == 1)
            {
                Console.Write("Enter student's NAME:");
                st[index].studentname = Console.ReadLine().ToString();
            }

            else if (column_index == 2)
            {
                Console.Write("Enter student's GENDER(F or M):");
                st[index].Gender = Console.ReadLine().ToString();
            }
            else if (column_index == 3)
            {
                Console.Write("Enter student's OBJECT ORIENTED PROGRAMMING GRADE:");
                st[index].OOP = float.Parse(Console.ReadLine());
            }
            else if (column_index == 4)
            {
                Console.Write("Enter student's INFORMATION MANAGEMENT GRADE:");
                st[index].IM = float.Parse(Console.ReadLine());
            }
            else if (column_index == 5)
            {
                Console.Write("Enter student's HUMAN CXOMPUTER INTERACTION GRADE:");
                st[index].HCI = float.Parse(Console.ReadLine());
            }
            else if (column_index == 6)
            {
                Console.Write("Enter student's NETWORK ADMINISTRATION GRADE:");
                st[index].NetAd = float.Parse(Console.ReadLine());
            }
            else if (column_index == 7)
            {
                Console.Write("Enter student's INTEGRATIVE PROGRAMMING GRADE:");
                st[index].Integ = float.Parse(Console.ReadLine());
            }
            else Console.WriteLine("Invalid column index");
            st[index].total = st[index].OOP + st[index].IM + st[index].HCI + st[index].NetAd + st[index].Integ;
        }
        else Console.WriteLine("The record deosn't exits.Check the Student n and try again.");

    }

    //VIEWING ALL DATA OF STUDENTS
    static void viewall(student[] st, int itemcount)
    {

        int i = 0;
        Console.WriteLine("========================================================================================================================\n                                           STUDENTS INFORMATION AND GRADING SYSTEM         \n=========================================================================================================================");
     
        Console.WriteLine("_______________________________________________________________________________________________________________________");
        Console.WriteLine("{0,-15}\t{1,-20}\t {2,-9}{3,-5} {4,-5} \t{5,-9}{6,-5} {7,-5}\t \t{8,-4}", "STUDENT NUMBER", "NAME", "GENDER", "OOP", "IM", "HCI", "NET AD", "INTEG", "AVERAGE");
        Console.WriteLine("========================================================================================================================");

        while (i < itemcount)
        {

            if (st[i].studentnumber != null)
            {
                Console.Write("{0,-15}\t{1,-20}\t{2,-5}", st[i].studentnumber, st[i].studentname, st[i].Gender);
                Console.Write(" \t{0,-5}\t {1,-9}{2,-5}", st[i].OOP, st[i].IM, st[i].HCI);
                Console.Write("\t{0,-9} {1,-5} \t\t{2,-4}", st[i].NetAd, st[i].Integ, st[i].total / 5);
                Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------------\n");
            }

            i = i + 1;
        }
    }


    //SEARCHING RECORD OF STUDENT BY Number
    static void find(student[] st, int itemcount)
    {
        Console.WriteLine("======================================================\n                     SEARCH STUDENTS                         \n======================================================");
        string studentnumber;
        Console.Write("Enter student's Number:");
        studentnumber = Console.ReadLine();

        int index = search(st, studentnumber.ToString(), itemcount);
        if (index != -1)
        {
            Console.Write("{0,-5}\t{1,-20}{2,-5}", st[index].studentnumber, st[index].studentname, st[index].Gender);
            Console.Write("{0,-5}{1,-5}{2,-5}", st[index].OOP, st[index].IM, st[index].HCI);
            Console.Write("{0,-5}{1,-5}{2,-5}", st[index].NetAd, st[index].Integ, st[index].total / 5);
            Console.WriteLine();

        }
        else Console.WriteLine("The record doesn't exits.");
    }

    //CODE FOR SEARCH USED BY FINDING,DELETING,UPDATING THE DATA OF STUDENTS
    //ALSO BY ADDING IF THE THE STUDENT ID ALREADY EXIST
    static int search(student[] st, string studentnumber, int itemcount)
    {
        int found = -1;
        for (int i = 0; i < itemcount && found == -1; i++)
        {

            if (st[i].studentnumber == studentnumber) found = i;

            else found = -1;
        }

        return found;

    }

    //METHOD TO CLEAN THE DELETED RECORD
    static void clean(student[] st, int index)
    {                            
        st[index].studentnumber = null;
        st[index].studentname = null;
        st[index].Gender = null;
        st[index].OOP = 0;
        st[index].IM = 0;
        st[index].HCI = 0;
        st[index].NetAd = 0;
        st[index].Integ = 0;
        st[index].total = 0;

    }
}
}
