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

        public IActionResult OnGet(int? id)
        {

            if (id != null)
            {
                TempData["id"] = id;

                var trainingBlock = _context.TrainingBlock.FirstOrDefault(w => w.TrainingBlockID == id);
                ViewData["BlockName"] = trainingBlock.BlockName;
            }
            else
            { 
                // if the ID is null then we need to hide the text input in HTML and show a select list for them to choose manually, using the below
                ViewData["BlockName"] = new SelectList(_context.TrainingBlock, "TrainingBlockID", "BlockName");
               
            }
            

            return Page();
        }

        [BindProperty]
        public Workout Workout { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int id)
        {
            Workout.TrainingBlockID = id;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workout.Add(Workout);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = id });
        }
    }
}
