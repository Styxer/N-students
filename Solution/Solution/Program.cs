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
            Console.WriteLine("Hello World!");

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
                => attendees.SelectMany(lecture => lecture.Distinct().Intersect(students)) 
                            .GroupBy(x => x)
                            .Select(x => (Student : x.First(), Attendances: x.Count()))
                            .OrderByDescending(x => x.Attendances)
                            .Take(n);
    }
}
