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

        [Route("{**path}")]
        public async Task<IActionResult> Index(string path)
        {
            FoldersViewModel folderViewModel = new FoldersViewModel();

            if (path == null)
            {
                return View("Views/Home/Index.cshtml");
            }
          
            folderViewModel.Name = path.Split('/').LastOrDefault("");
            folderViewModel.Path += path;
            folderViewModel.Id = _context.Folders.FirstOrDefault(x => x.Name == folderViewModel.Name)?.Id;
            folderViewModel.Childrens = await _context.Folders.Where(x => x.ParentId == folderViewModel.Id).ToListAsync();

            return View(folderViewModel);
        }
    }
}
