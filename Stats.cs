using System;

namespace GradeBook
{
    public class Stats
    {
        public double Average
        {
            get { return Sum / Count; }
        }


        public double High;
        public double Low;

        public double NumGrade
        {
            get
            {
                switch (Average) //switch pokazujacy ocene koncowa
                {
                    case var d when d >= 90.0:
                        return 5;
                    case var d when d >= 80.0:
                        return 4.5;
                    case var d when d >= 70.0:
                        return 4;
                    case var d when d >= 60.0:
                        return 3.5;
                    case var d when d >= 51.0:
                        return 3;
                    case var d when d < 51.0:
                        return 2;

                    default:
                        return 2;

                }
            }
        }

        public double Sum;
        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            High = Math.Max(number, High); //przyrowywanie z namniejsza zeby dostac wyzsza liczbe
            Low = Math.Min(number, Low);   // przyrownywanie z najwieksza zeby dostac nizsza liczbe
        }

        public Stats()
        {
            Sum = 0.0;
            Count = 0;
            High = double.MinValue; //zeby zawsze pokazywalo najwieksza wartosc przy porownywanie High posiada najmniejsza wartosc
            Low = double.MaxValue; //zeby zawsze pokazywalo wartosc najmniejsza Low posiada najwieksza wartosc
        }

    }
}