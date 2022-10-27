using FolderHierarchy_GFL_.Models;
using FolderHierarchy_GFL_.ViewModels;
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
            FoldersViewModel folderViewModel = new FoldersViewModel();
            folderViewModel.Id = id;
            folderViewModel.Name = _context.Folders.Where(x => x.Id == id).FirstOrDefault().Name;
            folderViewModel.Childrens = await _context.Folders.Where(x => x.ParentId == id).ToListAsync();

            return View(folderViewModel);
        }
    }
}
