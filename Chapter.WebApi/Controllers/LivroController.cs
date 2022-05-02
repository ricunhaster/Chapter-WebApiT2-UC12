using Chapter.WebApi.Models;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    //[Authorize]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Livro livroBuscado = _livroRepository.BuscarPorId(id);

                if (livroBuscado == null)
                {
                    return NotFound();
                }

                return Ok(livroBuscado);
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //[Authorize(Roles = "1")]
       
        [HttpPost]

        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);

                return StatusCode(201);

            }

            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

       [HttpPut("{id}")]

       public IActionResult Cadastrar(int id, Livro livro)
       {

            try
            {
                _livroRepository.Atualizar(id, livro);

                return StatusCode(204);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

       }

       //[Authorize(Roles = "1")]

       [HttpDelete("{id}")]

       public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);

                return Ok("Livro deletado");

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}

