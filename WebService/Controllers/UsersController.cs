using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.BLL.Interfaces;
using WebService.Mapping;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }        
        
        [HttpGet]
        public IActionResult Get()
        {
            var products =  _service.GetAll().MapToEnumerableUsers();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = _service.GetById(id).MapToUser();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
            //logger.LogInformation($"{p.Name} {p.Category}");
            //return await repository.Products.FindAsync(id);
            //return Ok(new { p.ProductId, p.Name, p.Price, p.CategoryId, p.SupplierId });
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            if (ModelState.IsValid)
            {
                _service.Create(user.MapToBLLUser());

                return Ok(user);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _service.GetAll().FirstOrDefault(x=> x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _service.Delete(user);

            return Ok(user);
        }

        [HttpPut]
        public IActionResult Put(int id, User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (!_service.GetAll().Any(x => x.Id == id))
            {
                return NotFound();
            }

            var newUser = user.MapToBLLUser();
            newUser.Id = id;

            _service.Update(newUser);

            return Ok(user);
        }
    }
}
