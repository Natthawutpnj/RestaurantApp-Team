using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ข้อมูลเริ่มต้น
            List<Restaurant> restaurants = new List<Restaurant>
            {
                new Restaurant(1, "Quanjude Roast Duck", "Beijing Cuisine", 4.5),
                new Restaurant(2, "Donglaishun Hot Pot", "Hot Pot", 4.6),
                new Restaurant(3, "Din Tai Fung", "Taiwanese Cuisine", 4.7),
                new Restaurant(4, "Huguosi Snacks", "Snacks", 4.2),
                new Restaurant(5, "Haidilao Hot Pot", "Hot Pot", 4.8)
            };

            // ---------- รับข้อมูลร้านใหม่จากคีย์บอร์ด ----------
            Console.Write("ชื่อร้าน: ");
            string name = Console.ReadLine();

            Console.Write("ประเภท: ");
            string type = Console.ReadLine();

            double rating;
            Console.Write("คะแนน (0-5): ");
            while (!double.TryParse(Console.ReadLine(), out rating) || rating < 0 || rating > 5)
            {
                Console.Write("กรุณากรอกตัวเลข 0-5: ");
            }

            int newId = restaurants.Max(r => r.UID) + 1;
            restaurants.Add(new Restaurant(newId, name, type, rating));
            Console.WriteLine("เพิ่มร้านเรียบร้อย");

            // ---------- แสดงร้านทั้งหมด ----------
            Console.WriteLine("\nรายการร้านทั้งหมด:");
            foreach (var item in restaurants)
            {
                Console.WriteLine($"{item.UID}. {item._name} ({item._type}) - Rating: {item._score}");
            }

            Console.WriteLine($"Total is {restaurants.Count}");
            Console.WriteLine($"Average is {restaurants.Average(x => x._score):F2}");

            // ---------- feature/good-rating: เฉพาะร้านคะแนน 4.5 ขึ้นไป ----------
            Console.WriteLine("\nRestaurants with rating 4.5 or higher:");
            foreach (var r in restaurants.Where(x => x._score >= 4.5))
            {
                Console.WriteLine($"{r._name} ({r._type}) - Rating: {r._score}");
            }

            // ---------- ค้นหาร้านจากชื่อบางส่วน ----------
            Console.WriteLine();
            Console.Write("พิมพ์ชื่อร้าน (บางส่วนก็ได้) เพื่อค้นหา: ");
            string keyword = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                Console.WriteLine("กรุณาพิมพ์คำค้นหา");
            }
            else
            {
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

            Console.ReadLine();
        }
    }

    public class Restaurant
    {
        public int UID { get; set; }
        public string _name { get; set; }
        public string _type { get; set; }
        public double _score { get; set; }

        public Restaurant(int uid, string name, string type, double score)
        {
            UID = uid;
            _name = name;
            _type = type;
            _score = score;
        }
    }
}