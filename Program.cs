using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student("Alice", 85),
                new Student("Bob", 72),
                new Student("Charlie", 90),
                new Student("Diana", 65),
                new Student("Edward", 50)
            };

            // Instantiate ScoreProcessor
            var scoreProcessor = new ScoreProcessor();

            // Define criteria
            ScoreProcessor.ScoreCriteria isPassing = student => student.Score >= 60;
            ScoreProcessor.ScoreCriteria isFailing = student => student.Score < 60;

            // Filter students
            var passingStudents = scoreProcessor.StudentFilter(students, isPassing);
            var failingStudents = scoreProcessor.StudentFilter(students, isFailing);

            // Display results
            Console.WriteLine("Passing Students:");
            passingStudents.Print();

            Console.WriteLine("\nFailing Students:");
            failingStudents.Print();

            // Calculate and display average score
            double averageScore = scoreProcessor.CalculateAverage(students);
            Console.WriteLine($"\nAverage Score: {averageScore:F2}");

            // Find and display top scorer
            var topScorer = students.TopScorer();
            if (topScorer != null)
            {
                Console.WriteLine($"\nTop Scorer: {topScorer.Name}, Score: {topScorer.Score}");
            }


            Console.ReadKey();
        }
        static bool isGreaterThan50(Student student) => student.Score > 50;
  
    }
}
