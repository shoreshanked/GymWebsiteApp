using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebsite.Model
{

    public class Workout
    {
        public int WorkoutID { get; set; }

        public int TrainingBlockID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string WorkoutName { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public TrainingBlock TrainingBlock { get; set; }

    }
}
