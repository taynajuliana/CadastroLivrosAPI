using CadastroLivrosAPI.Data;
using CadastroLivrosAPI.DTO.AutorDto;
using CadastroLivrosAPI.DTO.LivroDto;
using CadastroLivrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivrosAPI.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            _context = context;      
        }
        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .Include(a=>a.Autor)
                    .Where(l=>l.Autor.Id == idAutor)
                    .ToListAsync();

                if (livro == null) 
                {
                    resposta.Mensagem = "Nnehum registro localizado.";
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Livro localizado.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Livro localizado.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(l=>l.Id == livroCriacaoDto.Autor.Id);

                var livro = new LivroModel()
                {
                    Autor = autor,
                    Titulo = livroCriacaoDto.Titulo,
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
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

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(a => a.Id == livroEdicaoDto.Id);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado.";
                    resposta.Status = false;
                }

                livro.Id = livroEdicaoDto.Id;
                livro.Titulo = livroEdicaoDto.Titulo;
                livro.Autor = livroEdicaoDto.Autor;


                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
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

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.ToListAsync();

                resposta.Mensagem = "Todos os livros forem coletados!";
                resposta.Dados = livros;
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<LivroModel>>> RemoverLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(a => a.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado.";
                    resposta.Status = false;
                }
                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
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
