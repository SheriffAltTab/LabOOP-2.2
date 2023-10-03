using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LabOOP_2
{
    internal class OOP
    {
        static void Main()
        {
            int task;
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Виберіть завдання\nЗавдання 1\nЗавдання 2\nЗавдання 3\nЗавдання 4\n");
                try
                {
                    task = Convert.ToInt16(Console.ReadLine());
                }
                catch
                {
                    continue;
                }
                switch (task)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    default:
                        continue;

                }
            }
        }

        public static void Task1()
        {
            double[] arr = { 2.5, 0.0, -3.7, 0.0, 8.1, -1.5 };

            double A = -2.0;
            double B = 2.0;

            int zeroCount = arr.Count(x => x == 0.0);
            Console.WriteLine("Кількість елементів, рівних нулю: " + zeroCount);

            double sumInRange = arr.Where(x => x >= A && x <= B).Sum();
            Console.WriteLine("Сума елементів, які належать діапазону [{0}, {1}]: {2}", A, B, sumInRange);

            double[] sortedArray = arr.OrderByDescending(x => Math.Abs(x)).ToArray();

            Console.WriteLine("Впорядкований масив за спаданням модулів:");
            foreach (var element in sortedArray)
            {
                Console.WriteLine(element);
            }
            Console.ReadLine();
        }



        public static void Task2()
        {
            int[,] matrix = {
            {1, 2, 3, 8},
            {8, 0, 6, 8},
            {3, 9, 0, 7},
            {0, 13, 14, 15}
        };

            int rowCountWithZero = 0;
            int longestColumn = 0;
            int maxLength = 0;

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;

                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }

                if (hasZero)
                {
                    rowCountWithZero++;
                }
            }

            for (int j = 0; j < columns; j++)
            {
                int currentLength = 1;

                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] == matrix[i - 1, j])
                    {
                        currentLength++;
                    }
                    else
                    {
                        currentLength = 1;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        longestColumn = j;
                    }
                }
            }

            Console.WriteLine("Кількість рядків з нульовими елементами: " + rowCountWithZero);
            Console.WriteLine("Номер стовпця з найдовшою серією однакових елементів: " + longestColumn);
            Console.ReadLine();
        }



        public static void Task3()

        {
            Console.Write("Введіть текстовий рядок: ");
            string inputText = Console.ReadLine();

            int colonIndex = inputText.IndexOf(":");

            if (colonIndex != -1 && colonIndex < inputText.Length - 1)
            {
                string charactersAfterColon = inputText.Substring(colonIndex + 1);
                Console.WriteLine("Символи після першого ':': " + charactersAfterColon);
            }
            else
            {
                Console.WriteLine("В рядку немає символу ':' або він останній.");
            }

            string[] sentences = inputText.Split('.');
            int oddWordCountSentences = 0;

            foreach (string sentence in sentences)
            {
                string[] words = sentence.Trim().Split(' ');
                if (words.Length % 2 != 0)
                {
                    oddWordCountSentences++;
                }
            }

            Console.WriteLine("Кількість речень з непарною кількістю слів: " + oddWordCountSentences);

            string[] wordsToRemove = inputText.Split(',');
            foreach (string wordToRemove in wordsToRemove)
            {
                inputText = inputText.Replace("," + wordToRemove, "");
            }

            Console.WriteLine("Текст після видалення слів після коми: " + inputText);
            Console.ReadLine();
        }


        static List<PlantVariety> plantVarieties = new List<PlantVariety>();

        // Клас, який представляє сорт рослин
        class PlantVariety
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int Yield { get; set; }
            public bool FrostResistant { get; set; }
            public string Period { get; set; }
        }


        public static void Task4()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Виберіть дію:\n1. Додати сорт рослин\n2. Пошук сорту рослин\n3. Список всіх сортів рослин");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("\nНазва сорту рослин: ");
                        string name = Console.ReadLine();
                        Console.Write("Тип сорту: ");
                        string type = Console.ReadLine();
                        Console.Write("Врожайність: ");
                        int yield;
                        if (!int.TryParse(Console.ReadLine(), out yield))
                        {
                            Console.WriteLine("Некоректна врожайність. Введіть числове значення.");
                            return;
                        }
                        Console.Write("Морозостійкість (true/false): ");
                        bool frostResistant;
                        if (!bool.TryParse(Console.ReadLine(), out frostResistant))
                        {
                            Console.WriteLine("Некоректне значення морозостійкості. Введіть true або false.");
                            return;
                        }
                        Console.Write("Термін дозрівання (ранньостиглий/середньостиглий/пізній): ");
                        string Period = Console.ReadLine();

                        plantVarieties.Add(new PlantVariety
                        {
                            Name = name,
                            Type = type,
                            Yield = yield,
                            FrostResistant = frostResistant,
                            Period = Period
                        });

                        Console.WriteLine("\nСорт рослин додано до списку.");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Введіть тип рослини для пошуку (наприклад, 'Овочі', 'Фрукти', 'Ягоди', тощо): ");
                        string searchType = Console.ReadLine();

                        var filteredVarieties = FilterPlantVarietiesByType(plantVarieties, searchType);

                        Console.WriteLine("\nРезультати пошуку:");
                        foreach (var variety in filteredVarieties)
                        {
                            Console.WriteLine($"Назва сорту: {variety.Name}, Тип сорту: {variety.Type}, Врожайність: {variety.Yield}, Морозостійкість: {variety.FrostResistant}, Термін дозрівання: {variety.Period}");
                        }

                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("\nСписок всіх сортів рослин:");
                        foreach (var variety in plantVarieties)
                        {
                            Console.WriteLine($"Назва сорту: {variety.Name}, Тип сорту: {variety.Type}, Врожайність: {variety.Yield}, Морозостійкість: {variety.FrostResistant}, Термін дозрівання: {variety.Period}");
                        }
                        Console.ReadLine();
                        break;
                }
            }
        }

        static List<PlantVariety> FilterPlantVarietiesByType(List<PlantVariety> varieties, string type)
        {
            return varieties
                .Where(variety => variety.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
