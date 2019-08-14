using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeApplication.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double Money { get; set; }
        public BlockStatus IsBlocked { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Comment> Comments { get; set; }
        public User()
        {
            Comments = new List<Comment>();
        }
    }
}
