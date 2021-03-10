using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymWebsite.Data;
using GymWebsite.Model;
using Microsoft.AspNetCore.Authorization;

namespace GymWebsite.Pages.Workouts
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public DeleteModel(GymWebsite.Data.GymWebsiteContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Workout = await _context.Workout.FindAsync(id);

            if (Workout != null)
            {
                _context.Workout.Remove(Workout);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
