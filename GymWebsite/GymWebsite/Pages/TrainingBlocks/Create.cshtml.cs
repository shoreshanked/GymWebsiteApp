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

namespace GymWebsite.Pages.TrainingBlocks
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public CreateModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FirstName"] = new SelectList(_context.User, "ID", "FirstName");
            return Page();
        }

        [BindProperty]
        public TrainingBlock TrainingBlock { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TrainingBlock.Add(TrainingBlock);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
