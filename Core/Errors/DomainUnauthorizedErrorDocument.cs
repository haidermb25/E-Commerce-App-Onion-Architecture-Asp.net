using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Errors
{
    public class DomainUnauthorizedErrorDocument(string message):DomainError(message!)
    {
        public new string Type { get; set; } = "Unauthorized";
    }
}
