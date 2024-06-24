using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Repositories.Interface;
using System.Security.Claims;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLUserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly DatabaseContext context;

        public SQLUserService(IHttpContextAccessor httpContextAccessor, DatabaseContext context)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.context = context;
        }
        public string GetMyName()
        {
            var result = string.Empty;
            if (httpContextAccessor.HttpContext != null)
                result = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name) ?? string.Empty;
            return result;
        }
        public string GetRoleName()
        {
            var result = string.Empty;
            if (httpContextAccessor.HttpContext != null)
                result = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role) ?? string.Empty;
            return result;
        }
    }
}
