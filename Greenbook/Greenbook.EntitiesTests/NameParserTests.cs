using Greenbook.Entities;
using NUnit.Framework;
using System.Linq;

namespace Greenbook.EntitiesTests
{
    [TestFixture()]
    public class NameParserTests
    {
        private const string TestName = "@Test Name";

        [TestCase("@TestName test test")]
        [TestCase("test @TestName test")]
        [TestCase(" test test @TestName")]
        public void NameParserTest(string value)
        {
            var results = new ContentNameParser(value).ToArray();

            Assert.IsTrue(results.Length == 1);

            Assert.AreEqual(TestName.ToLowerInvariant(), results.First());
        }
    }
}