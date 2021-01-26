using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymWebsite.Data;
using GymWebsite.Model;

namespace GymWebsite.Pages.Workouts
{
    public class EditModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public EditModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Workout Workout { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Workout = await _context.Workout
                .Include(w => w.TrainingBlock).FirstOrDefaultAsync(m => m.WorkoutID == id);

            if (Workout == null)
            {
                return NotFound();
            }
           ViewData["WorkoutID"] = new SelectList(_context.TrainingBlock, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(Workout.WorkoutID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WorkoutExists(int id)
        {
            return _context.Workout.Any(e => e.WorkoutID == id);
        }
    }
}
