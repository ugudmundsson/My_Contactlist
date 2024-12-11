using UserCreate.Models;

namespace UserCreate.Services;

public class UserService
{

    private List<UserRegForm> _users = [];
    private readonly FileService _fileService = new();


    public void Add(UserRegForm user)
    {
        
        _users.Add(user);
        _fileService.SaveListToFile(_users);

    }


    public List<UserRegForm> GetAll()
    {
        _users = _fileService.LoadListFromFile();
        return _users;  
    }

    public void Remove(UserRegForm user)
    {
        

        if (user != null)
        {
            _users.Remove(user);
            _fileService.SaveListToFile(_users);
        }
    }


}
