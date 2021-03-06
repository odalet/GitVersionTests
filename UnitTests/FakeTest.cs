﻿using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace UnitTests
{
    [ExcludeFromCodeCoverage]
    public class FakeTest
    {
        [Fact]
        public void VB_code_test() =>
            Assert.Equal(4, ClassLibrary1.Class1.Add(2, 2));

        [Fact]
        public void CS_code_test() =>
            Assert.Equal(4, ClassLibrary2.Class1.Add(2, 2));

        [Fact]
        public void FS_code_test() =>
            Assert.Equal(4, ClassLibrary3.Class1.Add(2, 2));

        [Fact]
        public void CS_netstd10_code_test() =>
            Assert.Equal(4, NetStandard10.Class1.Add(2, 2));
    }
}
