using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp_01.Bank;

internal class Privatkonto: Bankkonto
{
    public override double MaxUeberzug => 999_999;

    public override double AktivZins { get; set; } = 0.005;
    public override double PassivZins { get; set; } = 0.01;
    public Privatkonto() : base()
    { }



}
