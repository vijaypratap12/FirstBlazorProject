using FirstBlazorApp.Server.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBlazorApp.Shared
{
    public class ErrorResponseModel
    {

        public EnumResponseCode ResponseCode { get; set; }
        public string Message { get; set; }
        public ErrorResponseModel(EnumResponseCode enumResponseCode, string message)
        {
            ResponseCode= enumResponseCode;
            Message=message;
        }
    }
}
