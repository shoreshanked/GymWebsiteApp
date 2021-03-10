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

namespace GymWebsite.Pages.Exercises
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public DetailsModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        public Exercise Exercise { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exercise = await _context.Exercise
                .Include(e => e.Workout).FirstOrDefaultAsync(m => m.ExerciseID == id);

            if (Exercise == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
