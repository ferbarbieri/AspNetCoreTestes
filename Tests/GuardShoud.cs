using Domain.SharedKernel.Exceptions;
using Domain.SharedKernel.Validation;
using Xunit;

namespace Tests
{
    public class GuardShoud
    {
        [Trait("Unit Test","")]
        [Theory]
        [InlineData(1, 1.1d, "string nao nula", "string nao vazia", "fbarbieri@live.com", "live.com")]
        [InlineData(1000, -500.1d, "", "0", "Fbarbieri@viceri.com.br", "viceri.com.br")]
        public void Validate(int valorMaior, decimal valorMenor, object notNull, string notEmpty, string email, string domain)
        {
            var ex = Record.Exception(() =>
             new Guard()
                 .GreaterThan("maior", valorMaior, 0)
                 .LessThan("menor", valorMenor, 2)
                 .NotNull("Não Nulo", notNull)
                 .NotNullOrEmpty("NaoVazio", notEmpty)
                 .ValidEmail("email", email)
                 .ValidDomain("domain", domain)
                 .Validate()
            );
            Assert.Null(ex);
        }

        [Trait("Unit Test", "")]
        [Theory]
        [InlineData(3, 5.1d, null, "", "fbarbieri", "")]
        [InlineData(-10, 500.1d, null, null, "Fbarbieri@viceri", "viceri")]
        [InlineData(5, 5, null, null, "Fbarbieri@viceri.", "viceri.")]
        public void ThrowExceptionOnInvalidInputData(int valorMaior, decimal valorMenor, object notNull, string notEmpty, string email, string domain)
        {
            var ex = Record.Exception(() =>
             new Guard()
                 .GreaterThan("maior", valorMaior, 5)
                 .LessThan("menor", valorMenor, 5)
                 .NotNull("Não Nulo", notNull)
                 .NotNullOrEmpty("NaoVazio", notEmpty)
                 .ValidEmail("email", email)
                 .ValidDomain("domain", domain)
                 .Validate()
            );

            Assert.IsType(typeof(FieldsValidationException), ex);

            var info = ((FieldsValidationException)ex).FieldsValidation;

            Assert.Equal(6, info.Count);
            
        }
    }
}
