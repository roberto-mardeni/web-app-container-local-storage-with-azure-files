using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LocalStorageFileManager.Data;
using LocalStorageFileManager.Models;

namespace LocalStorageFileManager.Pages.File
{
    public class EditModel : PageModel
    {
        private readonly IFileManager _fileManager;

        public EditModel(IFileManager fileManager)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _fileManager.UpdateFile(FileItem, FileContent);

            return RedirectToPage("./Index");
        }
    }
}
