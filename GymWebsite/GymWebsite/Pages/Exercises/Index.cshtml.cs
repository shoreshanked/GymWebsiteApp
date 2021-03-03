using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymWebsite.Data;
using GymWebsite.Model;

namespace GymWebsite.Pages.Exercises
{
    public class IndexModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public IndexModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        public IList<Exercise> Exercise { get;set; }

        public async Task OnGetAsync(int? id)
        {
            if (id != null)
            {
                Exercise = await _context.Exercise
                                .Include(e => e.Workout)
                                .Where(w => w.WorkoutID == id)
                                .ToListAsync();

            }
            else
            {
                Exercise = await _context.Exercise
                                .Include(e => e.Workout).ToListAsync();
            }
           
        }
    }
}
