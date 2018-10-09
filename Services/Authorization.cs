using Microsoft.AspNetCore.Authorization;

namespace AppApi.Services
{
    public class Authorization : AuthorizeAttribute
    {
        public Authorization()
        {
        }

        public Authorization(string policy) : base(policy)
        {
        }
    }
}