using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.BLL.Interfaces;
using WebService.Mapping;
using WebService.Models;

namespace WebService.Controllers
{
    /// <summary>
    /// <c>Api UsersController</c>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService service, ILogger<UsersController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException();
            _service = service ?? throw new ArgumentNullException();
        }        
        
        /// <summary>
        /// Gets all users
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            _logger.LogInformation("Getting users ");
            _logger.LogTrace("Start method Get");
            var products =  _service.GetAll().MapToEnumerableUsers();

            _logger.LogInformation("Getting all users from the users table");
            _logger.LogInformation($"Status {Ok().StatusCode}");
            _logger.LogTrace("Finish method Get");

            return Ok(products);
        }

        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="id">user id.</param>
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            _logger.LogInformation("Getting user {Id}", id);
            _logger.LogTrace("Start method Get for id");

            var user = _service.GetById(id).MapToUser();

            if (user == null)
            {
                _logger.LogInformation($"Status code {NotFound().StatusCode}");
                _logger.LogWarning($"Get({id}) NOT FOUND");
                return NotFound();
            }

            _logger.LogInformation($"Id element contains the user {user.Name} {user.Surname}");
            _logger.LogInformation($"Status code {Ok().StatusCode}");
            _logger.LogTrace("Finish method Get");

            return Ok(user);
        }

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="user">new user.</param>
        [HttpPost]
        public ActionResult Post(User user)
        {
            _logger.LogTrace("Start method Post");

            if (ModelState.IsValid)
            {
                _logger.LogTrace("Start method Create");

                _service.Create(user.MapToBLLUser());

                _logger.LogTrace("Finish method Create");
                _logger.LogInformation($"Create user {user.Name} {user.Surname}");
                _logger.LogInformation($"Status code {Ok().StatusCode}");

                return Ok(user);
            }

            _logger.LogWarning($"POST({user}) Bad Request");

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="id">user id.</param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _logger.LogTrace("Start method Delete");

            var user = _service.GetAll().FirstOrDefault(x=> x.Id == id);

            if (user == null)
            {
                _logger.LogWarning($"Delete({id}) NOT FOUND");

                return NotFound();
            }

            _logger.LogTrace("Start method Delete");

            _service.Delete(user);

            _logger.LogTrace("Finish method Delete");
            _logger.LogInformation($"Delete user {user.Name} {user.Surname} ");
            _logger.LogInformation($"{Ok().StatusCode}");
            _logger.LogTrace("Finish method Post");

            return Ok(user);
        }

        /// <summary>
        /// Update user data.
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="user">new user data.</param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put(int id, User user)
        {
            _logger.LogTrace("Start method Put");

            if (user == null)
            {
                _logger.LogWarning($"PUT({id}) BAD REQUEST");
                _logger.LogInformation($"{BadRequest().StatusCode}");

                return BadRequest();
            }

            if (!_service.GetAll().Any(x => x.Id == id))
            {
                _logger.LogWarning($"PUT ({id}) NOT FOUND");
                _logger.LogInformation($"{NotFound().StatusCode}");

                return NotFound();
            }

            var newUser = user.MapToBLLUser();
            newUser.Id = id;

            _logger.LogTrace($"Start method Update");
            _service.Update(newUser);
            _logger.LogTrace($"Finish method Update");

            return Ok(user);
        }
    }
}
