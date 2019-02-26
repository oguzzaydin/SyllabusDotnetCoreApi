using DPA.Model;

namespace DPA.Domain
{
    public interface IUserDomainService
    {
        string GenerateHash(string text);

        string GenerateToken(SignedInModel signedInModel);
    }
}