using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Title
    {
        public Title()
        {
            User = new HashSet<User>();
        }

        public int TitleId { get; set; }
        public string TitleName { get; set; }

        public ICollection<User> User { get; set; }
    }
}
