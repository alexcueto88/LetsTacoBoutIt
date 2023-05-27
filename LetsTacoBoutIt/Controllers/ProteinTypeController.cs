using LetsTacoBoutIt.Repositories;
using Microsoft.AspNetCore.Mvc;
using LetsTacoBoutIt.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsTacoBoutIt.Controllers
{
    [Route("api/Protein")]
    [ApiController]
    public class ProteinTypeController : ControllerBase
    {   

        private readonly IProteinTypeRepository _proteinTypeRepository;
        public ProteinTypeController(IProteinTypeRepository proteinTypeRepository)
        {
            _proteinTypeRepository = proteinTypeRepository;
        }

        // GET: api/<ProteinTypeController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_proteinTypeRepository.GetAll());
        }
        // GET api/<ProteinTypeController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var protein = _proteinTypeRepository.GetById(id);
            if (protein == null)
            {
                return NotFound();
            }
            return Ok(protein);
        }

        // POST api/<ProteinTypeController>
        [HttpPost]
        public IActionResult Add(ProteinType protein)
        {
            _proteinTypeRepository.Insert(protein);
            return Created("/api/Protein/" + protein.id, protein);
        }

        // PUT api/<ProteinTypeController>/5
        [HttpPut("{id}")]
        public IActionResult Update(ProteinType protein)
        {
            _proteinTypeRepository.UpdateProtein(protein);
            return Created("/api/Protein" + protein.id, protein);
        }

        // DELETE api/<ProteinTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var protein = _proteinTypeRepository.GetById(id);
            if( protein == null)
            {
                return NotFound();
            }
            _proteinTypeRepository.Delete(id);
            return NoContent();
        }
        
    }
}
