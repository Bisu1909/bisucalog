using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Interface
{
    interface IBDDFixture: IFixture
    {
        void BeforeScenario();
        void AfterScenario();
    }
}
