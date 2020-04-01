using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_6
{
    class AllMultiplesReadyException:Exception
    {
        public AllMultiplesReadyException () : base() { }
        public AllMultiplesReadyException (string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
}
