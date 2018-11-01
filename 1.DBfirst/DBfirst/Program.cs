using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBfirst
{
    class Program
    {
        static void Main(string[] args)
        {
             var dbContex = new PlutoDbContex();
            var courses = dbContex.GetCourses();

            foreach (var course in courses)
            {
                Console.WriteLine(course.Title +" "+ course.Description);
            }

            Console.ReadKey();
        }
    }
}
