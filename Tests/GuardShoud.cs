using Domain.SharedKernel.Exceptions;
using Domain.SharedKernel.Validation;
using System;
using Xunit;

namespace Tests
{
    public class GuardShoud
    {
        [Theory]
        [InlineData(1, 1.1d, "string nao nula", "string nao vazia", "fbarbieri@live.com")]
        [InlineData(1000, -500.1d, "", "0", "Fbarbieri@viceri.com.br")]
        public void Validate(int valorMaior, decimal valorMenor, object notNull, string notEmpty, string email)
        {
            var ex = Record.Exception(() =>
             new Guard()
                 .GreaterThan("maior", valorMaior, 0)
                 .LessThan("menor", valorMenor, 2)
                 .NotNull("Não Nulo", notNull)
                 .NotNullOrEmpty("NaoVazio", notEmpty)
                 .ValidEmail("email", email)
                 .Validate()
            );
            Assert.Null(ex);
        }

        [Theory]
        [InlineData(3, 5.1d, null, "", "fbarbieri")]
        [InlineData(-10, 500.1d, null, null, "Fbarbieri@viceri")]
        [InlineData(5, 5, null, null, "Fbarbieri@viceri.")]
        public void ThrowExceptionOnInvalidInputData(int valorMaior, decimal valorMenor, object notNull, string notEmpty, string email)
        {
            var ex = Record.Exception(() =>
             new Guard()
                 .GreaterThan("maior", valorMaior, 5)
                 .LessThan("menor", valorMenor, 5)
                 .NotNull("Não Nulo", notNull)
                 .NotNullOrEmpty("NaoVazio", notEmpty)
                 .ValidEmail("email", email)
                 .Validate()
            );

            Assert.IsType(typeof(FieldsValidationException), ex);

            var info = ((FieldsValidationException)ex).FieldsValidation;

            Assert.Equal(5, info.Count);
            
        }
    }
}
