using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebsite.Model
{
    public class Exercise
    {
        
        public int ID { get; set; }

        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }

        public string Name { get; set; }

        public int Reps { get; set; }

        public int Sets { get; set; }

        public double Weight { get; set; }

        public virtual Workout Workout { get; set; }
    }
}
