using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class UserEntity : BaseEntity<int>
    {
        public string Description { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string LinkedInUrl { get; set; } = String.Empty;
        public string GitHubUrl { get; set; } = String.Empty;
        public string WhatsAppNumber { get; set; } = String.Empty;
    }
}
