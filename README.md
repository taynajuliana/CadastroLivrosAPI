CadastrLivrosAPI
Projeto de API .NET8 com métodos CRUD de Livros e Autores.

Descrição
Este é um projeto de API simples em .NET8 que utiliza entidades de Livro e Autor para realizar operações CRUD básicas. A API permite que um usuário crie, leia, atualize e exclua Autores, cada um com Nome e Sobrenome e crie, edite, remova e liste livro com título e autor.

Pré-requisitos
Para utilizar esta API, é necessário ter instalado o .NET8 e um editor de código de sua escolha (como Visual Studio ou VSCode).

Instalação
Faça o clone do repositório em sua máquina local. Abra o projeto em seu editor de código de escolha. Execute o comando dotnet run para compilar e executar o projeto. Acesse a API em seu navegador ou em uma ferramenta de teste de API (como Postman ou Insomnia) através da URL http://localhost:5000. Rotas A seguir estão as rotas disponíveis nesta API:

##Autor
GET
/api/Autor/ListarAutores
Retorna uma lista de autores.

GET
/api/Autor/BuscarAutorPorId/{idAutor}
Retorna um o id, nome e sobrenome do autor.

GET
/api/Autor/BuscarAutorPorIdLivro
Retorna autor por id do livro. 

POST
/api/Autor/CriarAutor
Cria autor com propriedades de Nome e Sobrenome.

PUT
/api/Autor/EditarAutor
Edita autor com propriedades de Id, Nome e sobrenome.

DELETE
/api/Autor/RemoverAutor
Remove autor através do id do autor.

##Livro
GET
/api/Livro/ListarLivros
Retorna uma lista de livros.

GET
/api/Livro/BuscarLivroPorId/{idLivro}
Retorna as propriedades do livro por id.

GET
/api/Livro/BuscarLivroPorIdAutor
Retorna livro por id do autor. 

POST
/api/Livro/CriarLivro
Cria livro com propriedades de Título e entidade Autor.

PUT
/api/Livro/EditarLivro
Editar livro através da sua busca pelo seu id, com as propriedades Título e a entidade Autor

DELETE
/api/Livro/RemoverLivro
Excluir livro através do seu id.


##Exemplo de uso
Para criar um novo Livro, envie uma solicitação POST para a rota /api/Livro/CriarLivro com o seguinte corpo:
{
  "titulo": "string",
  "autor": {
    "id": 0,
    "nome": "string",
    "sobrenome": "string"
  }
}

##Contribuição
Este é um projeto simples e qualquer contribuição é bem-vinda! Sinta-se livre para enviar um pull request com melhorias ou correções de erros.
