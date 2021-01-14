using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LocalStorageFileManager.Data;
using LocalStorageFileManager.Models;

namespace LocalStorageFileManager.Pages.File
{
    public class DeleteModel : PageModel
    {
        private readonly IFileManager _fileManager;

        public DeleteModel(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [BindProperty]
        public FileItem FileItem { get; set; }
        [BindProperty]
        public string FileContent { get; set; }

        public async Task<IActionResult> OnGetAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }

            FileItem = _fileManager.GetFile(name);

            if (FileItem == null)
            {
                return NotFound();
            }
            else
            {
                FileContent = _fileManager.GetFileContent(FileItem);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }

            FileItem = _fileManager.GetFile(name);

            _fileManager.DeleteFile(FileItem);

            return RedirectToPage("./Index");
        }
    }
}
