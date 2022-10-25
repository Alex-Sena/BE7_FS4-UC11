using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chapter.Interfaces;
using Chapter.Models;
using Chapter.Repositories;

namespace Chapter.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public UsuarioController(IUsuarioRepository iUsuarioRepository)
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
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Usuario usuarioEncontrado = _iUsuarioRepository.BuscarPorId(id);

                if(usuarioEncontrado == null)
                    return NotFound();
                return Ok(usuarioEncontrado);
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuraio)
        {
            try
            {
                Usuario usuraioBuscado = _iUsuarioRepository.BuscarPorId(id);
                if(usuraioBuscado == null)
                {
                    return NotFound();
                }
                _iUsuarioRepository.Atualizar(id,usuraio);
                return StatusCode(204);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Usuario usurioBuscado = _iUsuarioRepository.BuscarPorId(id);
                if (usurioBuscado == null)
                {
                    return NotFound();
                }
                _iUsuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
