using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Common.Interfaces
{
    public interface IApplicationDBContext
    {
        DbSet<UserEntity> User { get; set; }
        Task<int> SaveChangesAsync();
    }
}
