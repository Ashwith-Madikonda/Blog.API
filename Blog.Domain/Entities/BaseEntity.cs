using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class BaseEntity : IBase
    {
        public  Guid Id { get; set; }
    }

    public interface IBase
    {
        public Guid Id { get; set; }
    }
}
