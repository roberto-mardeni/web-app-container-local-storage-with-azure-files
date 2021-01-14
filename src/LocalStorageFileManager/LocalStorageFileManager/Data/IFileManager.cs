using LocalStorageFileManager.Models;
using System.Collections.Generic;

namespace LocalStorageFileManager.Data
{
    public interface IFileManager
    {
        List<FileItem> GetFiles();

        FileItem GetFile(string name);
        string GetFileContent(FileItem fileItem);
        void CreateFile(FileItem fileItem, string content);
        void UpdateFile(FileItem fileItem, string content);
        void DeleteFile(FileItem name);

        void Seed();
    }
}
