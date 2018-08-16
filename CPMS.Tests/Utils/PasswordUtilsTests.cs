using System;
using CPMS.Common.Utils;
using NUnit.Framework;

namespace CPMS.Tests.Utils
{
    [TestFixture]
    public class PasswordUtilsTests
    {
        [Test]
        public void VerifyPasswordCreation()
        {
            var randomText = Guid.NewGuid().ToString();
            PasswordUtils.CreatePasswordHash(randomText, out var passwordHash, out var passwordSalt);
            Assert.IsTrue(PasswordUtils.VerifyPasswordHash(randomText, passwordHash, passwordSalt));
        }
    }
}
