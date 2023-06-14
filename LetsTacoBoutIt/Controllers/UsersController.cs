using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LetsTacoBoutIt.Models;
using LetsTacoBoutIt.Repositories;

namespace LetsTacoBoutIt.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usersRepository.GetAll());
        }


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _usersRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // GET api/<UserController>/5
        [HttpGet("firebaseId/{firebaseId}")]
        public IActionResult GetUserByFirebaseId(string firebaseId)
        {
            var user = _usersRepository.GetUserByFirebaseId(firebaseId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        // POST api/<UserController>
        [HttpPost]
        public IActionResult AddUser(Users user)
        {
            _usersRepository.Insert(user);
            return Created("/api/user/" + user.id, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Users user)
        {
            _usersRepository.UpdateUser(user);
            return Created("/api/user/" + user.id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _usersRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _usersRepository.Delete(id);
            return NoContent();
        }
    }


}

