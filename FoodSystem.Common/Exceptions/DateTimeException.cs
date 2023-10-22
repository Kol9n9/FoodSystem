using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Common.Exceptions
{
    public class DateTimeException : CommonException
    {
        public DateTimeException(string moduleName,string message) : base(moduleName,message)
        {
        }
    }
}
