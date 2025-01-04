
using System.Diagnostics;
using System.Text.Json;
using Library.Interfaces;
using Library.Models;

namespace Library.Services;


public class FileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public FileService(string directoryPath = "Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

    }



    public void SaveListToFile(List<User> list)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);

            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public List<User> LoadListFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
                return [];

            var json = File.ReadAllText(_filePath);
            var list = JsonSerializer.Deserialize<List<User>>(json, _jsonSerializerOptions);
            return list ?? [];
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }
}


//public class FileService : IFileService
//{

//    private readonly string _directoryPath;
//    private readonly string _filePath;
//    private readonly JsonSerializerOptions _jsonSerializerOptions;
//    public FileService(string directoryPath = "Data", string fileName = "userlist.json")
//    {
//        _directoryPath = directoryPath;
//        _filePath = Path.Combine(_directoryPath, fileName);
//        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

//    }
//    public string GetContentFromFile()
//    {
//        if (File.Exists(_filePath)) 
//            return File.ReadAllText(_filePath);

//        return null!;
//    }

//    public void SaveContentToFile(string content)
//    {
//        if (!Directory.Exists(_directoryPath))
//            Directory.CreateDirectory(_directoryPath);

//        File.WriteAllText(_filePath, content);
//    }
//}
