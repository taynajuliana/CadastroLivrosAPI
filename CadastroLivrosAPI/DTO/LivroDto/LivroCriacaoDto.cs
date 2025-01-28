using CadastroLivrosAPI.Models;

namespace CadastroLivrosAPI.DTO.LivroDto
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }
        public AutorModel Autor { get; set; }
    }
}
