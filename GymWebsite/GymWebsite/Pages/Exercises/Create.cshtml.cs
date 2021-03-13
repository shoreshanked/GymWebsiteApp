using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymWebsite.Data;
using GymWebsite.Model;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace GymWebsite.Pages.Exercises
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public CreateModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        public string GetExerciseDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }

        public List<string> SetExerciseList()
        {
            
            var exerciseList = new List<ExerciseEnum>();
            exerciseList = Enum.GetValues(typeof(ExerciseEnum)).Cast<ExerciseEnum>().ToList();

            var exerciseDisplayNameList = new List<String>();
 
            foreach (ExerciseEnum item in exerciseList)
            {
                //Call to GetExerciseDisplayName method and assign returned DisplayAttribute to exerciseDisplayNameList list
                var exerciseDisplayName = GetExerciseDisplayName(item);
                exerciseDisplayNameList.Add(exerciseDisplayName);
            }

            //List of Enum DisplayAttribute returned to IActionResult OnGet below, to populate an HTML select list
            return exerciseDisplayNameList;
        }

        public IActionResult OnGet(int? id)
        {
            
            ViewData["ExerciseDisplayNameList"] = new SelectList(SetExerciseList());

            if (id != null)
            {
                TempData["id"] = id;
                var workout = _context.Workout.FirstOrDefault(w => w.WorkoutID == id);
                ViewData["WorkoutName"] = workout.WorkoutName;

            }
            else
            {
                ViewData["WorkoutName"] = new SelectList(_context.Workout, "WorkoutID", "WorkoutName");
            }


            return Page();
        }

        [BindProperty]
        public Exercise Exercise { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //
        //public async Task<IActionResult> OnPostAsync()
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            
            if (id != null)
            {
                Exercise.WorkoutID = Convert.ToInt32(id);
            }
            
             
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Exercise.Add(Exercise);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = id });
        }
    }

}
