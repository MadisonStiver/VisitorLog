using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisitorLog.Data;
using VisitorLog.Models;

namespace VisitorLog
{
    public class IndexModel : PageModel
    {
        private readonly VisitorLogContext _context;
        public IndexModel(VisitorLogContext context) { _context = context; }
        [BindProperty(SupportsGet = true)] public IList<Visit> Visits { get; set; }
        [BindProperty(SupportsGet = true)] public Visit Visit { get; set; }
        [BindProperty(SupportsGet = true)] public UpdateModel Update { get; set; }
        public class UpdateModel {
            public int Id { get; set; }
            public DateTime VisitDt { get; set; }
            public string Location { get; set; }
            public string AttendeeName { get; set; }
            public string AttendeeGroup { get; set; }
            public string HelperName { get; set; }
            public string HelperGroup { get; set; }
            public string Task { get; set; }
            public string Resolution { get; set; }
            public string Tags { get; set; } }

        // OnGet (to load table)
        public async Task OnGetAsync(){ Visits = await _context.Visit.ToListAsync(); }

        // Create OnPost
        public async Task<IActionResult> OnPostInsertAsync()
        {
            // Add if statement here to check for nulls and return a StatusMessage instead of adding.
            _context.Visit.Add(Visit);
            await _context.SaveChangesAsync();
            Visits = await _context.Visit.ToListAsync();
            return RedirectToPage("./Index");
        }

        // Update OnPost
        public async Task<IActionResult> OnPostUpdateAsync(int Id)
        {
            // Find the current entry
            Visit = await _context.Visit.FirstOrDefaultAsync(m => m.Id == Id);

            // Set my updates in the entry
            if (Update.VisitDt != Visit.VisitDt) { Visit.VisitDt = Update.VisitDt; }
            if (Update.Location != Visit.Location) { Visit.Location = Update.Location; }
            if (Update.AttendeeName != Visit.AttendeeName) { Visit.AttendeeName = Update.AttendeeName; }
            if (Update.AttendeeGroup != Visit.AttendeeGroup) { Visit.AttendeeGroup = Update.AttendeeGroup; }
            if (Update.HelperName != Visit.HelperName) { Visit.HelperName = Update.HelperName; }
            if (Update.HelperGroup != Visit.HelperGroup) { Visit.HelperGroup = Update.HelperGroup; }
            if (Update.Task != Visit.Task) { Visit.Task = Update.Task; }
            if (Update.Resolution != Visit.Resolution) { Visit.Resolution = Update.Resolution; }
            if (Update.Tags != Visit.Tags) { Visit.Tags = Update.Tags; }

            // Attach changes and save, then re-load the table and page
            _context.Attach(Visit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            Visits = await _context.Visit.ToListAsync();
            return RedirectToPage("./Index");
        }

        // Delete OnPost
        public async Task<IActionResult> OnPostDeleteAsync(int Id)
        {
            Visit = await _context.Visit.FindAsync(Id);
            _context.Visit.Remove(Visit);
            await _context.SaveChangesAsync();

            Visits = await _context.Visit.ToListAsync();

            return RedirectToPage("./Index");
        }
    }
}
