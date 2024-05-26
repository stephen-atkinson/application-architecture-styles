namespace DonutShop.BLL.Exceptions;

public class UserExistsException : Exception
{
    private readonly string _username;

    public UserExistsException(string username)
    {
        _username = username;
    }

    public override string Message => $"User with the username \"{_username}\" already exists";
}