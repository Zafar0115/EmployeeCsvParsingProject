using CsvHelper;
using System.Globalization;

namespace EmployeeTask.Services
{
    public class CsvParserService
    {
        public IEnumerable<T> GetEntities<T>(IFormFile file)
        {
            var entities = new List<T>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    T? record = csv.GetRecord<T>();
                    if (record is not null)
                        entities.Add(record);
                }
            }

            return entities;
        }
    }
}
