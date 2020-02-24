# Livraria
Uma aplicação para gerenciar os livros da biblioteca municipal.

## Rotas
GET: api/livros (Lista de livros)
POST: api/livros (Cadastro de livros)
PUT: api/livros (Edição de livros)
DELETE: api/livros/{livroId} (Remoção de livros)

###Exemplo de body do POST
```javascript
{
	"Autor": "William",
	"Editora": "American Books Inc",
	"Titulo": "A hegemonia brasileira nas copas",
}
```

###Exemplo de body do PUT
```javascript
{
	"Autor": "William Scott",
	"Editora": "American Books",
	"Titulo": "A hegemonia do Brasil",
	"Id": 1
}
```
