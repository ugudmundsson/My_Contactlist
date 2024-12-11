namespace UserCreate.Models;

public static class UserFactory
{
    public static UserRegForm Create()
    {

        return new UserRegForm
        {
            Id = Guid.NewGuid().ToString()
        };
    }

    public static UserEntity Create(UserRegForm userRegForm)
    {
        return new UserEntity
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = userRegForm.FirstName,
            LastName = userRegForm.LastName,
            Email = userRegForm.Email,
            Mobnr = userRegForm.Mobnr,
            Streetnr = userRegForm.Streetnr,
            Citycode = userRegForm.Citycode,
            City = userRegForm.City,

        };
    }
}