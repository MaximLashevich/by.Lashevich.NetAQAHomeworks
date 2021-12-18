using System.Runtime.Serialization.Formatters.Binary;

namespace Homework2
{
    public class Program
    {

        public static void Main(string[] args)
        {
            List<TestCase> testCaseList = new List<TestCase>();
            List<Bug> bugList = new List<Bug>();

            BinaryFormatter formatter = new BinaryFormatter();
            string testCasePath = @"C:\Users\mlashevich\Documents\Issues\testCases.dat";
            DirectoryInfo testCaseInfo = new DirectoryInfo(testCasePath);

            if (testCaseInfo.Exists)
            {
                using (FileStream fileStream = new FileStream(testCasePath, FileMode.Open))
                {
                    testCaseList = (List<TestCase>)formatter.Deserialize(fileStream);

                    Console.WriteLine("Current version of Test Cases database is successfully loaded from file");
                }
            }

            string bugPath = @"C:\Users\mlashevich\Documents\Issues\bugs.dat";
            DirectoryInfo bugInfo = new DirectoryInfo(bugPath);

            if (bugInfo.Exists)
            {
                using (FileStream fileStream = new FileStream(bugPath, FileMode.Open))
                {
                    bugList = (List<Bug>)formatter.Deserialize(fileStream);

                    Console.WriteLine("Current version of Bugs database is successfully loaded from file");
                }
            }

            Console.ReadLine();

            /*int userChoice;
            do
            {
                userChoice = Actions.ChooseOption("Create Test Case", "Create Bug", "Cancel");

                switch (userChoice)
                {
                    case 1:
                        ICollectionExtension.AddIssue<TestCase>(testCaseList);
                        break;
                    case 2:
                        ICollectionExtension.AddIssue<Bug>(bugList);
                        break;
                    case 3:
                        Console.WriteLine("\n\nInput is over");
                        break;
                }
            } while (userChoice == 1 || userChoice == 2);



            //ICollectionExtension.ShowAll<TestCase>(testCaseList);
            //ICollectionExtension.ShowAll<Bug>(bugList);

            //ICollectionExtension.FilterPriority<TestCase>(testCaseList, 3);
            //ICollectionExtension.FilterPriority<Bug>(bugList, 1);

            //ICollectionExtension.FilterStatus<TestCase>(testCaseList, 1);
            //ICollectionExtension.FilterStatus<Bug>(bugList, 4);

            //ICollectionExtension.SortDate<TestCase>(testCaseList);
            //ICollectionExtension.SortDate<Bug>(bugList);

            //if (testCaseList.Count >= 1) 
            //{
                //ICollectionExtension.FindId<TestCase>(testCaseList, testCaseList[0].Id);
            //}

            //if (bugList.Count >= 1)
            //{
                //ICollectionExtension.FindId<Bug>(bugList, bugList[0].Id);
            //}*/

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