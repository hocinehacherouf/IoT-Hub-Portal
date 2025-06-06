// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace IoTHub.Portal.Tests.Unit.Server.Extensions
{
    [TestFixture]
    public class StringExtensionTests
    {
        [TestCase("/*-+&\"'(-_)=}]@^\\`|[{# ", "-----------------------")]
        [TestCase("éèàçîïâäç", "eeaciiaac")]
        public void RemoveDiacriticsStateUnderTestExpectedBehavior(string input, string expected)
        {
            // Act
            var result = input.RemoveDiacritics();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenInputIsNullRemoveDiacriticsShouldReturnNull()
        {
            const string test = null;

            // Act
            var result = test.RemoveDiacritics();

            // Assert
            Assert.IsNull(result);
        }
    }
}
