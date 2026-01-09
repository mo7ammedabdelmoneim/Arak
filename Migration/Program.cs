using Arak.Entities;
using Microsoft.Extensions.Configuration;

namespace Arak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding =System.Text.Encoding.UTF8;
            using (var context = new AppContext())
            {

                var students = context.Students.Select(s => s.Name);

                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }

            }



        }

        
        }
    }

