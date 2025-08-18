using DatingAPP_API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingAPP_API.Controllers
{
    public class BuggeyController : APIController
    {
        private readonly DataContext _dbcontext;
        public BuggeyController(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet("not-found")]
        public ActionResult<string> GetNotFound() {
            var user = _dbcontext.Users.Find(Guid.Empty);
            if (user == null) { 
            return NotFound();
            }
            return Ok(user);
        }
        [Authorize]
        [HttpGet("auth")]

        public ActionResult<string> GetSecret() {
            return "secret text";
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var user = _dbcontext.Users.Find(Guid.Empty);
            return user.ToString();
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequests()
        {
            return BadRequest("this is a bad request");
        }
    }
}
