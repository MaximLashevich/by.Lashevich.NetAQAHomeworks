using System.Text;

namespace Homework3
{
    public static class ICollectionExtension
    {

        public static void AddIssue<T>(this ICollection<T> IssueList)
            where T : IIssue, new()
        {
            var issue = new T();
            issue.Set();
            IssueList.Add(issue);

            Console.WriteLine("Issue was successfully added");
        }

        public static void ShowAll<T>(this ICollection<T> IssueList)
            where T : IIssue
        {
            Console.Clear();

            foreach (var issue in IssueList)
            {
                Console.WriteLine(issue.Get());
            }
        }

        public static T FindIssueById<T>(this ICollection<T> IssueList, Guid id)
           where T : IIssue
        {
            T foundIssue = (T)(from T issue in IssueList
                                                  where issue.Id == id
                                                  select issue);
            return foundIssue;
        }

        public static void ShowIssueById<T>(this ICollection<T> IssueList, Guid id)
            where T : IIssue
        {
            var selectedIssues = (ICollection<T>)(from T issue in IssueList
                                                  where issue.Id == id
                                                  select issue);
            ShowAll(selectedIssues);
        }

        public static void SortIssuesbyDate<T>(this ICollection<T> IssueList)
            where T : IIssue
        {
            var sortedIssues = (ICollection<T>)(from T issue in IssueList
                                                orderby issue.CreationDate
                                                select issue);
            ShowAll(sortedIssues);
        }

        public static void FilterIssuesbyPriority<T>(this ICollection<T> IssueList, int value)
            where T : IIssue
        {
            var filteredIssues = (ICollection<T>)(from T issue in IssueList
                                                  where issue.Priority == (Priority)value - 1
                                                  select issue);
            ShowAll(filteredIssues);
        }

        public static void RunTestCaseById(this ICollection<TestCase> testCaseList, Guid id)
        {
            TestCase foundtestCase = (TestCase)(from TestCase testCase in testCaseList
                                                where testCase.Id == id
                                                select testCase);
            foundtestCase.Status = (Status)1;
            Console.WriteLine($"Test Case {foundtestCase.Id} is being executed. Status: {foundtestCase.Status}. \nTest Case steps:");
            int i = 0;
            StringBuilder sb = new StringBuilder();

            foreach (Step step in foundtestCase.StepList) 
            {
                i++;
                Console.WriteLine(step.Get());
                sb.Append(step.Get());
                string title = "Does Actual result correspond to Expected result?";
                string[] paramList = { "YES", "NO" };
                int userChoice = Actions.ChooseOption(title, paramList);

                if (userChoice == 2) 
                {
                    foundtestCase.Status = (Status)3;
                    Bug bug = new Bug();

                    bug.SetFromFailedTestCase(foundtestCase, step, sb.ToString());
                    Console.Clear();
                    Console.WriteLine("Bug is successfully created");
                    bug.Get();
                    return;
                }
            }
            if(i == foundtestCase.StepList.Count) 
            {
                foundtestCase.Status = (Status)3;
                Console.WriteLine($"Test Case {foundtestCase.Id} is successfully executed. Status: {foundtestCase.Status}.");
            }
            
        }

        public static void ChangeBugStatusById(this ICollection<Bug> bugList, ICollection<TestCase> testCaseList, Guid id) 
        {
            Bug foundBug = FindIssueById(bugList, id);
            Console.WriteLine("Enter new Status for the found Bug");
            int userChoiceBug = Actions.EnumChooseOptions<Status>();
            foundBug.Status = (Status)userChoiceBug - 1;

            TestCase foundTestCase = FindIssueById(testCaseList, (Guid)foundBug.TestCaseId);
            Console.WriteLine("Enter new Status for the linked Test Case");
            int userChoiceTestCase = Actions.EnumChooseOptions<Status>();
            foundTestCase.Status = (Status)userChoiceTestCase - 1;

            Console.WriteLine("Statuses for the Bug and Test Case have been successfully changed");
        }

        public static void DeleteIssueById<T>(this ICollection<T> issueList, Guid id)
            where T : IIssue
        {
            T foundIssue = FindIssueById(issueList, id);
            issueList.Remove(foundIssue);

            Console.WriteLine("Issue has been successfully deleted");
        }

    }
}
