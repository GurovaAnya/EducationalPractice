using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_11
{
    class DecodingErrorException:Exception
    {
        public DecodingErrorException() : base() { }
        public DecodingErrorException(string message) : base(message) { }
        public override string ToString()
        {
            return Message;
        }
    }
}
