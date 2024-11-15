using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
    internal static class Extensions
    {
        public static void Print(this List<Student> students)
        {
            foreach (var student in students) Console.WriteLine($"Name : {student.Name} => {student.Score}");
        }
        public static Student TopScorer(this List<Student> students)
        {

            var stds = students.OrderByDescending(x => x.Score);

            var std = stds.FirstOrDefault();

            return std;
        }
    }
}
