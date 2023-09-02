using EmployeeTask.CustomAttributes;
using EmployeeTask.Data;
using EmployeeTask.Models;
using EmployeeTask.Services;
using MediatR;

namespace EmployeeTask.CQRS.Commands
{
    public class ParseFileCommand:IRequest<IEnumerable<Employee>>
    {
        [MyCustomFileValidator(5, new[] {".csv",".xls",".xlsx",".tsv"})]
        public IFormFile file { get; set; }
    }

    public class ParseFileCommandHandler : IRequestHandler<ParseFileCommand, IEnumerable<Employee>>
    {
        private readonly CsvParserService _parserService;

        public ParseFileCommandHandler(CsvParserService parserService)
        {
            _parserService = parserService;
        }

        public Task<IEnumerable<Employee>> Handle(ParseFileCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_parserService.GetEntities<Employee>(request.file));
        }
    }
}
