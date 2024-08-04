namespace Core;

public interface ICore 
{
	public bool RegisterUser(string email, string userName, string password);
	public bool AuthorizeUser(string userName, string password);
	public string GetPassword(string userName, string password, string appName);
}
