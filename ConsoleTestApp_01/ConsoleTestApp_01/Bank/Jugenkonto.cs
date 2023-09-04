using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp_01.Bank
{
    internal class Jugendkonto : Bankkonto
    {
        public override double MaxUeberzug => 0;
        public override double MaxBezug => 9_999;
        public Jugendkonto() : base()
        { }
    }
}
