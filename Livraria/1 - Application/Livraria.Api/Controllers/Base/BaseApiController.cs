using Livraria.Dtos.Base;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Api.Controllers.Base
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected ActionResult TratarRetorno(BaseDto resultDto)
            => resultDto?.IsValid() ?? false
                ? (ActionResult)Ok(resultDto)
                : BadRequest(resultDto);

        protected ActionResult TratarRetorno(bool sucesso)
            => sucesso
                ? (ActionResult)Ok()
                : BadRequest();
    }
}