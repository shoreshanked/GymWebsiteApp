using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebsite.Model
{
    public class Exercise
    {
        
        public int ExerciseID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int WorkoutID { get; set; }

        public string Name { get; set; }

        public int Reps { get; set; }

        public int Sets { get; set; }

        public double Weight { get; set; }

        public Workout Workout { get; set; }
    }

    public enum ExerciseEnum
    {
        [Display(Name = "Bench Press")]
        BenchPress = 1,
        [Display(Name = "Squat")]
        Squat = 2,
        [Display(Name = "Military Press")]
        MilitaryPress = 3,
        [Display(Name = "Deadlift")]
        Deadlift = 4,
        [Display(Name = "Romanian Deadlift")]
        RomanianDeadlift = 5,
        [Display(Name = "Lateral Raise")]
        LateralRaise = 6,
        [Display(Name = "Standing Row")]
        StandingRow = 7,
        [Display(Name = "Pec Fly")]
        PecFly = 8,
        [Display(Name = "Pull Up")]
        PullUp = 9,
        [Display(Name = "Defecit Deadlift")]
        DefecitDeadlift = 10,
        [Display(Name = "Bicep Curl")]
        BicepCurl = 11,
        [Display(Name = "Hammer Curl")]
        HammerCurl = 12,
        [Display(Name = "Barbell Curl")]
        BarbellCurl = 13,
        [Display(Name = "Box Squat")]
        BoxSquat = 14,
        [Display(Name = "Incline Bench Press")]
        InclineBenchPress = 15,
        [Display(Name = "Leg Curl")]
        LegCurl = 16,
        [Display(Name = "Leg Extension")]
        LegExtensionv = 17,
    }

}
