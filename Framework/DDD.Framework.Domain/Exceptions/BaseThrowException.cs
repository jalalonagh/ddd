using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Framework.Domain.Exceptions
{
    public abstract class BaseThrowException
    {
        private IEnumerable<string> exceptions;
        
        public void AddException(IEnumerable<string> exceptions)
        {
            this.exceptions = exceptions;
        }

        public void ThrowExceptions()
        {
            var exs = exceptions.Where(w => w != string.Empty && w != "").ToList();
            if (exs.Any())
            {
                var ex = new Exception(string.Join(", ", exs));
                exceptions = Enumerable.Empty<string>();
                throw ex;
            }
        }

        public string GenerateErrorMessage(Type classType, string propertyName)
        {
            return $"{classType.Namespace}-{classType.Name}-{propertyName}";
        }
    }
}
