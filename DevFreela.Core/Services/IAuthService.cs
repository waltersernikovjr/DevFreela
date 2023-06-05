namespace DevFreela.Core.Services
{
    public interface IAuthService
    {
        string GenarateJwtToken(string email, string role);
        string ComputeSha256Hash(string password);
    }
}
