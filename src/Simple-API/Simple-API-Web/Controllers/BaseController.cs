using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Simple_API_Web.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TControler> : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Send<T>(T model)
        {
            try
            {
                var result = await _mediator.Send(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
    }
}