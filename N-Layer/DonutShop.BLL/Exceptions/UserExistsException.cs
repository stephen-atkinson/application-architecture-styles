namespace DonutShop.BLL.Exceptions;

public class UserExistsException : Exception
{
    public UserExistsException(string username)
    {
        Username = username;
    }

    public string Username { get; }
    
    public override string Message => $"User with the username \"{Username}\" already exists.";
}