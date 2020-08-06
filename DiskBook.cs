using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeBook
{
    public class DiskBook : Book // klasa ktora bedzie zapisywac do pliku 
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                using (var writer = File.AppendText($"{Name}.txt")) //utworzenie pliku o takiej samej nazwie jak podana
                {
                    writer.WriteLine(grade); //wpisanie oceny do pliku tylko wtedy kiedy uzywamy
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Stats GetStats()
        {
            var result = new Stats();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();

                while (line != null) //kiedy line = null wiemy, ze koniec pliku
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }

        public override event InMemoryBook.GradeAddedDelegate GradeAdded;
    }
}