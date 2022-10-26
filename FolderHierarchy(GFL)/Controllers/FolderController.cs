using FolderHierarchy_GFL_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FolderHierarchy_GFL_.Controllers
{
    public class FolderController : Controller
    {
        private readonly FolderContext _context;

        public FolderController(FolderContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            return View(await _context.Folders.Where(x => x.ParentId == id).ToListAsync());
        }
    }
}
