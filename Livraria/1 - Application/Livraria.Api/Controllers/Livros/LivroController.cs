using Livraria.Api.Controllers.Base;
using Livraria.Dtos.Livros;
using Livraria.Services.Livros;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> AddAsync(LivroFormDto dto)
            => TratarRetorno(await _livroServices.AddAsync(dto));

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
            => Ok(await _livroServices.GetAllAsync());

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(LivroFormDto dto)
            => TratarRetorno(await _livroServices.UpdateAsync(dto));
    }
}