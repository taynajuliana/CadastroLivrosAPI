# CadastrLivrosAPI

## Projeto de API .NET8 com métodos CRUD de Livros e Autores

### Descrição
Este é um projeto de API simples em **.NET8** que utiliza entidades de **Livro** e **Autor** para realizar operações CRUD básicas.
A API permite que um usuário:
- Crie, leia, atualize e exclua **Autores**, cada um com **Nome** e **Sobrenome**.
- Crie, edite, remova e liste **Livros** com **Título** e **Autor**.

---

## **Pré-requisitos**
Para utilizar esta API, é necessário ter instalado:
- **.NET8**
- Um editor de código de sua escolha (**Visual Studio** ou **VSCode**)

---

## **Instalação**
1. Faça o clone do repositório em sua máquina local:
   ```sh
   git clone https://github.com/seu-repositorio.git
   ```
2. Abra o projeto no seu editor de código.
3. Execute o comando abaixo para compilar e executar o projeto:
   ```sh
   dotnet run
   ```
4. Acesse a API em seu navegador ou em uma ferramenta de teste de API (como **Postman** ou **Insomnia**) através da URL:
   ```
   http://localhost:5000
   ```

---

## **Rotas**
### **Autor**
- `GET /api/Autor/ListarAutores` - Retorna uma lista de autores.
- `GET /api/Autor/BuscarAutorPorId/{idAutor}` - Retorna o **id, nome e sobrenome** do autor.
- `GET /api/Autor/BuscarAutorPorIdLivro/{idLivro}` - Retorna o autor pelo **id do livro**.
- `POST /api/Autor/CriarAutor` - Cria um autor com propriedades de **Nome** e **Sobrenome**.
- `PUT /api/Autor/EditarAutor` - Edita um autor com propriedades de **Id, Nome e Sobrenome**.
- `DELETE /api/Autor/RemoverAutor/{idAutor}` - Remove um autor através do **id do autor**.

### **Livro**
- `GET /api/Livro/ListarLivros` - Retorna uma lista de livros.
- `GET /api/Livro/BuscarLivroPorId/{idLivro}` - Retorna as propriedades do livro pelo **id**.
- `GET /api/Livro/BuscarLivroPorIdAutor/{idAutor}` - Retorna os livros pelo **id do autor**.
- `POST /api/Livro/CriarLivro` - Cria um livro com propriedades de **Título** e a entidade **Autor**.
- `PUT /api/Livro/EditarLivro/{idLivro}` - Edita um livro através da busca pelo **id**, com as propriedades **Título** e a entidade **Autor**.
- `DELETE /api/Livro/RemoverLivro/{idLivro}` - Exclui um livro através do **id**.

---

## **Exemplo de uso**
Para criar um novo **Livro**, envie uma solicitação **POST** para a rota:
```
/api/Livro/CriarLivro
```
Com o seguinte corpo JSON:
```json
{
  "titulo": "O Senhor dos Anéis",
  "autor": {
    "id": 1,
    "nome": "J.R.R.",
    "sobrenome": "Tolkien"
  }
}
```

---

## **Contribuição**
Este é um projeto simples e qualquer contribuição é bem-vinda!
Sinta-se livre para **enviar um pull request** com melhorias ou correções de erros.

---

