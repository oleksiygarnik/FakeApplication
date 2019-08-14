using FakeApplication.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeApplication.Models.ViewModels
{
    public class IndexViewModel
    {
        public User User { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
