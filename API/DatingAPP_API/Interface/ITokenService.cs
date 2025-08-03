namespace DatingAPP_API.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
