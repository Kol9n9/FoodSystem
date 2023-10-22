using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Common.Exceptions
{
    public class StartIntevalLargerEnd : DateTimeException
    {
        public StartIntevalLargerEnd(string moduleName) : base(moduleName, "Начало интервала больше конца")
        {
        }
    }
}
