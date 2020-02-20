using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Livraria.Domain.Base
{
    public abstract class ErrorBase
    {
        protected ErrorBase()
        {
            Errors ??= new List<string>();
        }

        [NotMapped]
        public ICollection<string> Errors { get; private set; }

        public void AddError(string error)
        {
            if (!Errors.Contains(error)) Errors.Add(error);
        }

        public void AddError(IEnumerable<string> errors)
        {
            foreach (var error in errors)
                AddError(error);
        }

        public void AddError(ErrorBase errorBase) => AddError(errorBase.Errors);

        public bool IsValid() => !Errors.Any();
    }
}