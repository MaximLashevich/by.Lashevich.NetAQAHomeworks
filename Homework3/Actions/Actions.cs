namespace Homework3
{
    public static class Actions
    {

        public static void ShowOptions(string title, params string[] paramList)
        {
            Console.WriteLine(title);

            for (int i = 0; i < paramList.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {paramList[i]}");
            }
        }

        
        public static int ChooseOption(string title, params string[] paramList)
        {
            int choice;
            while (true)
            {
                Console.Clear();

                ShowOptions(title, paramList);
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

            return ChooseOption($"Choose a { nameof(T)}", str.ToArray());
        }
    }
}
