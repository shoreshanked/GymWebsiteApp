using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymWebsite.Data;
using GymWebsite.Model;

namespace GymWebsite.Pages.Exercises
{
    public class CreateModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public CreateModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
        TempData["id"] = id;
        //ViewData["WorkoutName"] = new SelectList(_context.Workout, "WorkoutID", "WorkoutName");

        var workout = _context.Workout.FirstOrDefault(w => w.WorkoutID == id);
        ViewData["WorkoutName"] = workout.WorkoutName;
        

            return Page();
        }

        [BindProperty]
        public Exercise Exercise { get; set; }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //
        //public async Task<IActionResult> OnPostAsync()
        public async Task<IActionResult> OnPostAsync(int id)
        {
            Exercise.WorkoutID = id;
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
