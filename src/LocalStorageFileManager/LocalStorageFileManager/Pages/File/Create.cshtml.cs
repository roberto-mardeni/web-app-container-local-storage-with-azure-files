using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LocalStorageFileManager.Data;
using LocalStorageFileManager.Models;
using System.Text;

namespace LocalStorageFileManager.Pages.File
{
    public class CreateModel : PageModel
    {
        private readonly IFileManager _fileManager;

        public CreateModel(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FileItem FileItem { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var content = new StringBuilder();
            var lines = new Random(DateTime.Now.Millisecond).Next(10, 100);

            for (int i = 0; i < lines; i++)
            {
                content.AppendLine(FileItem.SEED_TEXT);
                content.AppendLine(FileItem.SEED_TEXT);
                content.AppendLine(FileItem.SEED_TEXT);
                content.AppendLine(FileItem.SEED_TEXT);
                content.AppendLine(FileItem.SEED_TEXT);
                content.AppendLine(FileItem.SEED_TEXT);
                content.AppendLine(FileItem.SEED_TEXT);
                content.AppendLine(FileItem.SEED_TEXT);
                content.AppendLine(FileItem.SEED_TEXT);
                content.AppendLine(FileItem.SEED_TEXT);
            }

            _fileManager.CreateFile(this.FileItem, content.ToString());

            return RedirectToPage("./Index");
        }
    }
}
