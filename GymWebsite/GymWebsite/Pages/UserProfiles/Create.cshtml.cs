﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymWebsite.Data;
using GymWebsite.Model;

namespace GymWebsite.Pages.UserProfiles
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
        ViewData["UserID"] = new SelectList(_context.User, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public UserProfile UserProfile { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserProfile.Add(UserProfile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
