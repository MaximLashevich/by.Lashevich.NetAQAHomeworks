using System.Collections.Generic;

namespace Homework2
{
    public static class ICollectionExtension
    {

        public static void AddIssue<T>(this ICollection<T> IssueList)
            where T : IIssue, new()
        {
            var issue = new T();

            issue.Set();

            IssueList.Add(issue);
            
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

        public static void FilterPriority<T>(this ICollection<T> IssueList, int value)
            where T : IIssue
        {
            var selectedIssues = from Issue issue in IssueList
                                 where issue.Priority == (Priority)value - 1
                                 select issue;
            foreach (Issue issue in selectedIssues)
                Console.WriteLine(issue.Get());
        }

        public static void FilterStatus<T>(this ICollection<T> IssueList, int value)
            where T : IIssue
        {
            var selectedIssues = from Issue issue in IssueList
                                 where issue.Status == (Status)value - 1
                                 select issue;
            foreach (Issue issue in selectedIssues)
                Console.WriteLine(issue.Get());
        }
        
        public static void SortDate<T>(this ICollection<T> IssueList)
            where T : IIssue
        {
            var selectedIssues = from Issue issue in IssueList
                                 orderby issue.CreationDate
                                 select issue;

            foreach (Issue issue in selectedIssues)
                Console.WriteLine(issue.Get());
        }

        public static void FindId<T>(this ICollection<T> IssueList, Guid value)
            where T : IIssue
        {
            var selectedIssues = from Issue issue in IssueList
                                 where issue.Id == value
                                 select issue;
            foreach (Issue issue in selectedIssues)
                Console.WriteLine(issue.Get());
        }
    }
}
