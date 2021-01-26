using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebsite.Model
{
    public class Workout
    {
        [ForeignKey("TrainingBlock")]
        public int WorkoutID { get; set; }

        public string WorkoutName { get; set; }

        public virtual List<Exercise> Exercises { get; set; }

        public virtual TrainingBlock TrainingBlock { get; set; }

    }
}
