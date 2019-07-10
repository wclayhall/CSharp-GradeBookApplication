using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked Grading requires 5 or more students.");
            }

            var numToDrop = (int)Math.Ceiling(this.Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[numToDrop - 1] <= averageGrade)
                return 'A';
            else if (grades[numToDrop * 2 - 1] <= averageGrade)
                return 'B';
            else if (grades[numToDrop * 3 - 1] <= averageGrade)
                return 'C';
            else if (grades[numToDrop * 4 - 1] <= averageGrade)
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}