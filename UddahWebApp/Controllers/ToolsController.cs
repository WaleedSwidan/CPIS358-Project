using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using UddahWebApp.Models;
using UddahWebApp.Data;

namespace UddahWebApp.Controllers
{
    // controller for the tools table in the database (Create, Read, Update, Delete and Search)
    // [Authorize] means the user must be logged in to use that method
    public class ToolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tools
        // shows all the tools from the database
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tool.ToListAsync());
        }

        // GET: Tools/SearchForm
        // opens the search page
        public async Task<IActionResult> SearchForm()
        {
            return View();
        }

        // POST: Tools/ShowSearchFormResult
        // receives the word from the search form and shows the tools that match it
        public async Task<IActionResult> ShowSearchFormResult(string SearchTool)
        {
            if (_context.Tool == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tool' is null.");
            }

            // search by the tool name or the category
            var filteredTools = await _context.Tool
                                              .Where(j => j.name.Contains(SearchTool) || j.category.Contains(SearchTool))
                                              .ToListAsync();

            // use the same Index page to show the result
            return View("Index", filteredTools);
        }

        // GET: Tools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tool
                .FirstOrDefaultAsync(m => m.id == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // GET: Tools/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tools/Create
        // receives the data from the Create form and adds a new tool to the database
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,category,description,pricePerDay,deposit")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tool);
        }

        // GET: Tools/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tool.FindAsync(id);
            if (tool == null)
            {
                return NotFound();
            }
            return View(tool);
        }

        // POST: Tools/Edit/5
        // receives the changed data and updates the tool in the database
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("id,name,category,description,pricePerDay,deposit")] Tool tool)
        {
            if (id != tool.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToolExists(tool.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tool);
        }

        // GET: Tools/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tool
                .FirstOrDefaultAsync(m => m.id == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // POST: Tools/Delete/5
        // removes the tool from the database
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var tool = await _context.Tool.FindAsync(id);
            if (tool != null)
            {
                _context.Tool.Remove(tool);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToolExists(int? id)
        {
            return _context.Tool.Any(e => e.id == id);
        }
    }
}