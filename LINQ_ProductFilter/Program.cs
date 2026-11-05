using System;

namespace LINQ_ProductFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager manager = new ProductManager();

            Console.WriteLine("=== Исходный каталог товаров ===");
            manager.PrintAll();

            decimal initialThreshold = 1000m;
            manager.RunLinqQuery(initialThreshold);

            Console.WriteLine("\n=== Демонстрация Count и Any ===");
            manager.ShowAggregates(1000m, 100000m);

            decimal updatedThreshold = 5000m;
            Console.WriteLine($"\n=== Изменение порога в Where на {updatedThreshold} ===");
            manager.RunLinqQuery(updatedThreshold);

            Console.WriteLine("\n=== Интерактивный режим ===");

            while (true)
            {
                try
                {
                    Console.WriteLine("\n1. Выполнить LINQ-запрос с порогом цены");
                    Console.WriteLine("2. Показать статистику (Count и Any)");
                    Console.WriteLine("3. Добавить новый товар");
                    Console.WriteLine("4. Показать все товары");
                    Console.Write("Выберите действие (или 'stop' для выхода): ");
                    string choice = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(choice) || choice.Trim().ToLower() == "stop")
                    {
                        break;
                    }

                    if (choice == "1")
                    {
                        Console.Write("Введите порог цены: ");
                        decimal threshold = decimal.Parse(Console.ReadLine() ?? "0");
                        manager.RunLinqQuery(threshold);
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Введите порог для Count: ");
                        decimal t1 = decimal.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Введите порог для Any: ");
                        decimal t2 = decimal.Parse(Console.ReadLine() ?? "0");
                        manager.ShowAggregates(t1, t2);
                    }
                    else if (choice == "3")
                    {
                        Console.Write("Введите название товара: ");
                        string name = Console.ReadLine() ?? "";
                        Console.Write("Введите цену товара: ");
                        decimal price = decimal.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Введите категорию: ");
                        string category = Console.ReadLine() ?? "";

                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            manager.AddProduct(new Product(name, price, category));
                            Console.WriteLine("Товар успешно добавлен.");
                        }
                    }
                    else if (choice == "4")
                    {
                        manager.PrintAll();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введено некорректное число.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}