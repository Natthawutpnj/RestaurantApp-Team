
using System;
using System.Collections.Generic;

internal class Program
{
    static void Main()
    {
        List<string> names = new List<string>();
        List<string> types = new List<string>();
        List<double> ratings = new List<double>();

        // รับข้อมูลจากคีย์บอร์ด
        Console.Write("ชื่อร้าน: ");
        string name = Console.ReadLine();

        Console.Write("ประเภท: ");
        string type = Console.ReadLine();

        Console.Write("คะแนน (0-5): ");
        double rating = double.Parse(Console.ReadLine());

        // เพิ่มเข้า List
        names.Add(name);
        types.Add(type);
        ratings.Add(rating);

        Console.WriteLine("เพิ่มร้านเรียบร้อย");

        // แสดงผลร้านทั้งหมด
        Console.WriteLine("\nรายการร้านทั้งหมด:");

            };
            foreach (var item in restaurants)
            {
                Console.WriteLine($"{item.UID}. {item._name} ({item._type}) - Rating: {item._score}");
            }
            var amount = restaurants.Count();
            var avg = restaurants.Average(x => x._score);
            Console.WriteLine($"Total is {amount}");
            Console.WriteLine($"Average is {amount} ({avg})");
            {
                Console.WriteLine();
                Console.Write("พิมพ์ชื่อร้าน (บางส่วนก็ได้) เพื่อค้นหา: ");
                string keyword = Console.ReadLine()?.Trim();
        for (int i = 0; i < names.Count; i++)
        {
            Console.WriteLine(names[i] + " (" + types[i] + ") - " + ratings[i] + "/5");
        }

        // B feature/good-rating
        // แสดงเฉพาะร้านที่คะแนนตั้งแต่ 4.5 ขึ้นไป

                if (string.IsNullOrEmpty(keyword))
                {
                    Console.WriteLine("กรุณาพิมพ์คำค้นหา");
                    return;
                }

                var results = restaurants
                    .Where(r => r._name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                if (results.Count == 0)
                {
                    Console.WriteLine($"ไม่พบร้านที่มีคำว่า \"{keyword}\"");
                }
                else
                {
                    Console.WriteLine($"พบ {results.Count} ร้าน:");
                    foreach (var r in results)
                    {
                        Console.WriteLine($"{r.UID}. {r._name} ({r._type}) - Rating: {r._score}");
                    }
                }
            }
        }
            
    }
    public class Restaurant
    {
        public int UID { get; set; }
        public string _name { get; set; }
        public string _type { get; set; }
        public double _score { get; set; }
        Console.WriteLine("\nRestaurants with rating 4.5 or higher:");

        for (int i = 0; i < names.Count; i++)
        {
            if (ratings[i] >= 4.5)
            {
                Console.WriteLine(names[i] + " (" + types[i] + ") - Rating: " + ratings[i]);
            }
        }

        Console.ReadLine();
    }
}
