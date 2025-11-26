using System;

class Program
{
    static void Main()
    {
        Console.Title = "Car Rental Service";

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== СЕРВIС ПРОКАТУ АВТО ===");
            Console.ResetColor();

            // Меню типів авто
            Console.WriteLine("\nОберiть тип авто:");
            Console.WriteLine("1. Легковi");
            Console.WriteLine("2. Позашляховики");
            Console.WriteLine("3. Мiкроавтобуси");
            Console.WriteLine("4. Вийти");

            Console.Write("\nВведiть номер типу авто: ");
            if (!int.TryParse(Console.ReadLine(), out int type) || type < 1 || type > 4)
            {
                PrintError("Невiрний вибiр! Натиснiть будь-що, щоб продовжити...");
                continue;
            }

            if (type == 4) return;

            // Дані по авто
            string[] names = Array.Empty<string>();
            int[] prices = Array.Empty<int>();

            switch (type)
            {
                case 1:
                    names = new[] { "Toyota Corolla", "BMW 5 Series", "Tesla Model 3", "Audi A4", "Honda Civic" };
                    prices = new[] { 1200, 2500, 3000, 2000, 1300 };
                    break;

                case 2:
                    names = new[] { "Toyota RAV4", "BMW X5", "Mercedes GLE", "Audi Q7", "Jeep Grand Cherokee" };
                    prices = new[] { 1800, 3500, 4000, 3600, 3200 };
                    break;

                case 3:
                    names = new[] { "Ford Transit", "Mercedes Sprinter", "Renault Trafic", "Volkswagen Crafter", "Opel Vivaro" };
                    prices = new[] { 2000, 2800, 2300, 2600, 2100 };
                    break;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== СПИСОК МОДЕЛЕЙ ===");

                for (int i = 0; i < names.Length; i++)
                    Console.WriteLine($"{i + 1}. {names[i]} — {prices[i]} грн/доба");

                Console.WriteLine("6. Повернутися назад");
                Console.Write("\nВведiть авто: ");

                if (!int.TryParse(Console.ReadLine(), out int carChoice) || carChoice < 1 || carChoice > 6)
                {
                    PrintError("Невiрний вибiр авто!");
                    continue;
                }

                if (carChoice == 6) break;

                string chosenName = names[carChoice - 1];
                double pricePerDay = prices[carChoice - 1];

                Console.Write("\nНа скiльки дiб хочете орендувати: ");
                if (!int.TryParse(Console.ReadLine(), out int days) || days < 1)
                {
                    PrintError("Невiрна кiлькiсть дiб!");
                    continue;
                }

                double total = pricePerDay * days;

                Random rnd = new Random();
                int discount = rnd.Next(5, 16);
                double finalTotal = Math.Round(total - (total * discount / 100), 2);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=== ЧЕК ПРОКАТУ АВТО ===");
                Console.ResetColor();

                Console.WriteLine($"Модель: {chosenName}");
                Console.WriteLine($"Цiна за добу: {pricePerDay} грн");
                Console.WriteLine($"Кiлькiсть дiб: {days}");
                Console.WriteLine($"Повна вартiсть: {total} грн");
                Console.WriteLine($"Знижка: {discount}%");
                Console.WriteLine($"До сплати: {finalTotal} грн");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nДякуємо, що обрали наш сервiс!");
                Console.ResetColor();

                Console.WriteLine("\nНатисніть будь-що, щоб повернутися в меню...");
                Console.ReadKey();
                break;
            }
        }
    }

    static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{message}");
        Console.ResetColor();
        Console.ReadKey();
    }
}
