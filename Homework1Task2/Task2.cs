/*
 Задание 2:
  1.	Создать enum Priority (Low, Medium, High) и Status(New, InProgress, Failed, Done)
  2.	Создать переменные основных полей бага:
    a)	Id;
    b)	CreationDate; (заполняется автоматически)
    c)	Priority; (тип Priority)
    d)	Summary;
    e)	Precondition;
    f)	Status;  (тип Status)
    g)	TestCaseId;
    h)	StepNumber; 
    i)	ActualResult;
    j)	ExpectedResult.
  3.	Реализовать метод заполнения переменных с помощью ввода из консоли (Сделать с помощью примера: Fill(ref int         id, ref Datetime creationDate, …) {…} )
  4.	Реализовать метод вывода заполненных переменных на экран
  5.	Реализовать меню (Switch) для выбора действия для заданий 2.3 и 2.4
*Задание 2а:
  1.	Вместо заданий 2-4, Определить переменные в класс, реализовать конструктор и метод вывода
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1Task2
{
    internal class Task2
    {
        static void Main(string[] args)
        {
            Console.Write("Enter bug's Id: ");
            int id = int.Parse(Console.ReadLine());

            string bugDate = DateTime.Now.ToString();

            Console.Write("Enter bug's Priority. Type 1 for High, Type 2 for Medium or Type 3 for Low: ");
            int userPriority = int.Parse(Console.ReadLine());
            string bugPriority = CreateBugPriority(userPriority);

            Console.Write("Enter bug's Summary: ");
            string bugSummary = Console.ReadLine();

            Console.Write("Enter bug's Precondition: ");
            string bugPrecondition = Console.ReadLine();

            Console.Write("Enter bug's Status. Type 1 for New, Type 2 for InProgress, Type 3 for Failed or Type 4 for Done: ");
            int userStatus = int.Parse(Console.ReadLine());
            string bugStatus = CreateBugStatus(userStatus);

            Console.Write("Enter TestCase Id: ");
            int testCaseId = int.Parse(Console.ReadLine());

            Console.Write("Enter Step Number: ");
            int stepNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter Test Actual Result: ");
            string testActualResult = Console.ReadLine();

            Console.Write("Enter Test Expected Result: ");
            string testExpectedResult = Console.ReadLine();

            BugFillPrint(ref id, ref bugDate, ref bugPriority, ref bugSummary, ref bugPrecondition, ref bugStatus, ref testCaseId,
                ref stepNumber, ref testActualResult, ref testExpectedResult);
        }

        static string CreateBugPriority(int userPriority) 
        {
            switch (userPriority)
            {
                case 1: return Priority.High.ToString();

                case 2: return Priority.Medium.ToString();
                    
                case 3: return Priority.Low.ToString();
                    
                default: return "Wrong Priority Input";
            }
        }

        static string CreateBugStatus(int userStatus)
        {
            switch (userStatus)
            {
                case 1: return Status.New.ToString();

                case 2: return Status.InProgress.ToString();

                case 3: return Status.Failed.ToString();

                case 4: return Status.Done.ToString();

                default: return "Wrong Status Input";
            }
        }

        static void BugFillPrint(ref int id, ref string bugDate, ref string bugPriority, ref string bugSummary, ref string bugPrecondition,
            ref string bugStatus, ref int testCaseId, ref int stepNumber, ref string testActualResult, ref string testExpectedResult) 
        {
            Console.WriteLine("\n\nBug is successfully created with the following properties:");
            Console.WriteLine($"Id: {id};");
            Console.WriteLine($"Creation Date: {bugDate};");
            Console.WriteLine($"Priority: {bugPriority};");
            Console.WriteLine($"Summary: {bugSummary};");
            Console.WriteLine($"Precondition: {bugPrecondition};");
            Console.WriteLine($"Status: {bugStatus};");
            Console.WriteLine($"TestCase Id: {testCaseId};");
            Console.WriteLine($"Step Number: {stepNumber};");
            Console.WriteLine($"Actual Result: {testActualResult};");
            Console.WriteLine($"Expected Result: {testExpectedResult};");
        }

        enum Priority
        {
            High,
            Medium,
            Low
        }
        enum Status
        {
            New,
            InProgress,
            Failed,
            Done
        }
    }
}
