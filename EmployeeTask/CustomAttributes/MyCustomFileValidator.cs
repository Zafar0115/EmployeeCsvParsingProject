using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.CustomAttributes
{
    public class MyCustomFileValidator : ValidationAttribute
    {
        string[]? extensions = null;
        int maxByteSize;
        public MyCustomFileValidator(int maxByteSize, params string[]? extensions)
        {
            this.maxByteSize = maxByteSize;
            this.extensions = extensions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > maxByteSize)
                {
                    return new ValidationResult($"File size should not excess {maxByteSize / (1024 * 1024)}Mb");
                }
                if (extensions is not null)
                    if (!extensions.Contains(Path.GetExtension(file.FileName)))
                    {
                        return new ValidationResult($" You can download files only with extensions {string.Join(',', extensions)}");
                    }
            }

            return ValidationResult.Success;
        }


    }
}
