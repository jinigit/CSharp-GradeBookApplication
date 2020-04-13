using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            var boundry = (int)Math.Ceiling(Students.Count * 0.2);
            var studentAverage = Students.OrderByDescending(x => x.AverageGrade)
                                .Select(x=>x.AverageGrade).ToArray();
            try
            {
                switch (averageGrade)
                {
                    case var d when d >= studentAverage[boundry - 1]:
                        return 'A';
                    case var d when d >= studentAverage[2 * boundry - 1]:
                        return 'B';
                    case var d when d >= studentAverage[3 * boundry - 1]:
                        return 'C';
                    case var d when d >= studentAverage[4 * boundry - 1]:
                        return 'D';
                    default:
                        return 'F';
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades " +
                    "in order to properly calculate a student's overall grade.");
                return;
            }
           
            base.CalculateStatistics();
            
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires " +
                    "at least 5 students with grades in order " +
                    "to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

    }
}
