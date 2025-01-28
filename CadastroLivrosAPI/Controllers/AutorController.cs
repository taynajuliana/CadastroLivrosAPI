using CadastroLivrosAPI.DTO.AutorDto;
using CadastroLivrosAPI.Models;
using CadastroLivrosAPI.Services.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroLivrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;
        public AutorController(IAutorInterface autorInterface)
        {
                _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autorIdLivro = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(autorIdLivro);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO)
        {
            var autores = await _autorInterface.CriarAutor(autorCriacaoDTO);
            return Ok(autores);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDTO autorEdicaoDTO)
        {
            var autores = await _autorInterface.EditarAutor(autorEdicaoDTO);
            return Ok(autores);
        }

        [HttpDelete("RemoverAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> RemoverAutor(int idAutor)
        {
            var autores = await _autorInterface.RemoverAutor(idAutor);
            return Ok(autores);
        }

    }
}
