using CadastroLivrosAPI.DTO.AutorDto;
using CadastroLivrosAPI.DTO.LivroDto;
using CadastroLivrosAPI.Models;
using CadastroLivrosAPI.Services.Autor;
using CadastroLivrosAPI.Services.Livro;
using Microsoft.AspNetCore.Mvc;

namespace CadastroLivrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }
        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var autor = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(autor);
        }

        [HttpGet("BuscarLivroPorIdAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var autorIdLivro = await _livroInterface.BuscarLivroPorAutor(idAutor);
            return Ok(autorIdLivro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var autores = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(autores);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var autores = await _livroInterface.EditarLivro(livroEdicaoDto);
            return Ok(autores);
        }

        [HttpDelete("RemoverLivro")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> RemoverLivro(int idLivro)
        {
            var autores = await _livroInterface.RemoverLivro(idLivro);
            return Ok(autores);
        }

    }
}
