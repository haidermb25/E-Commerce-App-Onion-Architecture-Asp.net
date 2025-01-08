using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;

namespace Core.Errors
{
    public class DomainError(string message):Error(message)
    {
        public string Type { get; set; } = "DomainError";
    }
}
