using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Core.Enums;
using Epiphyllum.TemanRS.Core.Helpers;
using Xunit;

namespace Epiphyllum.TemanRS.Unit.Tests.Helpers
{
    public class PasswordHasherTests
    {
        private readonly CommonHelpers commonHelpers;
        private readonly PasswordHasher passwordHasher;

        public PasswordHasherTests()
        {
            commonHelpers = new CommonHelpers();
            passwordHasher = new PasswordHasher(commonHelpers);
        }

        [Fact]
        public void Should_hash_a_password()
        {
            string plainPassword = "Password";
            var hashedPassword = passwordHasher.HashPassword(plainPassword);
            var result = commonHelpers.IsBase64Encoded(hashedPassword);

            Assert.True(result);
        }

        [Fact]
        public void Should_succeed_verify_a_hashed_password()
        {
            string plainPassword = "Password";
            var hashedPassword = passwordHasher.HashPassword(plainPassword);
            var result = passwordHasher.VerifyHashedPassword(hashedPassword, "Password");

            Assert.Equal(PasswordVerificationStatus.Success, result);
        }

        [Fact]
        public void Should_failed_verify_a_hashed_password()
        {
            string plainPassword = "Password";
            var hashedPassword = passwordHasher.HashPassword(plainPassword);
            var result = passwordHasher.VerifyHashedPassword(hashedPassword, "password");

            Assert.Equal(PasswordVerificationStatus.Failed, result);
        }

        [Fact]
        public void Should_rehash_needed_verify_a_plain_password()
        {
            string plainPassword = "Password";
            var result = passwordHasher.VerifyHashedPassword(plainPassword, "Password");

            Assert.Equal(PasswordVerificationStatus.SuccessRehashNeeded, result);
        }

        [Fact]
        public void Should_failed_verify_a_plain_password()
        {
            string plainPassword = "Password";
            var result = passwordHasher.VerifyHashedPassword(plainPassword, "password");

            Assert.Equal(PasswordVerificationStatus.Failed, result);
        }
    }
}
