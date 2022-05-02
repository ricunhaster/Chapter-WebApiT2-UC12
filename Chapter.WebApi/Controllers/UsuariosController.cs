using Chapter.WebApi.Interfaces;
using Chapter.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public UsuariosController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }
        
        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                return Ok(_iUsuarioRepository.Listar());
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

            Usuario usuarioEncontrado = _iUsuarioRepository.BuscarPorId(id);

            if (usuarioEncontrado == null)
             {
                return NotFound();
             }
                
                return Ok(usuarioEncontrado);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Atualizar(id, usuario);

                return Ok("Usuario alterado");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
               _iUsuarioRepository.Deletar(id);

                return Ok("Usuario deletado");

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


    }

}
