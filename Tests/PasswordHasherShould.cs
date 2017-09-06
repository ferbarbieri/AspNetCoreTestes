using Domain.SharedKernel.Exceptions;
using Domain.SharedKernel.Utils;
using Domain.SharedKernel.Validation;
using System;
using Xunit;

namespace Tests
{
    public class PasswordHasherShould
    {
        [Trait("Unit Test","")]
        [Theory]
        [InlineData("Fernando123")]
        [InlineData("8zkxml6!!!")]
        public void HashPasswords(string senha)
        {
            var hash = PasswordHasher.Hash(senha);
            Assert.NotNull(hash);
        }

        [Trait("Unit Test", "")]
        [Theory]
        [InlineData("Fernando123", "$PWDHASH$V1$10000$BtV71lFdRXiSd9CZRTwW7e5arqNI2SM2siLYWxwJMPQOJGUD")]
        [InlineData("8zkxml6!!!", "$PWDHASH$V1$10000$KJk2AyIfElmWzcczygQVq8j/PErioGMyLNJ561AYw2W4pYkJ")]
        public void VerifyHashedPasswords(string senha, string hash)
        {
            Assert.True(PasswordHasher.Verify(senha, hash));
        }
    }
}
