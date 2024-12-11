
using System.Text.Json;
using UserCreate.Models;

namespace UserCreate.Services;

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


    public void SaveListToFile(List<UserRegForm> list)
    {
        if (!Directory.Exists(_directoryPath))
            Directory.CreateDirectory(_directoryPath);

        var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);
        File.WriteAllText(_filePath, json);
    }

    
    public List<UserRegForm> LoadListFromFile()
    {
        if (!File.Exists(_filePath))
            return [];

        var json = File.ReadAllText(_filePath);
        var list = JsonSerializer.Deserialize<List<UserRegForm>>(json, _jsonSerializerOptions);
        return list ?? [];
    }




}
