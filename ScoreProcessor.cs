using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
    internal class ScoreProcessor
    {
        public delegate bool ScoreCriteria(Student student);
        List<Student> students;

        public List<Student> StudentFilter(List<Student> students, ScoreCriteria ScoreFilter)
        {
            List<Student> result = new List<Student>();
            foreach (Student student in students)
            {
                if (ScoreFilter(student))
                {
                    result.Add(student);
                }
            }
            return result;
        }

        public void PrintScore(List<Student> students)
        {

            foreach (Student student in students)
            {
                Console.WriteLine(student.Score);

            }
        }

        //public double CalcAverage(List<Student> students, Func<List<Student>, double> average)
        //{

        // to be studied later

        //}
    }
    }
