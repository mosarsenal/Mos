using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public int? TitleId { get; set; }
        public string UserName { get; set; }
        public string UserLast { get; set; }
        public int? UserType { get; set; }

        public Title Title { get; set; }
    }
}
