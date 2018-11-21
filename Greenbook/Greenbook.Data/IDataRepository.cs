using CSharpFunctionalExtensions;

namespace Greenbook.Data
{
    public interface IDataRepository
    {
        Result Save();

        Result Load();
    }
}