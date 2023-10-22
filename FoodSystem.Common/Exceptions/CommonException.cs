using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Common.Exceptions
{
    public class CommonException : Exception
    {
        public string ModuleName { get;}
        public string Message { get; }
        public CommonException(string moduleName, string message) : base(message)
        {
            ModuleName = moduleName;
            Message = message;
        }
    }
}
