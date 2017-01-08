using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpGLWinformsApplication1
{
    class sqlConnection
    {
        public string str = "server=.;database=PlatformFlawBase;Integrated Security=SSPI;";
        public string getconn()
        {
            string ConnectionString = str;
            return ConnectionString;
        }
    }
}
