using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp_01.Bank;

internal class Privatkonto: Bankkonto
{
    public override double MaxUeberzug => 999_999;

    public override double AktivZins => 0.02;
    public Privatkonto() : base()
    { }



}
