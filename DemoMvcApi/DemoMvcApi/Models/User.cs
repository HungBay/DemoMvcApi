using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMvcApi.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid(); // tu sinh khoa k trung lap
            Status = Status.Active;
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }
    }

    
}
