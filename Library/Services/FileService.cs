
using System.Diagnostics;
using System.Text.Json;
using Library.Interfaces;

namespace Library.Services;


    public class FileService : IFileService
    {

        private readonly string _directoryPath;
        private readonly string _filePath;
        

    public FileService(string directoryPath, string fileName)
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    public string GetContentFromFile()
        {
            if (File.Exists(_filePath))
                return File.ReadAllText(_filePath);

            return null!;
        }

        public void SaveContentToFile(string content)
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            File.WriteAllText(_filePath, content);
        }
    }
