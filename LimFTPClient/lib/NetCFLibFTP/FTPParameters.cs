using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace NetCFLibFTP
{
    class FTPParameters
    {
        static public AutoResetEvent EndResponseEvent;
        static public AutoResetEvent EndConnectEvent;
    }
}
