﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymWebsite.Data;
using GymWebsite.Model;
using Microsoft.AspNetCore.Authorization;

namespace GymWebsite.Pages.TrainingBlocks
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public EditModel(GymWebsite.Data.GymWebsiteContext context)
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
           ViewData["FirstName"] = new SelectList(_context.User, "ID", "FirstName");
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

            _context.Attach(TrainingBlock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingBlockExists(TrainingBlock.TrainingBlockID))
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

        private bool TrainingBlockExists(int id)
        {
            return _context.TrainingBlock.Any(e => e.TrainingBlockID == id);
        }
    }
}
