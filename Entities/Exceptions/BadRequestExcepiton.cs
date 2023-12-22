using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public abstract class BadRequestExcepiton : Exception
    {
        protected BadRequestExcepiton(string message) : base(message)
        {

        }

    }
}
