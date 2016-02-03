// <copyright file="PasswordEncryption.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using Xunit;

namespace FubarDev.Lexware.Database.Tests
{
    public class PasswordEncryption
    {
        [Fact(DisplayName = "Ver- und Entschlüsselung von _login_")]
        public void TestEncryption()
        {
            Assert.Equal("_login_", LexwarePassword.Decrypt("92ab346d1c02cffc"));
            Assert.Equal("92ab346d1c02cffc", LexwarePassword.Encrypt("_login_"));
        }
    }
}
