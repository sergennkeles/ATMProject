using ATMProject.Domain.Common;
using ATMProject.Domain.Entities;

namespace ATMProject.Application.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
