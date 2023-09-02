using EmployeeTask.CQRS.Commands;
using EmployeeTask.Models;
using EmployeeTask.Services;
using Microsoft.AspNetCore.Http;

namespace Employees.Tests.Tests.Commands
{
    public class FileParseHandlerTests
    {
        private readonly string filePath = @"..\..\..\StaticFilesToTest\dataset.csv";
        private IFormFile file;
        private CsvParserService csvParserService;

        public FileParseHandlerTests()
        {
            csvParserService = new CsvParserService();

            var stream = new FileStream(filePath, FileMode.Open);
            file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
            {
                Headers = new HeaderDictionary(),
            };
        }


        [Fact]
        public async Task FileParseHandler_Success()
        {
            //Arrange
            var handler = new ParseFileCommandHandler(csvParserService);

            //Act
            IEnumerable<Employee> employees = await handler.Handle(new ParseFileCommand
            {
                file = file,
            }, CancellationToken.None);

            //Assert
            Assert.True(employees.Any());

        }
    }
}
