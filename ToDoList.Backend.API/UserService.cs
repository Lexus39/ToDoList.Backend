using System.Security.Claims;

namespace ToDoList.Backend.API
{
    public class UserService
    {
        private readonly IHttpContextAccessor _context;

        public UserService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public ClaimsPrincipal GetCurrentUser()
        {
            if (_context.HttpContext == null)
                throw new ArgumentException();
            return _context.HttpContext.User;
        }

        public string GetCurrentUserName()
        {
            if (_context.HttpContext == null)
                throw new ArgumentException();
            return _context.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
    }
}
