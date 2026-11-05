using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_ProductFilter
{
    public class ProductManager
    {
        private List<Product> products = new List<Product>
        {
            new Product("Наушники", 3500m, "Электроника"),
            new Product("Мышь", 1500m, "Электроника"),
            new Product("Клавиатура", 4500m, "Электроника"),
            new Product("Монитор", 25000m, "Электроника"),
            new Product("Книга", 800m, "Литература"),
            new Product("Рюкзак", 4000m, "Аксессуары")
        };

        public void RunLinqQuery(decimal threshold)
        {
            var query = products
                .Where(p => p.Price > threshold)
                .OrderBy(p => p.Price)
                .Select(p => $"{p.Name}: {p.Price} руб.");

            Console.WriteLine($"\nРезультат LINQ-запроса (дороже {threshold}):");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowAggregates(decimal threshold1, decimal threshold2)
        {
            int count = products.Count(p => p.Price > threshold1);
            bool anyExpensive = products.Any(p => p.Price > threshold2);

            Console.WriteLine($"Количество товаров дороже {threshold1}: {count}");
            Console.WriteLine($"Есть ли товары дороже {threshold2}: {anyExpensive}");
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void PrintAll()
        {
            Console.WriteLine("=== Все товары в каталоге ===");
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }
        }
    }
}