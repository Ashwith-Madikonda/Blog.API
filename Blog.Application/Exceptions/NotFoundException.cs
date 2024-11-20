using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Response = Blog.Application.BaseResponse;

namespace Blog.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public Response Response { get; }

        public NotFoundException(string entityName, Guid id)
          : base($"{entityName} with id {id} not found")
        {
            Response = Response.NotFound(Message);
        }
    }
}
