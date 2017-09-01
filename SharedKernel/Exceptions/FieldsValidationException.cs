using Domain.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SharedKernel.Exceptions
{
    public class FieldsValidationException : Exception
    {
        public IList<FieldValidationInfo> FieldsValidation { get; private set; }

        public FieldsValidationException(string message) : base(message)
        {
            FieldsValidation = new List<FieldValidationInfo>();
            FieldsValidation.Add(new FieldValidationInfo("", message, false));
        }

        public FieldsValidationException(string message, IList<FieldValidationInfo> fieldsValidation) : base(message)
        {
            this.FieldsValidation = fieldsValidation;
        }
    }
}
