using FluentResults;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Errors
{
    public class DomainErrorDocument
    {
        public required int Status { get; set; }    

        public required string Title { get; set; }

        public List<DomainErrorDocumentError> Errors { get; set; } = [];
        
        public void AddError(IError error)
        {
            if(error is DomainValidationError domainValidationError)
            {
                AddFluentValidationError(domainValidationError.Errors);
            }
            else if(error is DomainError domainError)
            {
                AddDomainError(domainError);
            }
            else
            {
                Errors.Add(
                    new DomainErrorDocumentError
                    {
                        Type="Error",
                        Message=error.Message,
                    }
                    );
            }
        }

        public void AddDomainError(DomainError error)
        {
            Errors.Add(new DomainErrorDocumentError
                    {
                        Type=error.Type,
                        Message=error.Message,
                    });
        }

        public void AddFluentValidationError(List<ValidationFailure> errors)
        {
            foreach (var error in errors.GroupBy(x=>x.PropertyName))
            {
                var errorDocument = new DomainErrorDocumentError
                {
                    Type = "ValidationError",
                    Message = error.Key,
                    Errors = error.Select(x => x.ErrorMessage).ToList()
                };
                Errors.Add(errorDocument);
            }
        }

    }

    public class DomainErrorDocumentError
    {
        public required string Type {  get; set; }  
        public required string Message {  get; set; }

        public List<string> Errors { get; set; } = [];
    }
}
