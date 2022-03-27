using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Text;

namespace KappaCreations.Controllers
{
    public static class Utilities
    {
        public static string FormatDbEntityValidationException(
            DbEntityValidationException exception)
        {
            var sb = new StringBuilder();

            sb.Append("DbEntityValidationException. ");
            foreach (var result in exception.EntityValidationErrors)
            {
                string entity = result.Entry.Entity.GetType().Name;
                var errors = new List<string>();

                sb.Append(entity + ": ");
                foreach (var error in result.ValidationErrors)
                {
                    string property = error.PropertyName;
                    string message = error.ErrorMessage;

                    errors.Add($"{property} - {message}");
                }
                sb.Append(string.Join(", ", errors) + " ");
            }
            return sb.ToString();
        }
    }
}