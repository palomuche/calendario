using Calendario.Data;
using Calendario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Calendario.Controllers
{
    [ApiController]
    [Route("api/teste")]
    public class TesteController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TesteController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teste>>> Get()
        {
            return await _context.Testes.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Teste>> GetTeste(int id)
        {
            var teste = await _context.Testes.FindAsync(id);

            return teste;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Teste>> PostTeste(Teste teste)
        {
            if(!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                //return ValidationProblem(ModelState);
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = "Um ou mais erros de validação ocorreram!",
                });
            }

            _context.Testes.Add(teste);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeste), new { Id = teste.Id }, teste);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutTeste(int id, Teste teste)
        {
            _context.Testes.Update(teste);  
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeste(int id)
        {
            var teste = await _context.Testes.FindAsync(id);

            _context.Testes.Remove(teste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #region Inicial
        //[HttpGet]
        //[ProducesResponseType(typeof(Teste), StatusCodes.Status200OK)]
        //public IActionResult Get()
        //{
        //    return Ok(new Teste { Id = 1, Nome = "Anônimo", Quantidade = 0 });
        //}

        //[ProducesResponseType(typeof(Teste), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpGet("{id:int}")]
        //public IActionResult Get(int id)
        //{
        //    return Ok(new Teste { Id = 1, Nome = "Anônimo", Quantidade = 0 });
        //}

        //[ProducesResponseType(typeof(Teste), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpPost]
        //public IActionResult Post(Teste teste)
        //{
        //    return CreatedAtAction("Get", new { id = teste.Id, teste });
        //}

        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Put(int id, Teste teste)
        //{
        //    if (id != teste.Id) return BadRequest();

        //    return NoContent();
        //}

        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult Delete(int id)
        //{
        //    return NoContent();
        //}
        #endregion
    }
}
