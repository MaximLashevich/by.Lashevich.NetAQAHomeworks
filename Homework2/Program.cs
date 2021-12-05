/*
1.      Создать enum Priority (Low, Medium, High) и Status(New, InProgress, Failed, Done)


2.      Создать класс Bug  Свойствами: (public int id{ get; set; })

a.      Id - заполняется автоматически uid;

b.      CreationDate - заполняется автоматически;

c.      Priority - заполняется пользователем; (тип Priority)

d.      Summary - заполняется пользователем;

e.      Precondition - заполняется автоматически из объекта тест-кейс;

f.       Status;  (тип Status)

g.      TestCaseId - заполняется автоматически из объекта тест-кейс;

h.      StepNumber - заполняется пользователем;

i.       ActualResult - заполняется пользователем;

j.       ExpectedResult - заполняется автоматически из объекта тест-кейс и номера стэпа;



3.      Создать класс Step со свойствами:

a.      Number - заполняется пользователем;

b.      Action - заполняется пользователем;

c.      ExpectedResult - заполняется пользователем;.



4.      Создать класс TestCase со свойствами:

a.      Id; (Заполняется автоматически)

b.      CreationDate; (Заполняется автоматически)

c.      Priority; (Low, Medium, High)

d.      Summary - заполняется пользователем;

e.      Precondition - заполняется пользователем;

f.       Status; (New, InProgress, Failed, Done)

g.      Коллекции Step.



5.      Во всех классах реализовать методы заполнения и вывода на экран (Fill(…), Show())

a.      Каждый ввод с консли должен проверяться на валидность и если не проходит, то предлагать выполнить это действие снова.

6.      Вынести классы и перечисления(enum) в отдельные файлы.(желательно в папку)


7.      * В Program.cs создать коллекции Bugs и TestCases

8.      * В Switch меню реализовать добавление и удаление в коллекции Bugs и TestCase

9.      * Создать абстрактный класс, содержащий общие свойства и методы, унаследовать от него Bug и TestCase.

*/
using System.Collections;

namespace Homework2
{
    public class Program
    {
        
        public static void Main(string[] args) 
        {
            ArrayList stepList = Step.FillStepsCollection();
            Step.ShowSteps(stepList);

            TestCase testCase = TestCase.FillTestCase();
            TestCase.ShowTestCase(testCase);

            Bug bug = Bug.FillBug(testCase);
            Bug.ShowBug(bug);
        }
    }
}