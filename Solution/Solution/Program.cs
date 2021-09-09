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

            TopStudents(students, attendess, 5);
        }

        static void TopStudents(IEnumerable<string> student, IEnumerable<IEnumerable<string>> attendees, int n)
        {
            var dic = new Dictionary<string,int>();
            foreach (var attendee in attendees)
            {
                var aa = attendee.Distinct().Intersect(student);
                for (int i = 0; i < aa.Count(); i++)
                {
                    var item = aa.ElementAt(i);
                    if (dic.TryGetValue(item, out int count))
                    {
                        dic[item] = count + 1;
                    }
                    else
                    {
                        dic.Add(item, 1);
                    }
                }     
               
            }

            foreach (var item in dic)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            Console.Read();
        }
    }
}
