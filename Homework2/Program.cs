/*
1.      Переделать классы enum Priority (Low, Medium, High) и Status(New, InProgress, Failed, Done)


У вас уже написаны классы TestCase, Step, Bug с базовым функционалом.

Объявлены и инициализированы коллекции TestCase и Bug в классе Project

1.      Создать интерфейс IIssue содержащий в себе методы Get() и Set()      

2.      Создать абстрактный класс Issue, наследуемый от IIssue, содержащий общие свойства и реализующий общие методы для TestCase и Bug.

3.      Переопределить методы Get() и Set() в классах TestCase и Bug

4.      Создать статический класс Actions с методом int Choose(string[]), принимающий в себя массив пунктов меню, выводящий их на экран для предложения вариантов действий из меню. Принимает значение из консоли, конвертирует в тип int. Если ввод не соответствует одному из требуемых значений, выполняется снова

5.      Реализовать статические класс с методами расширения для коллекций: с Generic типом и вынести в них функционал добавления добавления элемента, вовода всех элементов на экран (с сортировкой и фильтрацией), Вывода отдельного элемента по ИД

6.      *Реализовать статический метод Seed(), автоматически заполняющий коллекции TestCase и Bug. Добавить его, как опцию меню.

7. *При выводе всех элементов реализовать возможность задания сортировки и фильтрации элементов по заданным значениям

8. *Реализовать все взаимодействия в соответствии с принципами ООП (+SOLID, KISS, YAGNI, DRY)

Сдать к сб (11.12.2021) 17:00 (Минск)


*/

namespace Homework2
{
    public class Program
    {

        public static void Main(string[] args)
        {
            List<TestCase> testCaseList = new List<TestCase>();
            List<Bug> bugList = new List<Bug>();

            int userChoice;
            do
            {
                userChoice = Actions.EnumChooseOptions<ChooseOptions>();

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



            ICollectionExtension.ShowAll<TestCase>(testCaseList);
            ICollectionExtension.ShowAll<Bug>(bugList);

            ICollectionExtension.FilterPriority<TestCase>(testCaseList, 3);
            ICollectionExtension.FilterPriority<Bug>(bugList, 1);

            ICollectionExtension.FilterStatus<TestCase>(testCaseList, 1);
            ICollectionExtension.FilterStatus<Bug>(bugList, 4);

            ICollectionExtension.SortDate<TestCase>(testCaseList);
            ICollectionExtension.SortDate<Bug>(bugList);

            if (testCaseList.Count >= 1) 
            {
                ICollectionExtension.FindId<TestCase>(testCaseList, testCaseList[0].Id);
            }


            if (bugList.Count >= 1)
            {
                ICollectionExtension.FindId<Bug>(bugList, bugList[0].Id);
            }
        }
    }
}