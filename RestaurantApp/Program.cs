using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
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

            // แสดงผล
            Console.WriteLine("\nรายการร้านทั้งหมด:");
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i] + " (" + types[i] + ") - " + ratings[i] + "/5");
            }

            Console.ReadLine();
        }
    }
}