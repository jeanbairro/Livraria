using Livraria.Api.Controllers.Base;
using Livraria.Dtos.Livros;
using Livraria.Services.Livros;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Livraria.Api.Controllers.Livros
{
    [Route("api/livros")]
    public class LivroController : BaseApiController
    {
        private readonly ILivroServices _livroServices;

        public LivroController(ILivroServices livroServices)
        {
            _livroServices = livroServices;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(LivroFormDto dto, CancellationToken cancellationToken)
            => TratarRetorno(await _livroServices.AddAsync(dto, cancellationToken));

        [HttpDelete("{livroId}")]
        public async Task<ActionResult> DeleteAsync(long livroId, CancellationToken cancellationToken)
            => TratarRetorno(await _livroServices.DeleteAsync(livroId, cancellationToken));

        [HttpGet]
        public async Task<ActionResult> GetAllAsync(CancellationToken cancellationToken)
            => Ok(await _livroServices.GetAllAsync(cancellationToken));

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(LivroFormDto dto, CancellationToken cancellationToken)
            => TratarRetorno(await _livroServices.UpdateAsync(dto, cancellationToken));
    }
}