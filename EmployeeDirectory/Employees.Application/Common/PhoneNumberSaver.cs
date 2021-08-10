using System.Linq;

namespace Employees.Application.Common
{
    public static class PhoneNumberHandler
    {
        public static string HandlePhoneNumber(string request)
        {
            return (request == null) ? "" : string.Concat(request.Where(c => char.IsDigit(c)));
        }
    }
}
