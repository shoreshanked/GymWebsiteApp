﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymWebsite.Data;
using GymWebsite.Model;
using Microsoft.AspNetCore.Authorization;

namespace GymWebsite.Pages.TrainingBlocks
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public DetailsModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        public TrainingBlock TrainingBlock { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainingBlock = await _context.TrainingBlock
                .Include(w => w.Workouts)
                .FirstOrDefaultAsync(m => m.TrainingBlockID == id);

            if (TrainingBlock == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
