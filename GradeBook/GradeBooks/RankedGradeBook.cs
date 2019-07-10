using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

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
            if(this.Students.Count <5)
            {
                throw new InvalidOperationException("Ranked Grading requires 5 or more students.");
            }

            var numToDrop = (int)Math.Ceiling(this.Students.Count * 0.2) ;
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
    }
}
