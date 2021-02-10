using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymWebsite.Data;
using GymWebsite.Model;

namespace GymWebsite.Pages.Workouts
{
    public class CreateModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public CreateModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TrainingBlockId"] = new SelectList(_context.TrainingBlock, "ID", "BlockName");
            return Page();
        }

        [BindProperty]
        public Workout Workout { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workout.Add(Workout);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
