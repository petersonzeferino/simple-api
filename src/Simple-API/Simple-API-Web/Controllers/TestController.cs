using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simple_API_Domain.Commands;
using System.Net;
using System.Threading.Tasks;

namespace Simple_API_Web.Controllers
{
    [ApiController]
    public class TestController : BaseController<TestController>
    {
        public TestController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Test() =>
            await Send(new TestCommand());
    }
}
