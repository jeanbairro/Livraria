using System.Collections.Generic;
using System.Linq;

namespace Livraria.Dtos.Base
{
    public class BaseDto
    {
        protected BaseDto()
        {
            Errors ??= new List<string>();
        }

        public ICollection<string> Errors { get; set; }

        public void AddError(string error)
        {
            if (!Errors.Contains(error))
                Errors.Add(error);
        }

        public void AddErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors) AddError(error);
        }

        public bool IsValid() => !Errors.Any();
    }
}