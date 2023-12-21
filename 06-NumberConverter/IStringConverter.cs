using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConverters
{
    public interface IStringConverter
    {
        int ConvertToInt(string numericString);
    }
}
