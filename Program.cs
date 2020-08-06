using GradeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBookJA
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Mój Dziennik");
            book.GradeAdded += OnGradeAdded;//wyswietlenie info ze ocena zostala dodana poprzez delegat

            EnterGrades(book);


            var stats = book.GetStats(); //pobranie statystyk


            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The number grade is {stats.NumGrade:N1}");

        }
        static void EnterGrades(IBook inMemoryBook)
        {
            while (true) //petla ktora sie bedzie wykonywac w nieskoczonosc dopoki nie wcisnie sie q
            {
                Console.WriteLine("Add grade or press q to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try //chwytanie wyjatku
                {
                    var grade = double.Parse(input);
                    inMemoryBook.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
