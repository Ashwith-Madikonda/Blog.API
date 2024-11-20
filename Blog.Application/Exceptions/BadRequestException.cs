using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Response = Blog.Application.BaseResponse;


namespace Blog.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public Response Response { get; }

        public BadRequestException(string message)
            : base(message)
        {
            Response = Response.BadRequest(message);
        }
    }
}
