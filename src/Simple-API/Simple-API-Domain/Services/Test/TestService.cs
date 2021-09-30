using MediatR;
using Simple_API_Domain.Handlers.Test;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_API_Domain.Services
{
    public class TestService : BaseService, IRequestHandler<TestRequest, Unit>
    {
        public TestService() { }

        public async Task<Unit> Handle(TestRequest request, CancellationToken cancellationToken)
        {
            return await Unit.Task;
        }
    }
}
