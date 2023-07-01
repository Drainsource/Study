using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemoLib
{
    public class Messages : IMessages
    {
        public string SayHello() => "Hello";

        public string SayGoodBye() => "Goodbye";

    }
}
