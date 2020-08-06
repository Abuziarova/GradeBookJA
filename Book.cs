using System;
using System.Collections.Generic;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook  // klasa abstrakcyjna poniewaz jeszcze nie wiem jak bedzie wygladac dziennik
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);
        public abstract Stats GetStats();

        public abstract event InMemoryBook.GradeAddedDelegate GradeAdded;
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Stats GetStats();
        string Name { get; }
        event InMemoryBook.GradeAddedDelegate GradeAdded;

    }

    public class InMemoryBook : Book
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);


        public InMemoryBook(string name) : base(name)//utworzenie nowego dziennika, przekazanie imienia z klasy bazowej 
        {
            grades = new List<double>();
            Name = name;
        }
        public override void AddGrade(double grade) //dodanie oceny(wartosci punktowej jak na wsb); przeciazenie klasy z abstracyjnej klasy bazowej
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs()); //ogloszenie "swiatu" ze ocena została utworzona(tylko jak zostala utworzona)
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        public override event GradeAddedDelegate GradeAdded; //przeciazenie virtualnego eventu z klasy bazowej

        public override Stats GetStats() // obliczenie statystyk
        {
            var result = new Stats();



            for (var index = 0; index < grades.Count; index++)
            {

                result.Add(grades[index]);

            }

            return result;

        }

        private List<double> grades;



    }
}
