using FolderHierarchy_GFL_.Models;

namespace FolderHierarchy_GFL_.ViewModels
{
    public class FoldersViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public List<Folder>? Childrens { get; set; }
    }
}
