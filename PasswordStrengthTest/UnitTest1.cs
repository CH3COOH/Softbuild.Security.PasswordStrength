using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace PasswordStrengthTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testGeneralComplexity()
        {
            var result = Softbuild.Security.PasswordStrength.Validate("simple");
            Assert.IsTrue(result.Complexity == 0.344194323f);
        }

        [TestMethod]
        public void testSameComplexity()
        {
            var a = Softbuild.Security.PasswordStrength.Validate("abc").Complexity;
            var b = Softbuild.Security.PasswordStrength.Validate("abc").Complexity;
            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void testComparisonOfComplexity()
        {
            var a = Softbuild.Security.PasswordStrength.Validate("simple").Complexity;
            var b = Softbuild.Security.PasswordStrength.Validate("too!&%too'&)&%)very&&)very'''''''08786strongp@ssw0rd").Complexity;
            Assert.IsTrue(b > a);
        }

        [TestMethod]
        public void testComparisonOfCharacterSet1()
        {
            var a = Softbuild.Security.PasswordStrength.Validate("abc").Complexity;
            var b = Softbuild.Security.PasswordStrength.Validate("ab1").Complexity;
            Assert.IsTrue(b > a);
        }

        [TestMethod]
        public void testComparisonOfCharacterSet2()
        {
            var a = Softbuild.Security.PasswordStrength.Validate("abc").Complexity;
            var b = Softbuild.Security.PasswordStrength.Validate("ab!").Complexity;
            Assert.IsTrue(b > a);
        }

        [TestMethod]
        public void testComparisonOfCharacterSet3()
        {
            var a = Softbuild.Security.PasswordStrength.Validate("aaa").Complexity;
            var b = Softbuild.Security.PasswordStrength.Validate("abc").Complexity;
            Assert.IsTrue(b > a);
        }

        [TestMethod]
        public void testComparisonOfUpperCase()
        {
            var a = Softbuild.Security.PasswordStrength.Validate("abc").Complexity;
            var b = Softbuild.Security.PasswordStrength.Validate("Abc").Complexity;
            Assert.IsTrue(b > a);
        }

        [TestMethod]
        public void testComparisonOfLongPassword()
        {
            var a = Softbuild.Security.PasswordStrength.Validate("abcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabc").Complexity;
            var b = Softbuild.Security.PasswordStrength.Validate("zyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyxzyx").Complexity;
            Assert.IsTrue(a == b);
        }
    }
}
