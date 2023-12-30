using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.ExternalServices.Interfaces;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IEmailService _emailService { get; }

        public AuthsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        /*[HttpPost]*/
        // Register controller
        // Email service send welcome message to registered user

    }
}
