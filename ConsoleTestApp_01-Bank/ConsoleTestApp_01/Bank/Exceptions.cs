using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp_01.Bank;

internal class MaxUerbzugException : Exception
{
    public MaxUerbzugException() : base() { }
    public MaxUerbzugException(string message) : base(message)
    {
    }
    public MaxUerbzugException(string message, Exception innerException) : base(message, innerException) { }
}
internal class MaxBezugException : Exception
{
    public MaxBezugException() : base() { }
    public MaxBezugException(string message) : base(message) { }
    public MaxBezugException(string message, Exception innerException) : base(message, innerException) { }
}
