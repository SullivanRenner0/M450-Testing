using ConsoleTestApp_02.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp_02.Interfaces
{
    internal interface IEngineControl
    {
        void EngineStart();
        void EngineStop();
        void UpdateCheck();
        void DoUpdate();
        void UpdateReady();
        void VoltageLow();
    }

    
}
