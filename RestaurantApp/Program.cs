
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

        for (int i = 0; i < names.Count; i++)
        {
            Console.WriteLine(names[i] + " (" + types[i] + ") - " + ratings[i] + "/5");
        }

        // B feature/good-rating
        // แสดงเฉพาะร้านที่คะแนนตั้งแต่ 4.5 ขึ้นไป

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
