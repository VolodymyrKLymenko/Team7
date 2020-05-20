using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventSevice.Api.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost("login")]
        public ActionResult<AuthenticationResponse> Authenticate(AuthenticateRequest request)
        {
            // TODO implement this endpoint

            if (request.Password == "1111")
            {
                // With role = 'super-admin' in jwt token payload
                return
                    new AuthenticationResponse
                    {
                        AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyLCJyb2xlIjoic3VwZXItYWRtaW4ifQ.soWr6OmWdzCM8x9k6J5yZVAyCKJrlygIz1hkgcu_qJI",
                        UserId = 5,
                        UserName = "Test User"
                    };
            }

            return
                new AuthenticationResponse
                {
                    AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyLCJyb2xlIjoiYWRtaW4ifQ.HEvMnFJ5dU18e-VvYEBVXvoY3lsYxf-Onel3RCfb0Bc",
                    UserId = 5,
                    UserName = "Test User"
                };
        }

        public class AuthenticateRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class AuthenticationResponse
        {
            public string AccessToken { get; set; }
            public int UserId { get; set; }
            public string UserName { get; set; }
        }
    }
}
