using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebsite.Model
{
    public class User
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        private string Password { get; set; }

        public ICollection<TrainingBlock> TrainingBlocks { get; set; }
    }
}
