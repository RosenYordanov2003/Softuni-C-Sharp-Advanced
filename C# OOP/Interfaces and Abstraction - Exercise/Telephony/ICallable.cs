using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    interface ICallable
    {
        string Call(string number);
    }
}
