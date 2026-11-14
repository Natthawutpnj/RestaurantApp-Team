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

            int newId = restaurants.Count == 0 ? 1 : restaurants.Max(r => r.UID) + 1;
            restaurants.Add(new Restaurant(newId, name, type, rating));
            Console.WriteLine("เพิ่มร้านเรียบร้อย");

            // ---------- แสดงร้านทั้งหมด ----------
            Console.WriteLine("\nรายการร้านทั้งหมด:");
            foreach (var item in restaurants)
            {
                Console.WriteLine($"{item.UID}. {item._name} ({item._type}) - Rating: {item._score}");
            }

            // ---------- feature/good-rating ----------
            Console.WriteLine("\nRestaurants with rating 4.5 or higher:");
            var good = restaurants.Where(x => x._score >= 4.5).ToList();
            if (good.Count == 0)
            {
                Console.WriteLine("ไม่มีร้านที่คะแนน 4.5 ขึ้นไป");
            }
            else
            {
                foreach (var g in good)
                {
                    Console.WriteLine($"{g._name} ({g._type}) - Rating: {g._score}");
                }
            }

            // ---------- feature/summary ----------
            if (restaurants.Count > 0)
            {
                double maxScore = restaurants.Max(x => x._score);
                double minScore = restaurants.Min(x => x._score);

                Console.WriteLine();
                Console.WriteLine("=== Summary ===");
                Console.WriteLine($"Total is {restaurants.Count}");
                Console.WriteLine($"Average is {restaurants.Average(x => x._score):F2}");

                Console.WriteLine("Highest:");
                foreach (var h in restaurants.Where(x => x._score == maxScore))
                    Console.WriteLine($"  {h._name} ({h._type}) - Rating: {h._score}");

                Console.WriteLine("Lowest:");
                foreach (var l in restaurants.Where(x => x._score == minScore))
                    Console.WriteLine($"  {l._name} ({l._type}) - Rating: {l._score}");
            }

            // ---------- feature/search-restaurant ----------
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
                    .Where(x => x._name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                if (results.Count == 0)
                {
                    Console.WriteLine($"ไม่พบร้านที่มีคำว่า \"{keyword}\"");
                }
                else
                {
                    Console.WriteLine($"พบ {results.Count} ร้าน:");
                    foreach (var s in results)
                    {
                        Console.WriteLine($"{s.UID}. {s._name} ({s._type}) - Rating: {s._score}");
                    }
                }
            }

            Console.ReadLine(); // ค้างหน้าจอไว้ท้ายสุด
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