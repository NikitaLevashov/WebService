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
        public async Task<ActionResult> GetUsers()
        {
            var products = await Task.Run(() => _service.GetAll().MapToEnumerableUsers());

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            User user = await Task.Run(()=>_service.Get(id).MapToUser());

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
        public async Task<ActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                await Task.Run(() => _service.Create(user.MapToBLLUser()));

                return Ok(user);
            }

            return BadRequest(ModelState);
        }
    }
}
