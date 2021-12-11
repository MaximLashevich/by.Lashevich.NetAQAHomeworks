namespace Homework2
{
    public static class Actions
    {

        public static void ShowOptions(params string[] paramList)
        {
            for (int i = 0; i < paramList.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {paramList[i]}");
            }
        }

        
        public static int ChooseOption(params string[] paramList)
        {
            int choice;
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Type the number choosing one option from the menu below:");

                ShowOptions(paramList);
                try
                {
                    if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > paramList.Length)
                    {
                        throw new InvalidInputException();
                    }
                    return choice;
                }
                catch (InvalidInputException ex)
                {
                    ex.ShowMessage();
                }
            }
        }

        public static int EnumChooseOptions<T>()
            where T : Enum
        {
            var str = new List<string>();
            foreach (var option in Enum.GetNames(typeof(T)))
            {
                str.Add(option.ToString());
            }

            return ChooseOption(str.ToArray());
        }
    }
}
