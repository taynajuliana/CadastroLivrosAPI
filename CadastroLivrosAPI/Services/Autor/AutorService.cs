using CadastroLivrosAPI.Data;
using CadastroLivrosAPI.DTO.AutorDto;
using CadastroLivrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivrosAPI.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;
                }
                resposta.Dados = autor;
                resposta.Mensagem = "Autor localizado.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livro => livro.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;
                }
                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor localizado.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _context.Autores.ToListAsync();

                resposta.Mensagem = "Todos os autores forem coletados!";
                resposta.Dados = autores;
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }
        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = new AutorModel()
                {
                    Nome = autorCriacaoDTO.Nome,
                    Sobrenome = autorCriacaoDTO.Sobrenome,
                };
                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDTO autorEdicaoDTO)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == autorEdicaoDTO.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado.";
                    resposta.Status = false;
                }
                autor.Nome = autorEdicaoDTO.Nome;
                autor.Sobrenome = autorEdicaoDTO.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor editado com sucesso.";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<AutorModel>>> RemoverAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado.";
                    resposta.Status = false;
                }
                _context.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor removido com sucesso.";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }
    }
}
