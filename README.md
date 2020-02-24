# Livraria
Uma aplicação para gerenciar os livros da biblioteca municipal.

## Dependências
_PostgreSQL_ [(download)](https://www.postgresql.org/download/)

## Rotas
**GET**: _api/livros_ (Lista de livros)

**POST**: _api/livros_ (Cadastro de livros)

**PUT**: _api/livros_ (Edição de livros)

**DELETE**: _api/livros/{livroId}_ (Remoção de livros)

### Exemplo de body do POST
```javascript
{
	"Autor": "William",
	"Editora": "American Books Inc",
	"Titulo": "A hegemonia brasileira nas copas",
}
```

### Exemplo de body do PUT
```javascript
{
	"Autor": "William Scott",
	"Editora": "American Books",
	"Titulo": "A hegemonia do Brasil",
	"Id": 1
}
```
