using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tines
{
    public class ServiceFailedException : Exception
    {
        public ServiceFailedException()
            : base("Service failure") { }

        public ServiceFailedException(Exception exception)
            : base("Service Failure", exception) { }
    }
}
