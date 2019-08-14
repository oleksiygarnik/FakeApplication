using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeApplication.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }
 
    }
}
