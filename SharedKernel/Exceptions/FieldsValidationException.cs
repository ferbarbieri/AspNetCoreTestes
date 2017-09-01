using Domain.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public override string Message => GetErrorSummary();

        private string GetErrorSummary()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Os seguntes campos informados não são válidos:\n");
            
            foreach(var val in FieldsValidation.Where(c => !c.IsValid))
            {
                sb.Append($"{val.Field} : {val.Message}\n");
            }
            return sb.ToString();
        }
    }
}
