using Greenbook.Domain;
using Greenbook.Foundation.DependencyInjection;

namespace Greenbook.RandomTools
{
    public class RandomToolsViewModelLocator
    {
        public static TestOneViewModel TestOneViewModel =>
            SpringContext.GetObject<TestOneViewModel>("TestOneViewModel");

        public static TestTwoViewModel TestTwoViewModel =>
            SpringContext.GetObject<TestTwoViewModel>("TestTwoViewModel");
    }
}