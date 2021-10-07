using MediatR;
using Simple_API_Domain.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_API_Domain.Handlers.Test
{
    public class TestHandler : BaseCommand, IRequestHandler<TestCommand, Unit>
    {
        public async Task<Unit> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            return await Unit.Task;
        }
    }
}