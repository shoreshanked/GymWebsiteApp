using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebsite.Model
{
    public class UserProfile
    {
        [ForeignKey("User")]
        public int UserProfileId { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public string Username { get; set; }

        public virtual User User { get; set; }


    }
}
