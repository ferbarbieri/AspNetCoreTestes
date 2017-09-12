using Domain.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.SharedKernel.Exceptions
{
    [Serializable]
    public class FieldsValidationException : MeritusException
    {
        public IList<FieldValidationInfo> FieldsValidation { get; private set; }

        public FieldsValidationException() : base("Um ou mais valores informados não são válidos.")
        {
        }

        public FieldsValidationException(string message) : base(message)
        {
        }

        public FieldsValidationException(string message, IList<FieldValidationInfo> fieldsValidation) : base(message)
        {
            FieldsValidation = fieldsValidation;
        }
    }
}
