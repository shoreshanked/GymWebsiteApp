using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymWebsite.Data;
using GymWebsite.Model;

namespace GymWebsite.Pages.TrainingBlocks
{
    public class DeleteModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public DeleteModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrainingBlock TrainingBlock { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainingBlock = await _context.TrainingBlock
                .Include(t => t.User).FirstOrDefaultAsync(m => m.TrainingBlockID == id);

            if (TrainingBlock == null)
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

            TrainingBlock = await _context.TrainingBlock.FindAsync(id);

            if (TrainingBlock != null)
            {
                _context.TrainingBlock.Remove(TrainingBlock);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
