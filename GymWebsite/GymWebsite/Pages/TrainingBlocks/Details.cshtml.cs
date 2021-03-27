using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymWebsite.Data;
using GymWebsite.Model;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace GymWebsite.Pages.TrainingBlocks
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public DetailsModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        public TrainingBlock TrainingBlock { get; set; }
        public IList<Workout> Workouts { get; set; }
        public IList<Exercise> Exercise { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainingBlock = await _context.TrainingBlock
                .Include(w => w.Workouts)
                .FirstOrDefaultAsync(m => m.TrainingBlockID == id);

            Workouts = await _context.Workout
                .Include(e => e.Exercises)
                .Where(m => m.TrainingBlockID == id)
                .ToListAsync();

            IDictionary<String, List<Tuple<int, int, double>>> ExerciseDictionary = new Dictionary<String, List<Tuple<int, int, double>>>(); 

            foreach (Workout workout in Workouts)
            {
                foreach(Exercise exercise in workout.Exercises)
                {
                    var tuple = new List<Tuple<int, int, double>>();

                    if (ExerciseDictionary.ContainsKey(exercise.Name))
                    {
                        tuple = ExerciseDictionary[exercise.Name];
                        tuple.Add(Tuple.Create(exercise.Reps, exercise.Sets, exercise.Weight));
                    }
                    else
                    {
                        tuple.Add(Tuple.Create(exercise.Reps, exercise.Sets, exercise.Weight));
                        ExerciseDictionary.Add(exercise.Name, tuple);
                    }
                }
            }

            var serializer = JsonSerializer.Serialize(ExerciseDictionary);
            ViewData["chartData"] = serializer;
            

            Exercise = await _context.Exercise
                                .Include(e => e.Workout)
                                .Where(w => w.WorkoutID == id)
                                .ToListAsync();

            if (TrainingBlock == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
