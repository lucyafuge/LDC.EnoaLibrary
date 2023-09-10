using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDC.EnoaLibrary.Classes
{
    public class Response
    {
        public uint ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public object Result { get; set; }

        public Response()
        {
            ErrorCode = 0;
            ErrorMessage = null;
            Result = new object();
        }
    }
}
