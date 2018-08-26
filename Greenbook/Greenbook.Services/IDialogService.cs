using CSharpFunctionalExtensions;

namespace Greenbook.Services
{
    public interface IDialogService
    {
        Result<string> Open();

        Result<string> Save();
    }
}