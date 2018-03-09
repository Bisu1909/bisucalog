using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Demo
{
    public interface IDataService
    {
        int Count();
    }

    public class DataService : IDataService
    {
        public int Count()
        {
            return 1000;
        }
    }
}
