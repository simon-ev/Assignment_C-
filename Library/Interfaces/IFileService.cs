
namespace Library.Interfaces;

public interface IFileService
{
    void SaveContentToFile(string content);
    string GetContentFromFile();
}
