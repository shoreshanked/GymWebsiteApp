using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebsite.Model
{
    public class Exercise
    {
        
        public int ExerciseID { get; set; }

        public int WorkoutID { get; set; }

        public string Name { get; set; }

        public int Reps { get; set; }

        public int Sets { get; set; }

        public double Weight { get; set; }

        public Workout Workout { get; set; }
    }
}
