using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LocalStorageFileManager.Data;
using LocalStorageFileManager.Models;

namespace LocalStorageFileManager.Pages.File
{
    public class IndexModel : PageModel
    {
        private readonly IFileManager _fileManager;

        public IndexModel(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public IList<FileItem> FileItem { get;set; }

        public void OnGet()
        {
            var files = _fileManager.GetFiles();
            files.Sort(new Comparison<FileItem>((a, b) => string.Compare(a.Name, b.Name)));
            FileItem = files;
        }
    }
}
