using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {

            var students = new List<string> { "Eden", "Refael", "Yoni", "Nitzan", "Hadas" };

            var attendess = new List<List<string>>
            {
                new List<string>{"Eden", "Refael", "Yoni", "Nitzan", "Hadas", "Ortal", },
                new List<string>{"Berry", "Nitzan", "Yoni", "Eden", "Hadas", "Ortal" },
                new List<string>{"Maxim", "Ortal", "Yoni", "Refael", "Nitzan", "Alex" },
                new List<string>{"Eden", "Andrew", "Yoni", "Nitzan", "Ortal","Nitzan" },

            };

            foreach (var entry in TopStudents(students, attendess, 3))
            {
                Console.WriteLine($"{entry.Student}: {entry.Attendances}");
            }
        }



        static IEnumerable<(string Student, int Attendances)> TopStudents(IEnumerable<string> students
            , IEnumerable<IEnumerable<string>> attendees,
             int n)
        {
            if (students?.Count() > 0 && attendees?.Count() > 0 && n >= 0)
            {
                if (n > students.Count())
                    n = students.Count();

                return attendees.SelectMany(lecture => lecture.Distinct().Intersect(students)) // remove non students and duplicates attendees
                            .GroupBy(x => x)
                            .Select(x => (Student: x.First(), Attendances: x.Count())) //grouping back the result
                            .OrderByDescending(x => x.Attendances) //ordering them from high to low by the number of times they showed
                            .Take(n); //returning the first highest N
            }
            else
                return null;
        }
    }
}
