using System.Runtime.Serialization.Formatters.Binary;

namespace Homework3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<TestCase> testCaseList = new List<TestCase>();
            List<Bug> bugList = new List<Bug>();

            BinaryFormatter formatter = new BinaryFormatter();

            string testCasePath = @"C:\Users\mlashevich\Documents\Issues\testCases.dat";
            string bugPath = @"C:\Users\mlashevich\Documents\Issues\bugs.dat";

            DirectoryInfo testCaseInfo = new DirectoryInfo(testCasePath);
            DirectoryInfo bugInfo = new DirectoryInfo(bugPath);

            if (testCaseInfo.Exists)
            {
                using (FileStream fileStream = new FileStream(testCasePath, FileMode.Open))
                {
                    testCaseList = (List<TestCase>)formatter.Deserialize(fileStream);

                    Console.WriteLine("Current version of Test Cases database is successfully loaded from file");
                }
            }

            if (bugInfo.Exists)
            {
                using (FileStream fileStream = new FileStream(bugPath, FileMode.Open))
                {
                    bugList = (List<Bug>)formatter.Deserialize(fileStream);

                    Console.WriteLine("Current version of Bugs database is successfully loaded from file");
                }
            }

            Console.ReadLine();

            int firstMenuUserChoice;
            string[] paramList = { "Create a Test Case", "Show Test Case by Id", "Show all Test Cases", "Delete Test Case by Id",
             "Run Test case by Id", "Show Bug by Id", "Show all bugs", "Change Bug status by id", "Delete Bug", "Exit"};

            do
            {
                firstMenuUserChoice = Actions.ChooseOption("Type the number choosing one option from the menu below:", paramList);

                switch (firstMenuUserChoice)
                {
                    case 1:
                        ICollectionExtension.AddIssue<TestCase>(testCaseList);
                        break;

                    case 2:
                        Guid id1;
                        Console.Clear();
                        Console.WriteLine("Input Id");

                        try
                        {
                            if (!Guid.TryParse(Console.ReadLine(), out id1))
                            {
                                throw new InvalidInputException();
                            }
                            ICollectionExtension.ShowIssueById<TestCase>(testCaseList, id1);
                        }
                        catch (InvalidInputException ex)
                        {
                            ex.ShowMessage();
                        }
                        break;

                    case 3:
                        Console.Clear();
                        ICollectionExtension.ShowAll(testCaseList);
                        break;

                    case 4:
                        Guid id2;
                        Console.Clear();
                        Console.WriteLine("Input Id");

                        try
                        {
                            if (!Guid.TryParse(Console.ReadLine(), out id2))
                            {
                                throw new InvalidInputException();
                            }
                            ICollectionExtension.DeleteIssueById<TestCase>(testCaseList, id2);
                        }
                        catch (InvalidInputException ex)
                        {
                            ex.ShowMessage();
                        }
                        break;

                    case 5:
                        Guid id3;
                        Console.Clear();
                        Console.WriteLine("Input Id");

                        try
                        {
                            if (!Guid.TryParse(Console.ReadLine(), out id3))
                            {
                                throw new InvalidInputException();
                            }
                            ICollectionExtension.RunTestCaseById(testCaseList, id3);
                        }
                        catch (InvalidInputException ex)
                        {
                            ex.ShowMessage();
                        }
                        break;

                    case 6:
                        Guid id4;
                        Console.Clear();
                        Console.WriteLine("Input Id");

                        try
                        {
                            if (!Guid.TryParse(Console.ReadLine(), out id4))
                            {
                                throw new InvalidInputException();
                            }
                            ICollectionExtension.ShowIssueById<Bug>(bugList, id4);
                        }
                        catch (InvalidInputException ex)
                        {
                            ex.ShowMessage();
                        }
                        break;

                    case 7:
                        Console.Clear();
                        ICollectionExtension.ShowAll(bugList);
                        break;

                    case 8:
                        Guid id5;
                        Console.Clear();
                        Console.WriteLine("Input Id");

                        try
                        {
                            if (!Guid.TryParse(Console.ReadLine(), out id5))
                            {
                                throw new InvalidInputException();
                            }
                            ICollectionExtension.ChangeBugStatusById(bugList, testCaseList, id5);
                        }
                        catch (InvalidInputException ex)
                        {
                            ex.ShowMessage();
                        }
                        break;

                    case 9:
                        Guid id7;
                        Console.Clear();
                        Console.WriteLine("Input Id");

                        try
                        {
                            if (!Guid.TryParse(Console.ReadLine(), out id7))
                            {
                                throw new InvalidInputException();
                            }
                            ICollectionExtension.DeleteIssueById<Bug>(bugList, id7);
                        }
                        catch (InvalidInputException ex)
                        {
                            ex.ShowMessage();
                        }
                        break;

                    case 10:
                        Console.Clear();
                        Console.WriteLine("Input is over");
                        break;
                }
            } while (firstMenuUserChoice != 10);

            using (FileStream fileStream = new FileStream(testCasePath, FileMode.Create))
            {
                formatter.Serialize(fileStream, testCaseList);

                Console.WriteLine("Current version of Test Cases database is successfully saved to file");
            }

            using (FileStream fileStream = new FileStream(bugPath, FileMode.Create))
            {
                formatter.Serialize(fileStream, bugList);

                Console.WriteLine("Current version of Bugs database is successfully saved to file");
            }
        }
    }
}