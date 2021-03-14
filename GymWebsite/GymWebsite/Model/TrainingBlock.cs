using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebsite.Model
{
    public class TrainingBlock
    {
        public int TrainingBlockID { get; set; }

        public string BlockName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime BlockStartDate { get; set; }

        public DateTime BlockEndDate { get; set; }

        public  int UserID { get; set; }

        public User User { get; set; }

        public ICollection<Workout> Workouts { get; set; }
    }
}

    