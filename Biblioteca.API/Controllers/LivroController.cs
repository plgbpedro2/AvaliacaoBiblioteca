using System.Threading.Tasks;
using Biblioteca.Domain;
using Biblioteca.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class LivroController : ControllerBase
    {
        private readonly IBibliotecaRepository _repo;

        public LivroController(IBibliotecaRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get(){

            try{

                var results = await _repo.GetAllLivroAsync();

                return Ok(results);
            }
            catch(System.Exception){

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        // get por Id
        [HttpGet("{LivroId}")]
        public async Task<IActionResult> Get(int livroId){

            try{

                var results = await _repo.GetAllLivroAsyncById(livroId);

                return Ok(results);
            }
            catch(System.Exception){

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Livro model){
            
            try
            {                
                _repo.Add(model);

                if(await _repo.SaveChangesAsync()){
                   
                    return Created($"/api/[controller]/{model.Id}",model);
                }

            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }


        [HttpPut]
        public async Task<IActionResult> Put(int livroId, Livro model){
            
            try
            {                
                var livro = await _repo.GetAllLivroAsyncById(livroId);
                if(livro == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync()){
                   
                    return Created($"/api/[controller]/{model.Id}",model);
                }

            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int livroId){
            
            try
            {                
                var livro = await _repo.GetAllLivroAsyncById(livroId);
                if(livro == null) return NotFound();

                _repo.Delete(livro);

                if(await _repo.SaveChangesAsync()){
                   
                    return Ok();
                }

            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();

        }


    }
}