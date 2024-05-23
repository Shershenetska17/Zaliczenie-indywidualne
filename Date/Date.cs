using System;
using System.Collections.Generic;

namespace Date
{
    public class Plyta
    {
        public string Tytul;
        public string Typ;
        public List<Utwor> Utwory;
        public List<string> Wykonawcy;
        public int NumerPlyty;

        public Plyta()
        {
            Utwory = new List<Utwor>();
            Wykonawcy = new List<string>();
        }

    }
    public class Utwor
    {
        public string Tytul;
        public int CzasTrwaniaMinuty;
        public int CzasTrwaniaSekundy;
        public List<string> Wykonawcy;
        public string Kompozytor;
        public int NumerUtworu;
        public string Wykonawca;

        public Utwor()
        {
            Wykonawcy = new List<string>();
        }
    }

}
