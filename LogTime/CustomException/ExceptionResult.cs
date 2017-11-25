using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTime.CustomException
{
    public class ExceptionResult
    {
        
        public ExceptionResult(string code, string message)
        {
            this.code = code;
            this.message = message;
        }

        public ExceptionResult() { }

        public string code { get; set; }
        public string message { get; set; }
    }
}
