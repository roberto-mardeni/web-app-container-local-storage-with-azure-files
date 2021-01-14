using LocalStorageFileManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LocalStorageFileManager.Data
{
    public class LocalFileManager : IFileManager
    {
        private string _path;

        public LocalFileManager(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            _path = path;
        }

        private string GetAbsolutePath(FileItem fileItem)
        {
            return Path.Combine(_path, fileItem.Name);
        }

        public void CreateFile(FileItem fileItem, string content)
        {
            File.AppendAllText(GetAbsolutePath(fileItem), content);
        }

        public void DeleteFile(FileItem fileItem)
        {
            File.Delete(GetAbsolutePath(fileItem));
        }

        public string GetFileContent(FileItem fileItem)
        {
            return File.ReadAllText(GetAbsolutePath(fileItem));
        }

        public List<FileItem> GetFiles()
        {
            var items = new List<FileItem>();

            foreach (var i in Directory.GetFiles(_path))
            {
                items.Add(GetFile(i));
            }

            return items;
        }

        public void UpdateFile(FileItem fileItem, string content)
        {
            File.WriteAllText(GetAbsolutePath(fileItem), content);
        }

        public void Seed()
        {
            var r = new Random(DateTime.Now.Millisecond);

            for (int n = 1; n <= 10; n++)
            {
                var content = new StringBuilder();
                var lines = r.Next(10, 100);

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

                CreateFile(new FileItem { Name = $"File{n}.txt" }, content.ToString());
            }
        }

        public FileItem GetFile(string name)
        {
            var fullpath = name.StartsWith(_path) ? name : Path.Combine(_path, name);
            var info = new FileInfo(fullpath);

            return new FileItem { Name = info.Name, Size = info.Length };
        }
    }
}
