﻿namespace FolderHierarchy_GFL_.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }
    }
}
