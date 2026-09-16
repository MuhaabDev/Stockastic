namespace Stockastic.Services.Authentication;
public interface IPasswordHasher
{
    string Hash(string password);
    bool verify(string password , string passwordHash);
}